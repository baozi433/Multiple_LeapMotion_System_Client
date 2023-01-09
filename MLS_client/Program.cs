using System;
using System.Collections.Generic;

// Data transmission
using System.Net;
using System.Threading;
using Rug.Osc;

// Configuration file reading
using System.Xml;

// Leap Data
using Leap;

namespace MLS_client
{
    class MLSClientApp
    {
        LeapListener listener;
        Controller controller;
        ClientConnector connector;

        public MLSClientApp()
        {
            connector = new ClientConnector();

            controller = new Controller();
            SetControllerPolicy(connector.cameraconfig.mode);

            listener = new LeapListener(connector);
            controller.Connect += listener.OnServiceConnect;
            controller.Device += listener.OnConnect;
            controller.FrameReady += listener.OnFrame;
        }

        public void SetControllerPolicy(string policy)
        {
            Controller.PolicyFlag _policy;
            switch (policy)
            {
                case "HMD":
                    _policy = Controller.PolicyFlag.POLICY_OPTIMIZE_HMD;
                    break;
                case "BACKGROUND":
                    _policy = Controller.PolicyFlag.POLICY_DEFAULT;
                    break;
                default:
                    _policy = Controller.PolicyFlag.POLICY_BACKGROUND_FRAMES;
                    break;
            }

            while(!controller.IsPolicySet(_policy))
            {
                controller.SetPolicy(_policy);
            }

            Console.WriteLine("The controller has been set as " + _policy);
        }
    }

    class ClientConnector
    {
        OscNamespaceManager m_Listener;
        OscReceiver m_Receiver;
        OscSender m_Sender;
        Thread m_Thread;

        public CameraConfig cameraconfig;

        public ClientConnector()
        {
            cameraconfig = new CameraConfig();

            m_Listener = new OscNamespaceManager();

            m_Listener.Attach("/Lag", LagTest);
            m_Listener.Attach("/testB", TestMethodB);

            m_Receiver = new OscReceiver(cameraconfig.port);

            m_Sender = new OscSender(IPAddress.Parse(cameraconfig.serveraddress), cameraconfig.serverport, 4900, 4900);

            m_Receiver.Connect();
            m_Sender.Connect();
            Console.WriteLine("Connecting to Server");

            m_Thread = new Thread(new ThreadStart(ListenLoop));
            m_Thread.Start();
        }

        public OscSocketState SenderState()
        {
            return m_Sender.State;
        }

        public void SendLeapData(Frame frame)
        {
            m_Sender.Send(LeapFrameData.BuildLeapMessage(frame, cameraconfig.index));
        }

        public void SendDisconnectSingal()
        {
            m_Sender.Send(new OscMessage("/Disconnect", cameraconfig.index, "Disconnected"));
        }

        public void SendConnectSingal()
        {
            m_Sender.Send(new OscMessage("/Connect", cameraconfig.index, "Connected"));
        }

        void LagTest(OscMessage message)
        {
            Console.WriteLine("Receive Lag test");
            OscMessage synsignal = new OscMessage("/Lag", cameraconfig.index, message[1]);
            m_Sender.Send(synsignal);
        }

        void TestMethodB(OscMessage message)
        {
            Console.WriteLine("Test method B called!: " + message[0].ToString());
        }

        void ListenLoop()
        {
            try
            {
                while (m_Receiver.State != OscSocketState.Closed)
                {
                    // if we are in a state to recieve
                    if (m_Receiver.State == OscSocketState.Connected)
                    {
                        // get the next message 
                        // this will block until one arrives or the socket is closed
                        OscPacket packet = m_Receiver.Receive();

                        //Console.WriteLine("Received");

                        switch (m_Listener.ShouldInvoke(packet))
                        {
                            case OscPacketInvokeAction.Invoke:
                                //Console.WriteLine("Received packet");
                                m_Listener.Invoke(packet);
                                break;
                            case OscPacketInvokeAction.DontInvoke:
                                Console.WriteLine("Cannot invoke");
                                Console.WriteLine(packet.ToString());
                                break;
                            case OscPacketInvokeAction.HasError:
                                Console.WriteLine("Error reading osc packet, " + packet.Error);
                                Console.WriteLine(packet.ErrorMessage);
                                break;
                            case OscPacketInvokeAction.Pospone:
                                Console.WriteLine("Posponed bundle");
                                Console.WriteLine(packet.ToString());
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // if the socket was connected when this happens
                // then tell the user
                if (m_Receiver.State == OscSocketState.Connected)
                {
                    Console.WriteLine("Exception in listen loop");
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }

    class CameraConfig
    {
        // The camera name, which is used for identify camera
        public string name;

        // The camera's order in raw data list
        public int index;

        // The camera's Lan address
        public string address;

        // The server's Lan address
        public string serveraddress;

        // The camera's port
        public int port;

        // The server's port
        public int serverport;

        // The camera's working mode
        public string mode;

        public CameraConfig()
        {
            name = MLS_client.Properties.Resource.Name;

            ReadConfigurationFile();

            //Console.WriteLine("Name is " + name + ", Index is " + index + ", Address is " + address + ", Port is " + port + ", mode is " + mode);
        }

        void ReadConfigurationFile()
        {
            try
            {
                XmlDocument doc = new XmlDocument();

                XmlReaderSettings settings = new XmlReaderSettings();
                settings.IgnoreComments = true;

                XmlReader reader = XmlReader.Create("MLS_Global_Config.xml", settings);
                doc.Load(reader);

                XmlNode _xn_connecteddevice = doc.SelectSingleNode("connecteddevice");

                XmlNode _xn_serverdevice = _xn_connecteddevice.SelectSingleNode("serverdevice");
                XmlElement _xe_server = (XmlElement)_xn_serverdevice.ChildNodes[0];
                serveraddress = _xe_server.ChildNodes.Item(0).InnerText;
                serverport = int.Parse(_xe_server.ChildNodes.Item(1).InnerText);

                XmlNode _xn_clientdevice = _xn_connecteddevice.SelectSingleNode("clientdevice");
                XmlNodeList _xnl_clientdeviceliset = _xn_clientdevice.ChildNodes;

                foreach (XmlNode xn in _xnl_clientdeviceliset)
                {
                    XmlElement xe = (XmlElement)xn;

                    if (xe.GetAttribute("Name") == name)
                    {
                        XmlNodeList xnl = xe.ChildNodes;
                        index = int.Parse(xe.GetAttribute("Index"));
                        address = xnl.Item(1).InnerText;
                        port = int.Parse(xnl.Item(2).InnerText);
                        mode = xnl.Item(3).InnerText;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //string GetLocalIP()
        //{
        //    //string hostname = Dns.GetHostName();
        //    //IPAddress[] addressList = Dns.GetHostAddresses(hostname);
        //    //return addressList[1].ToString();

        //    return MLS_client.Properties.Resource.Name;
        //}
    }

    class LeapListener
    {
        ClientConnector leapSender;

        public LeapListener(ClientConnector clientconnector)
        {
            leapSender = clientconnector;
        }

        public void OnServiceConnect(object sender, ConnectionEventArgs args)
        {
            Console.WriteLine("Service Connected");

        }

        public void OnConnect(object sender, DeviceEventArgs args)
        {
            Console.WriteLine("Connected");

            if (leapSender.SenderState() == OscSocketState.Connected)
            {
                leapSender.SendConnectSingal();
            }
        }

        public void OnFrame(object sender, FrameEventArgs args)
        {
            // Get the most recent frame and report some basic information
            //Console.WriteLine("Frame " + args.frame.Hands.Count);
            Frame frame = args.frame;

            if (leapSender.SenderState() == OscSocketState.Connected)
            {
                leapSender.SendLeapData(frame);
            }
        }

        public void OnServiceDisconnect()
        {
            if (leapSender.SenderState() == OscSocketState.Connected)
            {
                leapSender.SendConnectSingal();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MLSClientApp app = new MLSClientApp();

            Console.ReadKey(true);
        }
        
    }
}
