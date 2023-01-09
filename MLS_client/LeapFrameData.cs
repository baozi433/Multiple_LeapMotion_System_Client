using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Rug.Osc;
using Leap;

namespace MLS_client
{
    class LeapFrameData
    {
        public LeapFrameData() { }

        static public OscMessage BuildLeapMessage(Frame frame, int index)
        {
            var address = "/Data";

            OscMessage leapData = new OscMessage(address, index, 0);

            int handsCount = frame.Hands.Count;

            if (handsCount == 0)
            {
                return leapData;
            }

            Leap.Hand leftHand, rightHand;

            Leap.Arm leftArm, rightArm;

            Leap.Finger leftThumb, leftIndex, leftMiddle, leftRing, leftPinky, rightThumb, rightIndex, rightMiddle, rightRing, rightPinky;

            Leap.Bone leftThumbMeta, leftThumbProx, leftThumbInter, leftThumbDist;
            Leap.Bone leftIndexMeta, leftIndexProx, leftIndexInter, leftIndexDist;
            Leap.Bone leftMiddleMeta, leftMiddleProx, leftMiddleInter, leftMiddleDist;
            Leap.Bone leftRingMeta, leftRingProx, leftRingInter, leftRingDist;
            Leap.Bone leftPinkyMeta, leftPinkyProx, leftPinkyInter, leftPinkyDist;

            Leap.Bone rightThumbMeta, rightThumbProx, rightThumbInter, rightThumbDist;
            Leap.Bone rightIndexMeta, rightIndexProx, rightIndexInter, rightIndexDist;
            Leap.Bone rightMiddleMeta, rightMiddleProx, rightMiddleInter, rightMiddleDist;
            Leap.Bone rightRingMeta, rightRingProx, rightRingInter, rightRingDist;
            Leap.Bone rightPinkyMeta, rightPinkyProx, rightPinkyInter, rightPinkyDist;

            if (frame.Hands.Count == 2)
            {
                if (frame.Hands[0].IsLeft)
                {
                    leftHand = frame.Hands[0];
                    rightHand = frame.Hands[1];

                    leftArm = leftHand.Arm;
                    rightArm = rightHand.Arm;

                    leftThumb = frame.Hands[0].Fingers[0];
                    leftIndex = frame.Hands[0].Fingers[1];
                    leftMiddle = frame.Hands[0].Fingers[2];
                    leftRing = frame.Hands[0].Fingers[3];
                    leftPinky = frame.Hands[0].Fingers[4];
                    rightThumb = frame.Hands[1].Fingers[0];
                    rightIndex = frame.Hands[1].Fingers[1];
                    rightMiddle = frame.Hands[1].Fingers[2];
                    rightRing = frame.Hands[1].Fingers[3];
                    rightPinky = frame.Hands[1].Fingers[4];
                }
                else
                {
                    leftHand = frame.Hands[1];
                    rightHand = frame.Hands[0];

                    leftArm = leftHand.Arm;
                    rightArm = rightHand.Arm;

                    leftThumb = frame.Hands[1].Fingers[0];
                    leftIndex = frame.Hands[1].Fingers[1];
                    leftMiddle = frame.Hands[1].Fingers[2];
                    leftRing = frame.Hands[1].Fingers[3];
                    leftPinky = frame.Hands[1].Fingers[4];
                    rightThumb = frame.Hands[0].Fingers[0];
                    rightIndex = frame.Hands[0].Fingers[1];
                    rightMiddle = frame.Hands[0].Fingers[2];
                    rightRing = frame.Hands[0].Fingers[3];
                    rightPinky = frame.Hands[0].Fingers[4];
                }

                leftThumbMeta = leftThumb.bones[0];
                leftThumbProx = leftThumb.bones[1];
                leftThumbInter = leftThumb.bones[2];
                leftThumbDist = leftThumb.bones[3];

                leftIndexMeta = leftIndex.bones[0];
                leftIndexProx = leftIndex.bones[1];
                leftIndexInter = leftIndex.bones[2];
                leftIndexDist = leftIndex.bones[3];

                leftMiddleMeta = leftMiddle.bones[0];
                leftMiddleProx = leftMiddle.bones[1];
                leftMiddleInter = leftMiddle.bones[2];
                leftMiddleDist = leftMiddle.bones[3];

                leftRingMeta = leftRing.bones[0];
                leftRingProx = leftRing.bones[1];
                leftRingInter = leftRing.bones[2];
                leftRingDist = leftRing.bones[3];

                leftPinkyMeta = leftPinky.bones[0];
                leftPinkyProx = leftPinky.bones[1];
                leftPinkyInter = leftPinky.bones[2];
                leftPinkyDist = leftPinky.bones[3];

                rightThumbMeta = rightThumb.bones[0];
                rightThumbProx = rightThumb.bones[1];
                rightThumbInter = rightThumb.bones[2];
                rightThumbDist = rightThumb.bones[3];

                rightIndexMeta = rightIndex.bones[0];
                rightIndexProx = rightIndex.bones[1];
                rightIndexInter = rightIndex.bones[2];
                rightIndexDist = rightIndex.bones[3];

                rightMiddleMeta = rightMiddle.bones[0];
                rightMiddleProx = rightMiddle.bones[1];
                rightMiddleInter = rightMiddle.bones[2];
                rightMiddleDist = rightMiddle.bones[3];

                rightRingMeta = rightRing.bones[0];
                rightRingProx = rightRing.bones[1];
                rightRingInter = rightRing.bones[2];
                rightRingDist = rightRing.bones[3];

                rightPinkyMeta = rightPinky.bones[0];
                rightPinkyProx = rightPinky.bones[1];
                rightPinkyInter = rightPinky.bones[2];
                rightPinkyDist = rightPinky.bones[3];

                leapData = new OscMessage(address, index, handsCount,
                    //Left Hand Bone Data
                    leftThumbMeta.PrevJoint.x, leftThumbMeta.PrevJoint.y, leftThumbMeta.PrevJoint.z, leftThumbMeta.NextJoint.x, leftThumbMeta.NextJoint.y, leftThumbMeta.NextJoint.z, leftThumbMeta.Center.x, leftThumbMeta.Center.y, leftThumbMeta.Center.z, leftThumbMeta.Direction.x, leftThumbMeta.Direction.y, leftThumbMeta.Direction.z, leftThumbMeta.Length, leftThumbMeta.Width, 0, leftThumbMeta.Rotation.x, leftThumbMeta.Rotation.y, leftThumbMeta.Rotation.z, leftThumbMeta.Rotation.w,
                    leftThumbProx.PrevJoint.x, leftThumbProx.PrevJoint.y, leftThumbProx.PrevJoint.z, leftThumbProx.NextJoint.x, leftThumbProx.NextJoint.y, leftThumbProx.NextJoint.z, leftThumbProx.Center.x, leftThumbProx.Center.y, leftThumbProx.Center.z, leftThumbProx.Direction.x, leftThumbProx.Direction.y, leftThumbProx.Direction.z, leftThumbProx.Length, leftThumbProx.Width, 1, leftThumbProx.Rotation.x, leftThumbProx.Rotation.y, leftThumbProx.Rotation.z, leftThumbProx.Rotation.w,
                    leftThumbInter.PrevJoint.x, leftThumbInter.PrevJoint.y, leftThumbInter.PrevJoint.z, leftThumbInter.NextJoint.x, leftThumbInter.NextJoint.y, leftThumbInter.NextJoint.z, leftThumbInter.Center.x, leftThumbInter.Center.y, leftThumbInter.Center.z, leftThumbInter.Direction.x, leftThumbInter.Direction.y, leftThumbInter.Direction.z, leftThumbInter.Length, leftThumbInter.Width, 2, leftThumbInter.Rotation.x, leftThumbInter.Rotation.y, leftThumbInter.Rotation.z, leftThumbInter.Rotation.w,
                    leftThumbDist.PrevJoint.x, leftThumbDist.PrevJoint.y, leftThumbDist.PrevJoint.z, leftThumbDist.NextJoint.x, leftThumbDist.NextJoint.y, leftThumbDist.NextJoint.z, leftThumbDist.Center.x, leftThumbDist.Center.y, leftThumbDist.Center.z, leftThumbDist.Direction.x, leftThumbDist.Direction.y, leftThumbDist.Direction.z, leftThumbDist.Length, leftThumbDist.Width, 3, leftThumbDist.Rotation.x, leftThumbDist.Rotation.y, leftThumbDist.Rotation.z, leftThumbDist.Rotation.w,

                    leftIndexMeta.PrevJoint.x, leftIndexMeta.PrevJoint.y, leftIndexMeta.PrevJoint.z, leftIndexMeta.NextJoint.x, leftIndexMeta.NextJoint.y, leftIndexMeta.NextJoint.z, leftIndexMeta.Center.x, leftIndexMeta.Center.y, leftIndexMeta.Center.z, leftIndexMeta.Direction.x, leftIndexMeta.Direction.y, leftIndexMeta.Direction.z, leftIndexMeta.Length, leftIndexMeta.Width, 0, leftIndexMeta.Rotation.x, leftIndexMeta.Rotation.y, leftIndexMeta.Rotation.z, leftIndexMeta.Rotation.w,
                    leftIndexProx.PrevJoint.x, leftIndexProx.PrevJoint.y, leftIndexProx.PrevJoint.z, leftIndexProx.NextJoint.x, leftIndexProx.NextJoint.y, leftIndexProx.NextJoint.z, leftIndexProx.Center.x, leftIndexProx.Center.y, leftIndexProx.Center.z, leftIndexProx.Direction.x, leftIndexProx.Direction.y, leftIndexProx.Direction.z, leftIndexProx.Length, leftIndexProx.Width, 1, leftIndexProx.Rotation.x, leftIndexProx.Rotation.y, leftIndexProx.Rotation.z, leftIndexProx.Rotation.w,
                    leftIndexInter.PrevJoint.x, leftIndexInter.PrevJoint.y, leftIndexInter.PrevJoint.z, leftIndexInter.NextJoint.x, leftIndexInter.NextJoint.y, leftIndexInter.NextJoint.z, leftIndexInter.Center.x, leftIndexInter.Center.y, leftIndexInter.Center.z, leftIndexInter.Direction.x, leftIndexInter.Direction.y, leftIndexInter.Direction.z, leftIndexInter.Length, leftIndexInter.Width, 2, leftIndexInter.Rotation.x, leftIndexInter.Rotation.y, leftIndexInter.Rotation.z, leftIndexInter.Rotation.w,
                    leftIndexDist.PrevJoint.x, leftIndexDist.PrevJoint.y, leftIndexDist.PrevJoint.z, leftIndexDist.NextJoint.x, leftIndexDist.NextJoint.y, leftIndexDist.NextJoint.z, leftIndexDist.Center.x, leftIndexDist.Center.y, leftIndexDist.Center.z, leftIndexDist.Direction.x, leftIndexDist.Direction.y, leftIndexDist.Direction.z, leftIndexDist.Length, leftIndexDist.Width, 3, leftIndexDist.Rotation.x, leftIndexDist.Rotation.y, leftIndexDist.Rotation.z, leftIndexDist.Rotation.w,

                    leftMiddleMeta.PrevJoint.x, leftMiddleMeta.PrevJoint.y, leftMiddleMeta.PrevJoint.z, leftMiddleMeta.NextJoint.x, leftMiddleMeta.NextJoint.y, leftMiddleMeta.NextJoint.z, leftMiddleMeta.Center.x, leftMiddleMeta.Center.y, leftMiddleMeta.Center.z, leftMiddleMeta.Direction.x, leftMiddleMeta.Direction.y, leftMiddleMeta.Direction.z, leftMiddleMeta.Length, leftMiddleMeta.Width, 0, leftMiddleMeta.Rotation.x, leftMiddleMeta.Rotation.y, leftMiddleMeta.Rotation.z, leftMiddleMeta.Rotation.w,
                    leftMiddleProx.PrevJoint.x, leftMiddleProx.PrevJoint.y, leftMiddleProx.PrevJoint.z, leftMiddleProx.NextJoint.x, leftMiddleProx.NextJoint.y, leftMiddleProx.NextJoint.z, leftMiddleProx.Center.x, leftMiddleProx.Center.y, leftMiddleProx.Center.z, leftMiddleProx.Direction.x, leftMiddleProx.Direction.y, leftMiddleProx.Direction.z, leftMiddleProx.Length, leftMiddleProx.Width, 1, leftMiddleProx.Rotation.x, leftMiddleProx.Rotation.y, leftMiddleProx.Rotation.z, leftMiddleProx.Rotation.w,
                    leftMiddleInter.PrevJoint.x, leftMiddleInter.PrevJoint.y, leftMiddleInter.PrevJoint.z, leftMiddleInter.NextJoint.x, leftMiddleInter.NextJoint.y, leftMiddleInter.NextJoint.z, leftMiddleInter.Center.x, leftMiddleInter.Center.y, leftMiddleInter.Center.z, leftMiddleInter.Direction.x, leftMiddleInter.Direction.y, leftMiddleInter.Direction.z, leftMiddleInter.Length, leftMiddleInter.Width, 2, leftMiddleInter.Rotation.x, leftMiddleInter.Rotation.y, leftMiddleInter.Rotation.z, leftMiddleInter.Rotation.w,
                    leftMiddleDist.PrevJoint.x, leftMiddleDist.PrevJoint.y, leftMiddleDist.PrevJoint.z, leftMiddleDist.NextJoint.x, leftMiddleDist.NextJoint.y, leftMiddleDist.NextJoint.z, leftMiddleDist.Center.x, leftMiddleDist.Center.y, leftMiddleDist.Center.z, leftMiddleDist.Direction.x, leftMiddleDist.Direction.y, leftMiddleDist.Direction.z, leftMiddleDist.Length, leftMiddleDist.Width, 3, leftMiddleDist.Rotation.x, leftMiddleDist.Rotation.y, leftMiddleDist.Rotation.z, leftMiddleDist.Rotation.w,

                    leftRingMeta.PrevJoint.x, leftRingMeta.PrevJoint.y, leftRingMeta.PrevJoint.z, leftRingMeta.NextJoint.x, leftRingMeta.NextJoint.y, leftRingMeta.NextJoint.z, leftRingMeta.Center.x, leftRingMeta.Center.y, leftRingMeta.Center.z, leftRingMeta.Direction.x, leftRingMeta.Direction.y, leftRingMeta.Direction.z, leftRingMeta.Length, leftRingMeta.Width, 0, leftRingMeta.Rotation.x, leftRingMeta.Rotation.y, leftRingMeta.Rotation.z, leftRingMeta.Rotation.w,
                    leftRingProx.PrevJoint.x, leftRingProx.PrevJoint.y, leftRingProx.PrevJoint.z, leftRingProx.NextJoint.x, leftRingProx.NextJoint.y, leftRingProx.NextJoint.z, leftRingProx.Center.x, leftRingProx.Center.y, leftRingProx.Center.z, leftRingProx.Direction.x, leftRingProx.Direction.y, leftRingProx.Direction.z, leftRingProx.Length, leftRingProx.Width, 1, leftRingProx.Rotation.x, leftRingProx.Rotation.y, leftRingProx.Rotation.z, leftRingProx.Rotation.w,
                    leftRingInter.PrevJoint.x, leftRingInter.PrevJoint.y, leftRingInter.PrevJoint.z, leftRingInter.NextJoint.x, leftRingInter.NextJoint.y, leftRingInter.NextJoint.z, leftRingInter.Center.x, leftRingInter.Center.y, leftRingInter.Center.z, leftRingInter.Direction.x, leftRingInter.Direction.y, leftRingInter.Direction.z, leftRingInter.Length, leftRingInter.Width, 2, leftRingInter.Rotation.x, leftRingInter.Rotation.y, leftRingInter.Rotation.z, leftRingInter.Rotation.w,
                    leftRingDist.PrevJoint.x, leftRingDist.PrevJoint.y, leftRingDist.PrevJoint.z, leftRingDist.NextJoint.x, leftRingDist.NextJoint.y, leftRingDist.NextJoint.z, leftRingDist.Center.x, leftRingDist.Center.y, leftRingDist.Center.z, leftRingDist.Direction.x, leftRingDist.Direction.y, leftRingDist.Direction.z, leftRingDist.Length, leftRingDist.Width, 3, leftRingDist.Rotation.x, leftRingDist.Rotation.y, leftRingDist.Rotation.z, leftRingDist.Rotation.w,

                    leftPinkyMeta.PrevJoint.x, leftPinkyMeta.PrevJoint.y, leftPinkyMeta.PrevJoint.z, leftPinkyMeta.NextJoint.x, leftPinkyMeta.NextJoint.y, leftPinkyMeta.NextJoint.z, leftPinkyMeta.Center.x, leftPinkyMeta.Center.y, leftPinkyMeta.Center.z, leftPinkyMeta.Direction.x, leftPinkyMeta.Direction.y, leftPinkyMeta.Direction.z, leftPinkyMeta.Length, leftPinkyMeta.Width, 0, leftPinkyMeta.Rotation.x, leftPinkyMeta.Rotation.y, leftPinkyMeta.Rotation.z, leftPinkyMeta.Rotation.w,
                    leftPinkyProx.PrevJoint.x, leftPinkyProx.PrevJoint.y, leftPinkyProx.PrevJoint.z, leftPinkyProx.NextJoint.x, leftPinkyProx.NextJoint.y, leftPinkyProx.NextJoint.z, leftPinkyProx.Center.x, leftPinkyProx.Center.y, leftPinkyProx.Center.z, leftPinkyProx.Direction.x, leftPinkyProx.Direction.y, leftPinkyProx.Direction.z, leftPinkyProx.Length, leftPinkyProx.Width, 1, leftPinkyProx.Rotation.x, leftPinkyProx.Rotation.y, leftPinkyProx.Rotation.z, leftPinkyProx.Rotation.w,
                    leftPinkyInter.PrevJoint.x, leftPinkyInter.PrevJoint.y, leftPinkyInter.PrevJoint.z, leftPinkyInter.NextJoint.x, leftPinkyInter.NextJoint.y, leftPinkyInter.NextJoint.z, leftPinkyInter.Center.x, leftPinkyInter.Center.y, leftPinkyInter.Center.z, leftPinkyInter.Direction.x, leftPinkyInter.Direction.y, leftPinkyInter.Direction.z, leftPinkyInter.Length, leftPinkyInter.Width, 2, leftPinkyInter.Rotation.x, leftPinkyInter.Rotation.y, leftPinkyInter.Rotation.z, leftPinkyInter.Rotation.w,
                    leftPinkyDist.PrevJoint.x, leftPinkyDist.PrevJoint.y, leftPinkyDist.PrevJoint.z, leftPinkyDist.NextJoint.x, leftPinkyDist.NextJoint.y, leftPinkyDist.NextJoint.z, leftPinkyDist.Center.x, leftPinkyDist.Center.y, leftPinkyDist.Center.z, leftPinkyDist.Direction.x, leftPinkyDist.Direction.y, leftPinkyDist.Direction.z, leftPinkyDist.Length, leftPinkyDist.Width, 3, leftPinkyDist.Rotation.x, leftPinkyDist.Rotation.y, leftPinkyDist.Rotation.z, leftPinkyDist.Rotation.w,

                    //Left Hand Finger Data
                    frame.Id, leftHand.Id,
                    leftThumb.Id, leftThumb.TimeVisible, leftThumb.TipPosition.x, leftThumb.TipPosition.y, leftThumb.TipPosition.z, leftThumb.Direction.x, leftThumb.Direction.y, leftThumb.Direction.z, leftThumb.Width, leftThumb.Length, leftThumb.IsExtended, 0,
                    leftIndex.Id, leftIndex.TimeVisible, leftIndex.TipPosition.x, leftIndex.TipPosition.y, leftIndex.TipPosition.z, leftIndex.Direction.x, leftIndex.Direction.y, leftIndex.Direction.z, leftIndex.Width, leftIndex.Length, leftIndex.IsExtended, 0,
                    leftMiddle.Id, leftMiddle.TimeVisible, leftMiddle.TipPosition.x, leftMiddle.TipPosition.y, leftMiddle.TipPosition.z, leftMiddle.Direction.x, leftMiddle.Direction.y, leftMiddle.Direction.z, leftMiddle.Width, leftMiddle.Length, leftMiddle.IsExtended, 0,
                    leftRing.Id, leftRing.TimeVisible, leftRing.TipPosition.x, leftRing.TipPosition.y, leftRing.TipPosition.z, leftRing.Direction.x, leftRing.Direction.y, leftRing.Direction.z, leftRing.Width, leftRing.Length, leftRing.IsExtended, 0,
                    leftPinky.Id, leftPinky.TimeVisible, leftPinky.TipPosition.x, leftPinky.TipPosition.y, leftPinky.TipPosition.z, leftPinky.Direction.x, leftPinky.Direction.y, leftPinky.Direction.z, leftPinky.Width, leftPinky.Length, leftPinky.IsExtended, 0,

                    //Left Arm Data
                    leftArm.ElbowPosition.x, leftArm.ElbowPosition.y, leftArm.ElbowPosition.z, leftArm.WristPosition.x, leftArm.WristPosition.y, leftArm.WristPosition.z, leftArm.Center.x, leftArm.Center.y, leftArm.Center.z, leftArm.Direction.x, leftArm.Direction.y, leftArm.Direction.z, leftArm.Length, leftArm.Width, leftArm.Rotation.x, leftArm.Rotation.y, leftArm.Rotation.z, leftArm.Rotation.w,

                    //Left Hand Data
                    leftHand.Confidence, leftHand.GrabStrength, leftHand.GrabAngle, leftHand.PinchStrength, leftHand.PinchDistance, leftHand.PalmWidth, leftHand.IsLeft, leftHand.TimeVisible, leftHand.PalmPosition.x, leftHand.PalmPosition.y, leftHand.PalmPosition.z, leftHand.StabilizedPalmPosition.x, leftHand.StabilizedPalmPosition.y, leftHand.StabilizedPalmPosition.z, leftHand.PalmVelocity.x, leftHand.PalmVelocity.y, leftHand.PalmVelocity.z, leftHand.PalmNormal.x, leftHand.PalmNormal.y, leftHand.PalmNormal.z, leftHand.Rotation.x, leftHand.Rotation.y, leftHand.Rotation.z, leftHand.Rotation.w, leftHand.Direction.x, leftHand.Direction.y, leftHand.Direction.z, leftHand.WristPosition.x, leftHand.WristPosition.y, leftHand.WristPosition.z,

                    //Right Hand Bone Data
                    rightThumbMeta.PrevJoint.x, rightThumbMeta.PrevJoint.y, rightThumbMeta.PrevJoint.z, rightThumbMeta.NextJoint.x, rightThumbMeta.NextJoint.y, rightThumbMeta.NextJoint.z, rightThumbMeta.Center.x, rightThumbMeta.Center.y, rightThumbMeta.Center.z, rightThumbMeta.Direction.x, rightThumbMeta.Direction.y, rightThumbMeta.Direction.z, rightThumbMeta.Length, rightThumbMeta.Width, 0, rightThumbMeta.Rotation.x, rightThumbMeta.Rotation.y, rightThumbMeta.Rotation.z, rightThumbMeta.Rotation.w,
                    rightThumbProx.PrevJoint.x, rightThumbProx.PrevJoint.y, rightThumbProx.PrevJoint.z, rightThumbProx.NextJoint.x, rightThumbProx.NextJoint.y, rightThumbProx.NextJoint.z, rightThumbProx.Center.x, rightThumbProx.Center.y, rightThumbProx.Center.z, rightThumbProx.Direction.x, rightThumbProx.Direction.y, rightThumbProx.Direction.z, rightThumbProx.Length, rightThumbProx.Width, 1, rightThumbProx.Rotation.x, rightThumbProx.Rotation.y, rightThumbProx.Rotation.z, rightThumbProx.Rotation.w,
                    rightThumbInter.PrevJoint.x, rightThumbInter.PrevJoint.y, rightThumbInter.PrevJoint.z, rightThumbInter.NextJoint.x, rightThumbInter.NextJoint.y, rightThumbInter.NextJoint.z, rightThumbInter.Center.x, rightThumbInter.Center.y, rightThumbInter.Center.z, rightThumbInter.Direction.x, rightThumbInter.Direction.y, rightThumbInter.Direction.z, rightThumbInter.Length, rightThumbInter.Width, 2, rightThumbInter.Rotation.x, rightThumbInter.Rotation.y, rightThumbInter.Rotation.z, rightThumbInter.Rotation.w,
                    rightThumbDist.PrevJoint.x, rightThumbDist.PrevJoint.y, rightThumbDist.PrevJoint.z, rightThumbDist.NextJoint.x, rightThumbDist.NextJoint.y, rightThumbDist.NextJoint.z, rightThumbDist.Center.x, rightThumbDist.Center.y, rightThumbDist.Center.z, rightThumbDist.Direction.x, rightThumbDist.Direction.y, rightThumbDist.Direction.z, rightThumbDist.Length, rightThumbDist.Width, 3, rightThumbDist.Rotation.x, rightThumbDist.Rotation.y, rightThumbDist.Rotation.z, rightThumbDist.Rotation.w,

                    rightIndexMeta.PrevJoint.x, rightIndexMeta.PrevJoint.y, rightIndexMeta.PrevJoint.z, rightIndexMeta.NextJoint.x, rightIndexMeta.NextJoint.y, rightIndexMeta.NextJoint.z, rightIndexMeta.Center.x, rightIndexMeta.Center.y, rightIndexMeta.Center.z, rightIndexMeta.Direction.x, rightIndexMeta.Direction.y, rightIndexMeta.Direction.z, rightIndexMeta.Length, rightIndexMeta.Width, 0, rightIndexMeta.Rotation.x, rightIndexMeta.Rotation.y, rightIndexMeta.Rotation.z, rightIndexMeta.Rotation.w,
                    rightIndexProx.PrevJoint.x, rightIndexProx.PrevJoint.y, rightIndexProx.PrevJoint.z, rightIndexProx.NextJoint.x, rightIndexProx.NextJoint.y, rightIndexProx.NextJoint.z, rightIndexProx.Center.x, rightIndexProx.Center.y, rightIndexProx.Center.z, rightIndexProx.Direction.x, rightIndexProx.Direction.y, rightIndexProx.Direction.z, rightIndexProx.Length, rightIndexProx.Width, 1, rightIndexProx.Rotation.x, rightIndexProx.Rotation.y, rightIndexProx.Rotation.z, rightIndexProx.Rotation.w,
                    rightIndexInter.PrevJoint.x, rightIndexInter.PrevJoint.y, rightIndexInter.PrevJoint.z, rightIndexInter.NextJoint.x, rightIndexInter.NextJoint.y, rightIndexInter.NextJoint.z, rightIndexInter.Center.x, rightIndexInter.Center.y, rightIndexInter.Center.z, rightIndexInter.Direction.x, rightIndexInter.Direction.y, rightIndexInter.Direction.z, rightIndexInter.Length, rightIndexInter.Width, 2, rightIndexInter.Rotation.x, rightIndexInter.Rotation.y, rightIndexInter.Rotation.z, rightIndexInter.Rotation.w,
                    rightIndexDist.PrevJoint.x, rightIndexDist.PrevJoint.y, rightIndexDist.PrevJoint.z, rightIndexDist.NextJoint.x, rightIndexDist.NextJoint.y, rightIndexDist.NextJoint.z, rightIndexDist.Center.x, rightIndexDist.Center.y, rightIndexDist.Center.z, rightIndexDist.Direction.x, rightIndexDist.Direction.y, rightIndexDist.Direction.z, rightIndexDist.Length, rightIndexDist.Width, 3, rightIndexDist.Rotation.x, rightIndexDist.Rotation.y, rightIndexDist.Rotation.z, rightIndexDist.Rotation.w,

                    rightMiddleMeta.PrevJoint.x, rightMiddleMeta.PrevJoint.y, rightMiddleMeta.PrevJoint.z, rightMiddleMeta.NextJoint.x, rightMiddleMeta.NextJoint.y, rightMiddleMeta.NextJoint.z, rightMiddleMeta.Center.x, rightMiddleMeta.Center.y, rightMiddleMeta.Center.z, rightMiddleMeta.Direction.x, rightMiddleMeta.Direction.y, rightMiddleMeta.Direction.z, rightMiddleMeta.Length, rightMiddleMeta.Width, 0, rightMiddleMeta.Rotation.x, rightMiddleMeta.Rotation.y, rightMiddleMeta.Rotation.z, rightMiddleMeta.Rotation.w,
                    rightMiddleProx.PrevJoint.x, rightMiddleProx.PrevJoint.y, rightMiddleProx.PrevJoint.z, rightMiddleProx.NextJoint.x, rightMiddleProx.NextJoint.y, rightMiddleProx.NextJoint.z, rightMiddleProx.Center.x, rightMiddleProx.Center.y, rightMiddleProx.Center.z, rightMiddleProx.Direction.x, rightMiddleProx.Direction.y, rightMiddleProx.Direction.z, rightMiddleProx.Length, rightMiddleProx.Width, 1, rightMiddleProx.Rotation.x, rightMiddleProx.Rotation.y, rightMiddleProx.Rotation.z, rightMiddleProx.Rotation.w,
                    rightMiddleInter.PrevJoint.x, rightMiddleInter.PrevJoint.y, rightMiddleInter.PrevJoint.z, rightMiddleInter.NextJoint.x, rightMiddleInter.NextJoint.y, rightMiddleInter.NextJoint.z, rightMiddleInter.Center.x, rightMiddleInter.Center.y, rightMiddleInter.Center.z, rightMiddleInter.Direction.x, rightMiddleInter.Direction.y, rightMiddleInter.Direction.z, rightMiddleInter.Length, rightMiddleInter.Width, 2, rightMiddleInter.Rotation.x, rightMiddleInter.Rotation.y, rightMiddleInter.Rotation.z, rightMiddleInter.Rotation.w,
                    rightMiddleDist.PrevJoint.x, rightMiddleDist.PrevJoint.y, rightMiddleDist.PrevJoint.z, rightMiddleDist.NextJoint.x, rightMiddleDist.NextJoint.y, rightMiddleDist.NextJoint.z, rightMiddleDist.Center.x, rightMiddleDist.Center.y, rightMiddleDist.Center.z, rightMiddleDist.Direction.x, rightMiddleDist.Direction.y, rightMiddleDist.Direction.z, rightMiddleDist.Length, rightMiddleDist.Width, 3, rightMiddleDist.Rotation.x, rightMiddleDist.Rotation.y, rightMiddleDist.Rotation.z, rightMiddleDist.Rotation.w,

                    rightRingMeta.PrevJoint.x, rightRingMeta.PrevJoint.y, rightRingMeta.PrevJoint.z, rightRingMeta.NextJoint.x, rightRingMeta.NextJoint.y, rightRingMeta.NextJoint.z, rightRingMeta.Center.x, rightRingMeta.Center.y, rightRingMeta.Center.z, rightRingMeta.Direction.x, rightRingMeta.Direction.y, rightRingMeta.Direction.z, rightRingMeta.Length, rightRingMeta.Width, 0, rightRingMeta.Rotation.x, rightRingMeta.Rotation.y, rightRingMeta.Rotation.z, rightRingMeta.Rotation.w,
                    rightRingProx.PrevJoint.x, rightRingProx.PrevJoint.y, rightRingProx.PrevJoint.z, rightRingProx.NextJoint.x, rightRingProx.NextJoint.y, rightRingProx.NextJoint.z, rightRingProx.Center.x, rightRingProx.Center.y, rightRingProx.Center.z, rightRingProx.Direction.x, rightRingProx.Direction.y, rightRingProx.Direction.z, rightRingProx.Length, rightRingProx.Width, 1, rightRingProx.Rotation.x, rightRingProx.Rotation.y, rightRingProx.Rotation.z, rightRingProx.Rotation.w,
                    rightRingInter.PrevJoint.x, rightRingInter.PrevJoint.y, rightRingInter.PrevJoint.z, rightRingInter.NextJoint.x, rightRingInter.NextJoint.y, rightRingInter.NextJoint.z, rightRingInter.Center.x, rightRingInter.Center.y, rightRingInter.Center.z, rightRingInter.Direction.x, rightRingInter.Direction.y, rightRingInter.Direction.z, rightRingInter.Length, rightRingInter.Width, 2, rightRingInter.Rotation.x, rightRingInter.Rotation.y, rightRingInter.Rotation.z, rightRingInter.Rotation.w,
                    rightRingDist.PrevJoint.x, rightRingDist.PrevJoint.y, rightRingDist.PrevJoint.z, rightRingDist.NextJoint.x, rightRingDist.NextJoint.y, rightRingDist.NextJoint.z, rightRingDist.Center.x, rightRingDist.Center.y, rightRingDist.Center.z, rightRingDist.Direction.x, rightRingDist.Direction.y, rightRingDist.Direction.z, rightRingDist.Length, rightRingDist.Width, 3, rightRingDist.Rotation.x, rightRingDist.Rotation.y, rightRingDist.Rotation.z, rightRingDist.Rotation.w,

                    rightPinkyMeta.PrevJoint.x, rightPinkyMeta.PrevJoint.y, rightPinkyMeta.PrevJoint.z, rightPinkyMeta.NextJoint.x, rightPinkyMeta.NextJoint.y, rightPinkyMeta.NextJoint.z, rightPinkyMeta.Center.x, rightPinkyMeta.Center.y, rightPinkyMeta.Center.z, rightPinkyMeta.Direction.x, rightPinkyMeta.Direction.y, rightPinkyMeta.Direction.z, rightPinkyMeta.Length, rightPinkyMeta.Width, 0, rightPinkyMeta.Rotation.x, rightPinkyMeta.Rotation.y, rightPinkyMeta.Rotation.z, rightPinkyMeta.Rotation.w,
                    rightPinkyProx.PrevJoint.x, rightPinkyProx.PrevJoint.y, rightPinkyProx.PrevJoint.z, rightPinkyProx.NextJoint.x, rightPinkyProx.NextJoint.y, rightPinkyProx.NextJoint.z, rightPinkyProx.Center.x, rightPinkyProx.Center.y, rightPinkyProx.Center.z, rightPinkyProx.Direction.x, rightPinkyProx.Direction.y, rightPinkyProx.Direction.z, rightPinkyProx.Length, rightPinkyProx.Width, 1, rightPinkyProx.Rotation.x, rightPinkyProx.Rotation.y, rightPinkyProx.Rotation.z, rightPinkyProx.Rotation.w,
                    rightPinkyInter.PrevJoint.x, rightPinkyInter.PrevJoint.y, rightPinkyInter.PrevJoint.z, rightPinkyInter.NextJoint.x, rightPinkyInter.NextJoint.y, rightPinkyInter.NextJoint.z, rightPinkyInter.Center.x, rightPinkyInter.Center.y, rightPinkyInter.Center.z, rightPinkyInter.Direction.x, rightPinkyInter.Direction.y, rightPinkyInter.Direction.z, rightPinkyInter.Length, rightPinkyInter.Width, 2, rightPinkyInter.Rotation.x, rightPinkyInter.Rotation.y, rightPinkyInter.Rotation.z, rightPinkyInter.Rotation.w,
                    rightPinkyDist.PrevJoint.x, rightPinkyDist.PrevJoint.y, rightPinkyDist.PrevJoint.z, rightPinkyDist.NextJoint.x, rightPinkyDist.NextJoint.y, rightPinkyDist.NextJoint.z, rightPinkyDist.Center.x, rightPinkyDist.Center.y, rightPinkyDist.Center.z, rightPinkyDist.Direction.x, rightPinkyDist.Direction.y, rightPinkyDist.Direction.z, rightPinkyDist.Length, rightPinkyDist.Width, 3, rightPinkyDist.Rotation.x, rightPinkyDist.Rotation.y, rightPinkyDist.Rotation.z, rightPinkyDist.Rotation.w,

                    //Right Hand Finger Data
                    rightHand.Id,
                    rightThumb.Id, rightThumb.TimeVisible, rightThumb.TipPosition.x, rightThumb.TipPosition.y, rightThumb.TipPosition.z, rightThumb.Direction.x, rightThumb.Direction.y, rightThumb.Direction.z, rightThumb.Width, rightThumb.Length, rightThumb.IsExtended, 0,
                    rightIndex.Id, rightIndex.TimeVisible, rightIndex.TipPosition.x, rightIndex.TipPosition.y, rightIndex.TipPosition.z, rightIndex.Direction.x, rightIndex.Direction.y, rightIndex.Direction.z, rightIndex.Width, rightIndex.Length, rightIndex.IsExtended, 0,
                    rightMiddle.Id, rightMiddle.TimeVisible, rightMiddle.TipPosition.x, rightMiddle.TipPosition.y, rightMiddle.TipPosition.z, rightMiddle.Direction.x, rightMiddle.Direction.y, rightMiddle.Direction.z, rightMiddle.Width, rightMiddle.Length, rightMiddle.IsExtended, 0,
                    rightRing.Id, rightRing.TimeVisible, rightRing.TipPosition.x, rightRing.TipPosition.y, rightRing.TipPosition.z, rightRing.Direction.x, rightRing.Direction.y, rightRing.Direction.z, rightRing.Width, rightRing.Length, rightRing.IsExtended, 0,
                    rightPinky.Id, rightPinky.TimeVisible, rightPinky.TipPosition.x, rightPinky.TipPosition.y, rightPinky.TipPosition.z, rightPinky.Direction.x, rightPinky.Direction.y, rightPinky.Direction.z, rightPinky.Width, rightPinky.Length, rightPinky.IsExtended, 0,

                    //Right Arm Data
                    rightArm.ElbowPosition.x, rightArm.ElbowPosition.y, rightArm.ElbowPosition.z, rightArm.WristPosition.x, rightArm.WristPosition.y, rightArm.WristPosition.z, rightArm.Center.x, rightArm.Center.y, rightArm.Center.z, rightArm.Direction.x, rightArm.Direction.y, rightArm.Direction.z, rightArm.Length, rightArm.Width, rightArm.Rotation.x, rightArm.Rotation.y, rightArm.Rotation.z, rightArm.Rotation.w,

                    //Right Hand Data
                    rightHand.Confidence, rightHand.GrabStrength, rightHand.GrabAngle, rightHand.PinchStrength, rightHand.PinchDistance, rightHand.PalmWidth, rightHand.IsLeft, rightHand.TimeVisible, rightHand.PalmPosition.x, rightHand.PalmPosition.y, rightHand.PalmPosition.z, rightHand.StabilizedPalmPosition.x, rightHand.StabilizedPalmPosition.y, rightHand.StabilizedPalmPosition.z, rightHand.PalmVelocity.x, rightHand.PalmVelocity.y, rightHand.PalmVelocity.z, rightHand.PalmNormal.x, rightHand.PalmNormal.y, rightHand.PalmNormal.z, rightHand.Rotation.x, rightHand.Rotation.y, rightHand.Rotation.z, rightHand.Rotation.w, rightHand.Direction.x, rightHand.Direction.y, rightHand.Direction.z, rightHand.WristPosition.x, rightHand.WristPosition.y, rightHand.WristPosition.z,

                    //Frame Data
                    frame.Timestamp, frame.CurrentFramesPerSecond);
            }

            if (frame.Hands.Count == 1)
            {
                if (frame.Hands[0].IsLeft)
                {
                    leftHand = frame.Hands[0];
                    leftArm = leftHand.Arm;

                    leftThumb = frame.Hands[0].Fingers[0];
                    leftIndex = frame.Hands[0].Fingers[1];
                    leftMiddle = frame.Hands[0].Fingers[2];
                    leftRing = frame.Hands[0].Fingers[3];
                    leftPinky = frame.Hands[0].Fingers[4];

                    leftThumbMeta = leftThumb.bones[0];
                    leftThumbProx = leftThumb.bones[1];
                    leftThumbInter = leftThumb.bones[2];
                    leftThumbDist = leftThumb.bones[3];

                    leftIndexMeta = leftIndex.bones[0];
                    leftIndexProx = leftIndex.bones[1];
                    leftIndexInter = leftIndex.bones[2];
                    leftIndexDist = leftIndex.bones[3];

                    leftMiddleMeta = leftMiddle.bones[0];
                    leftMiddleProx = leftMiddle.bones[1];
                    leftMiddleInter = leftMiddle.bones[2];
                    leftMiddleDist = leftMiddle.bones[3];

                    leftRingMeta = leftRing.bones[0];
                    leftRingProx = leftRing.bones[1];
                    leftRingInter = leftRing.bones[2];
                    leftRingDist = leftRing.bones[3];

                    leftPinkyMeta = leftPinky.bones[0];
                    leftPinkyProx = leftPinky.bones[1];
                    leftPinkyInter = leftPinky.bones[2];
                    leftPinkyDist = leftPinky.bones[3];

                    leapData = new OscMessage(address, index, handsCount,
                    //Left Hand Bone Data
                    leftThumbMeta.PrevJoint.x, leftThumbMeta.PrevJoint.y, leftThumbMeta.PrevJoint.z, leftThumbMeta.NextJoint.x, leftThumbMeta.NextJoint.y, leftThumbMeta.NextJoint.z, leftThumbMeta.Center.x, leftThumbMeta.Center.y, leftThumbMeta.Center.z, leftThumbMeta.Direction.x, leftThumbMeta.Direction.y, leftThumbMeta.Direction.z, leftThumbMeta.Length, leftThumbMeta.Width, 0, leftThumbMeta.Rotation.x, leftThumbMeta.Rotation.y, leftThumbMeta.Rotation.z, leftThumbMeta.Rotation.w,
                    leftThumbProx.PrevJoint.x, leftThumbProx.PrevJoint.y, leftThumbProx.PrevJoint.z, leftThumbProx.NextJoint.x, leftThumbProx.NextJoint.y, leftThumbProx.NextJoint.z, leftThumbProx.Center.x, leftThumbProx.Center.y, leftThumbProx.Center.z, leftThumbProx.Direction.x, leftThumbProx.Direction.y, leftThumbProx.Direction.z, leftThumbProx.Length, leftThumbProx.Width, 1, leftThumbProx.Rotation.x, leftThumbProx.Rotation.y, leftThumbProx.Rotation.z, leftThumbProx.Rotation.w,
                    leftThumbInter.PrevJoint.x, leftThumbInter.PrevJoint.y, leftThumbInter.PrevJoint.z, leftThumbInter.NextJoint.x, leftThumbInter.NextJoint.y, leftThumbInter.NextJoint.z, leftThumbInter.Center.x, leftThumbInter.Center.y, leftThumbInter.Center.z, leftThumbInter.Direction.x, leftThumbInter.Direction.y, leftThumbInter.Direction.z, leftThumbInter.Length, leftThumbInter.Width, 2, leftThumbInter.Rotation.x, leftThumbInter.Rotation.y, leftThumbInter.Rotation.z, leftThumbInter.Rotation.w,
                    leftThumbDist.PrevJoint.x, leftThumbDist.PrevJoint.y, leftThumbDist.PrevJoint.z, leftThumbDist.NextJoint.x, leftThumbDist.NextJoint.y, leftThumbDist.NextJoint.z, leftThumbDist.Center.x, leftThumbDist.Center.y, leftThumbDist.Center.z, leftThumbDist.Direction.x, leftThumbDist.Direction.y, leftThumbDist.Direction.z, leftThumbDist.Length, leftThumbDist.Width, 3, leftThumbDist.Rotation.x, leftThumbDist.Rotation.y, leftThumbDist.Rotation.z, leftThumbDist.Rotation.w,

                    leftIndexMeta.PrevJoint.x, leftIndexMeta.PrevJoint.y, leftIndexMeta.PrevJoint.z, leftIndexMeta.NextJoint.x, leftIndexMeta.NextJoint.y, leftIndexMeta.NextJoint.z, leftIndexMeta.Center.x, leftIndexMeta.Center.y, leftIndexMeta.Center.z, leftIndexMeta.Direction.x, leftIndexMeta.Direction.y, leftIndexMeta.Direction.z, leftIndexMeta.Length, leftIndexMeta.Width, 0, leftIndexMeta.Rotation.x, leftIndexMeta.Rotation.y, leftIndexMeta.Rotation.z, leftIndexMeta.Rotation.w,
                    leftIndexProx.PrevJoint.x, leftIndexProx.PrevJoint.y, leftIndexProx.PrevJoint.z, leftIndexProx.NextJoint.x, leftIndexProx.NextJoint.y, leftIndexProx.NextJoint.z, leftIndexProx.Center.x, leftIndexProx.Center.y, leftIndexProx.Center.z, leftIndexProx.Direction.x, leftIndexProx.Direction.y, leftIndexProx.Direction.z, leftIndexProx.Length, leftIndexProx.Width, 1, leftIndexProx.Rotation.x, leftIndexProx.Rotation.y, leftIndexProx.Rotation.z, leftIndexProx.Rotation.w,
                    leftIndexInter.PrevJoint.x, leftIndexInter.PrevJoint.y, leftIndexInter.PrevJoint.z, leftIndexInter.NextJoint.x, leftIndexInter.NextJoint.y, leftIndexInter.NextJoint.z, leftIndexInter.Center.x, leftIndexInter.Center.y, leftIndexInter.Center.z, leftIndexInter.Direction.x, leftIndexInter.Direction.y, leftIndexInter.Direction.z, leftIndexInter.Length, leftIndexInter.Width, 2, leftIndexInter.Rotation.x, leftIndexInter.Rotation.y, leftIndexInter.Rotation.z, leftIndexInter.Rotation.w,
                    leftIndexDist.PrevJoint.x, leftIndexDist.PrevJoint.y, leftIndexDist.PrevJoint.z, leftIndexDist.NextJoint.x, leftIndexDist.NextJoint.y, leftIndexDist.NextJoint.z, leftIndexDist.Center.x, leftIndexDist.Center.y, leftIndexDist.Center.z, leftIndexDist.Direction.x, leftIndexDist.Direction.y, leftIndexDist.Direction.z, leftIndexDist.Length, leftIndexDist.Width, 3, leftIndexDist.Rotation.x, leftIndexDist.Rotation.y, leftIndexDist.Rotation.z, leftIndexDist.Rotation.w,

                    leftMiddleMeta.PrevJoint.x, leftMiddleMeta.PrevJoint.y, leftMiddleMeta.PrevJoint.z, leftMiddleMeta.NextJoint.x, leftMiddleMeta.NextJoint.y, leftMiddleMeta.NextJoint.z, leftMiddleMeta.Center.x, leftMiddleMeta.Center.y, leftMiddleMeta.Center.z, leftMiddleMeta.Direction.x, leftMiddleMeta.Direction.y, leftMiddleMeta.Direction.z, leftMiddleMeta.Length, leftMiddleMeta.Width, 0, leftMiddleMeta.Rotation.x, leftMiddleMeta.Rotation.y, leftMiddleMeta.Rotation.z, leftMiddleMeta.Rotation.w,
                    leftMiddleProx.PrevJoint.x, leftMiddleProx.PrevJoint.y, leftMiddleProx.PrevJoint.z, leftMiddleProx.NextJoint.x, leftMiddleProx.NextJoint.y, leftMiddleProx.NextJoint.z, leftMiddleProx.Center.x, leftMiddleProx.Center.y, leftMiddleProx.Center.z, leftMiddleProx.Direction.x, leftMiddleProx.Direction.y, leftMiddleProx.Direction.z, leftMiddleProx.Length, leftMiddleProx.Width, 1, leftMiddleProx.Rotation.x, leftMiddleProx.Rotation.y, leftMiddleProx.Rotation.z, leftMiddleProx.Rotation.w,
                    leftMiddleInter.PrevJoint.x, leftMiddleInter.PrevJoint.y, leftMiddleInter.PrevJoint.z, leftMiddleInter.NextJoint.x, leftMiddleInter.NextJoint.y, leftMiddleInter.NextJoint.z, leftMiddleInter.Center.x, leftMiddleInter.Center.y, leftMiddleInter.Center.z, leftMiddleInter.Direction.x, leftMiddleInter.Direction.y, leftMiddleInter.Direction.z, leftMiddleInter.Length, leftMiddleInter.Width, 2, leftMiddleInter.Rotation.x, leftMiddleInter.Rotation.y, leftMiddleInter.Rotation.z, leftMiddleInter.Rotation.w,
                    leftMiddleDist.PrevJoint.x, leftMiddleDist.PrevJoint.y, leftMiddleDist.PrevJoint.z, leftMiddleDist.NextJoint.x, leftMiddleDist.NextJoint.y, leftMiddleDist.NextJoint.z, leftMiddleDist.Center.x, leftMiddleDist.Center.y, leftMiddleDist.Center.z, leftMiddleDist.Direction.x, leftMiddleDist.Direction.y, leftMiddleDist.Direction.z, leftMiddleDist.Length, leftMiddleDist.Width, 3, leftMiddleDist.Rotation.x, leftMiddleDist.Rotation.y, leftMiddleDist.Rotation.z, leftMiddleDist.Rotation.w,

                    leftRingMeta.PrevJoint.x, leftRingMeta.PrevJoint.y, leftRingMeta.PrevJoint.z, leftRingMeta.NextJoint.x, leftRingMeta.NextJoint.y, leftRingMeta.NextJoint.z, leftRingMeta.Center.x, leftRingMeta.Center.y, leftRingMeta.Center.z, leftRingMeta.Direction.x, leftRingMeta.Direction.y, leftRingMeta.Direction.z, leftRingMeta.Length, leftRingMeta.Width, 0, leftRingMeta.Rotation.x, leftRingMeta.Rotation.y, leftRingMeta.Rotation.z, leftRingMeta.Rotation.w,
                    leftRingProx.PrevJoint.x, leftRingProx.PrevJoint.y, leftRingProx.PrevJoint.z, leftRingProx.NextJoint.x, leftRingProx.NextJoint.y, leftRingProx.NextJoint.z, leftRingProx.Center.x, leftRingProx.Center.y, leftRingProx.Center.z, leftRingProx.Direction.x, leftRingProx.Direction.y, leftRingProx.Direction.z, leftRingProx.Length, leftRingProx.Width, 1, leftRingProx.Rotation.x, leftRingProx.Rotation.y, leftRingProx.Rotation.z, leftRingProx.Rotation.w,
                    leftRingInter.PrevJoint.x, leftRingInter.PrevJoint.y, leftRingInter.PrevJoint.z, leftRingInter.NextJoint.x, leftRingInter.NextJoint.y, leftRingInter.NextJoint.z, leftRingInter.Center.x, leftRingInter.Center.y, leftRingInter.Center.z, leftRingInter.Direction.x, leftRingInter.Direction.y, leftRingInter.Direction.z, leftRingInter.Length, leftRingInter.Width, 2, leftRingInter.Rotation.x, leftRingInter.Rotation.y, leftRingInter.Rotation.z, leftRingInter.Rotation.w,
                    leftRingDist.PrevJoint.x, leftRingDist.PrevJoint.y, leftRingDist.PrevJoint.z, leftRingDist.NextJoint.x, leftRingDist.NextJoint.y, leftRingDist.NextJoint.z, leftRingDist.Center.x, leftRingDist.Center.y, leftRingDist.Center.z, leftRingDist.Direction.x, leftRingDist.Direction.y, leftRingDist.Direction.z, leftRingDist.Length, leftRingDist.Width, 3, leftRingDist.Rotation.x, leftRingDist.Rotation.y, leftRingDist.Rotation.z, leftRingDist.Rotation.w,

                    leftPinkyMeta.PrevJoint.x, leftPinkyMeta.PrevJoint.y, leftPinkyMeta.PrevJoint.z, leftPinkyMeta.NextJoint.x, leftPinkyMeta.NextJoint.y, leftPinkyMeta.NextJoint.z, leftPinkyMeta.Center.x, leftPinkyMeta.Center.y, leftPinkyMeta.Center.z, leftPinkyMeta.Direction.x, leftPinkyMeta.Direction.y, leftPinkyMeta.Direction.z, leftPinkyMeta.Length, leftPinkyMeta.Width, 0, leftPinkyMeta.Rotation.x, leftPinkyMeta.Rotation.y, leftPinkyMeta.Rotation.z, leftPinkyMeta.Rotation.w,
                    leftPinkyProx.PrevJoint.x, leftPinkyProx.PrevJoint.y, leftPinkyProx.PrevJoint.z, leftPinkyProx.NextJoint.x, leftPinkyProx.NextJoint.y, leftPinkyProx.NextJoint.z, leftPinkyProx.Center.x, leftPinkyProx.Center.y, leftPinkyProx.Center.z, leftPinkyProx.Direction.x, leftPinkyProx.Direction.y, leftPinkyProx.Direction.z, leftPinkyProx.Length, leftPinkyProx.Width, 1, leftPinkyProx.Rotation.x, leftPinkyProx.Rotation.y, leftPinkyProx.Rotation.z, leftPinkyProx.Rotation.w,
                    leftPinkyInter.PrevJoint.x, leftPinkyInter.PrevJoint.y, leftPinkyInter.PrevJoint.z, leftPinkyInter.NextJoint.x, leftPinkyInter.NextJoint.y, leftPinkyInter.NextJoint.z, leftPinkyInter.Center.x, leftPinkyInter.Center.y, leftPinkyInter.Center.z, leftPinkyInter.Direction.x, leftPinkyInter.Direction.y, leftPinkyInter.Direction.z, leftPinkyInter.Length, leftPinkyInter.Width, 2, leftPinkyInter.Rotation.x, leftPinkyInter.Rotation.y, leftPinkyInter.Rotation.z, leftPinkyInter.Rotation.w,
                    leftPinkyDist.PrevJoint.x, leftPinkyDist.PrevJoint.y, leftPinkyDist.PrevJoint.z, leftPinkyDist.NextJoint.x, leftPinkyDist.NextJoint.y, leftPinkyDist.NextJoint.z, leftPinkyDist.Center.x, leftPinkyDist.Center.y, leftPinkyDist.Center.z, leftPinkyDist.Direction.x, leftPinkyDist.Direction.y, leftPinkyDist.Direction.z, leftPinkyDist.Length, leftPinkyDist.Width, 3, leftPinkyDist.Rotation.x, leftPinkyDist.Rotation.y, leftPinkyDist.Rotation.z, leftPinkyDist.Rotation.w,

                    //Left Hand Finger Data
                    frame.Id, leftHand.Id,
                    leftThumb.Id, leftThumb.TimeVisible, leftThumb.TipPosition.x, leftThumb.TipPosition.y, leftThumb.TipPosition.z, leftThumb.Direction.x, leftThumb.Direction.y, leftThumb.Direction.z, leftThumb.Width, leftThumb.Length, leftThumb.IsExtended, 0,
                    leftIndex.Id, leftIndex.TimeVisible, leftIndex.TipPosition.x, leftIndex.TipPosition.y, leftIndex.TipPosition.z, leftIndex.Direction.x, leftIndex.Direction.y, leftIndex.Direction.z, leftIndex.Width, leftIndex.Length, leftIndex.IsExtended, 0,
                    leftMiddle.Id, leftMiddle.TimeVisible, leftMiddle.TipPosition.x, leftMiddle.TipPosition.y, leftMiddle.TipPosition.z, leftMiddle.Direction.x, leftMiddle.Direction.y, leftMiddle.Direction.z, leftMiddle.Width, leftMiddle.Length, leftMiddle.IsExtended, 0,
                    leftRing.Id, leftRing.TimeVisible, leftRing.TipPosition.x, leftRing.TipPosition.y, leftRing.TipPosition.z, leftRing.Direction.x, leftRing.Direction.y, leftRing.Direction.z, leftRing.Width, leftRing.Length, leftRing.IsExtended, 0,
                    leftPinky.Id, leftPinky.TimeVisible, leftPinky.TipPosition.x, leftPinky.TipPosition.y, leftPinky.TipPosition.z, leftPinky.Direction.x, leftPinky.Direction.y, leftPinky.Direction.z, leftPinky.Width, leftPinky.Length, leftPinky.IsExtended, 0,

                    //Left Arm Data
                    leftArm.ElbowPosition.x, leftArm.ElbowPosition.y, leftArm.ElbowPosition.z, leftArm.WristPosition.x, leftArm.WristPosition.y, leftArm.WristPosition.z, leftArm.Center.x, leftArm.Center.y, leftArm.Center.z, leftArm.Direction.x, leftArm.Direction.y, leftArm.Direction.z, leftArm.Length, leftArm.Width, leftArm.Rotation.x, leftArm.Rotation.y, leftArm.Rotation.z, leftArm.Rotation.w,

                    //Left Hand Data
                    leftHand.Confidence, leftHand.GrabStrength, leftHand.GrabAngle, leftHand.PinchStrength, leftHand.PinchDistance, leftHand.PalmWidth, leftHand.IsLeft, leftHand.TimeVisible, leftHand.PalmPosition.x, leftHand.PalmPosition.y, leftHand.PalmPosition.z, leftHand.StabilizedPalmPosition.x, leftHand.StabilizedPalmPosition.y, leftHand.StabilizedPalmPosition.z, leftHand.PalmVelocity.x, leftHand.PalmVelocity.y, leftHand.PalmVelocity.z, leftHand.PalmNormal.x, leftHand.PalmNormal.y, leftHand.PalmNormal.z, leftHand.Rotation.x, leftHand.Rotation.y, leftHand.Rotation.z, leftHand.Rotation.w, leftHand.Direction.x, leftHand.Direction.y, leftHand.Direction.z, leftHand.WristPosition.x, leftHand.WristPosition.y, leftHand.WristPosition.z,

                    //Frame Data
                    frame.Timestamp, frame.CurrentFramesPerSecond);

                    //Console.WriteLine("Left hand confidence is " + leftHand.Confidence);
                }
                else
                {
                    rightHand = frame.Hands[0];
                    rightArm = rightHand.Arm;

                    rightThumb = frame.Hands[0].Fingers[0];
                    rightIndex = frame.Hands[0].Fingers[1];
                    rightMiddle = frame.Hands[0].Fingers[2];
                    rightRing = frame.Hands[0].Fingers[3];
                    rightPinky = frame.Hands[0].Fingers[4];

                    rightThumbMeta = rightThumb.bones[0];
                    rightThumbProx = rightThumb.bones[1];
                    rightThumbInter = rightThumb.bones[2];
                    rightThumbDist = rightThumb.bones[3];

                    rightIndexMeta = rightIndex.bones[0];
                    rightIndexProx = rightIndex.bones[1];
                    rightIndexInter = rightIndex.bones[2];
                    rightIndexDist = rightIndex.bones[3];

                    rightMiddleMeta = rightMiddle.bones[0];
                    rightMiddleProx = rightMiddle.bones[1];
                    rightMiddleInter = rightMiddle.bones[2];
                    rightMiddleDist = rightMiddle.bones[3];

                    rightRingMeta = rightRing.bones[0];
                    rightRingProx = rightRing.bones[1];
                    rightRingInter = rightRing.bones[2];
                    rightRingDist = rightRing.bones[3];

                    rightPinkyMeta = rightPinky.bones[0];
                    rightPinkyProx = rightPinky.bones[1];
                    rightPinkyInter = rightPinky.bones[2];
                    rightPinkyDist = rightPinky.bones[3];

                    leapData = new OscMessage(address, index, handsCount,
                    //Right Hand Bone Data
                    rightThumbMeta.PrevJoint.x, rightThumbMeta.PrevJoint.y, rightThumbMeta.PrevJoint.z, rightThumbMeta.NextJoint.x, rightThumbMeta.NextJoint.y, rightThumbMeta.NextJoint.z, rightThumbMeta.Center.x, rightThumbMeta.Center.y, rightThumbMeta.Center.z, rightThumbMeta.Direction.x, rightThumbMeta.Direction.y, rightThumbMeta.Direction.z, rightThumbMeta.Length, rightThumbMeta.Width, 0, rightThumbMeta.Rotation.x, rightThumbMeta.Rotation.y, rightThumbMeta.Rotation.z, rightThumbMeta.Rotation.w,
                    rightThumbProx.PrevJoint.x, rightThumbProx.PrevJoint.y, rightThumbProx.PrevJoint.z, rightThumbProx.NextJoint.x, rightThumbProx.NextJoint.y, rightThumbProx.NextJoint.z, rightThumbProx.Center.x, rightThumbProx.Center.y, rightThumbProx.Center.z, rightThumbProx.Direction.x, rightThumbProx.Direction.y, rightThumbProx.Direction.z, rightThumbProx.Length, rightThumbProx.Width, 1, rightThumbProx.Rotation.x, rightThumbProx.Rotation.y, rightThumbProx.Rotation.z, rightThumbProx.Rotation.w,
                    rightThumbInter.PrevJoint.x, rightThumbInter.PrevJoint.y, rightThumbInter.PrevJoint.z, rightThumbInter.NextJoint.x, rightThumbInter.NextJoint.y, rightThumbInter.NextJoint.z, rightThumbInter.Center.x, rightThumbInter.Center.y, rightThumbInter.Center.z, rightThumbInter.Direction.x, rightThumbInter.Direction.y, rightThumbInter.Direction.z, rightThumbInter.Length, rightThumbInter.Width, 2, rightThumbInter.Rotation.x, rightThumbInter.Rotation.y, rightThumbInter.Rotation.z, rightThumbInter.Rotation.w,
                    rightThumbDist.PrevJoint.x, rightThumbDist.PrevJoint.y, rightThumbDist.PrevJoint.z, rightThumbDist.NextJoint.x, rightThumbDist.NextJoint.y, rightThumbDist.NextJoint.z, rightThumbDist.Center.x, rightThumbDist.Center.y, rightThumbDist.Center.z, rightThumbDist.Direction.x, rightThumbDist.Direction.y, rightThumbDist.Direction.z, rightThumbDist.Length, rightThumbDist.Width, 3, rightThumbDist.Rotation.x, rightThumbDist.Rotation.y, rightThumbDist.Rotation.z, rightThumbDist.Rotation.w,

                    rightIndexMeta.PrevJoint.x, rightIndexMeta.PrevJoint.y, rightIndexMeta.PrevJoint.z, rightIndexMeta.NextJoint.x, rightIndexMeta.NextJoint.y, rightIndexMeta.NextJoint.z, rightIndexMeta.Center.x, rightIndexMeta.Center.y, rightIndexMeta.Center.z, rightIndexMeta.Direction.x, rightIndexMeta.Direction.y, rightIndexMeta.Direction.z, rightIndexMeta.Length, rightIndexMeta.Width, 0, rightIndexMeta.Rotation.x, rightIndexMeta.Rotation.y, rightIndexMeta.Rotation.z, rightIndexMeta.Rotation.w,
                    rightIndexProx.PrevJoint.x, rightIndexProx.PrevJoint.y, rightIndexProx.PrevJoint.z, rightIndexProx.NextJoint.x, rightIndexProx.NextJoint.y, rightIndexProx.NextJoint.z, rightIndexProx.Center.x, rightIndexProx.Center.y, rightIndexProx.Center.z, rightIndexProx.Direction.x, rightIndexProx.Direction.y, rightIndexProx.Direction.z, rightIndexProx.Length, rightIndexProx.Width, 1, rightIndexProx.Rotation.x, rightIndexProx.Rotation.y, rightIndexProx.Rotation.z, rightIndexProx.Rotation.w,
                    rightIndexInter.PrevJoint.x, rightIndexInter.PrevJoint.y, rightIndexInter.PrevJoint.z, rightIndexInter.NextJoint.x, rightIndexInter.NextJoint.y, rightIndexInter.NextJoint.z, rightIndexInter.Center.x, rightIndexInter.Center.y, rightIndexInter.Center.z, rightIndexInter.Direction.x, rightIndexInter.Direction.y, rightIndexInter.Direction.z, rightIndexInter.Length, rightIndexInter.Width, 2, rightIndexInter.Rotation.x, rightIndexInter.Rotation.y, rightIndexInter.Rotation.z, rightIndexInter.Rotation.w,
                    rightIndexDist.PrevJoint.x, rightIndexDist.PrevJoint.y, rightIndexDist.PrevJoint.z, rightIndexDist.NextJoint.x, rightIndexDist.NextJoint.y, rightIndexDist.NextJoint.z, rightIndexDist.Center.x, rightIndexDist.Center.y, rightIndexDist.Center.z, rightIndexDist.Direction.x, rightIndexDist.Direction.y, rightIndexDist.Direction.z, rightIndexDist.Length, rightIndexDist.Width, 3, rightIndexDist.Rotation.x, rightIndexDist.Rotation.y, rightIndexDist.Rotation.z, rightIndexDist.Rotation.w,

                    rightMiddleMeta.PrevJoint.x, rightMiddleMeta.PrevJoint.y, rightMiddleMeta.PrevJoint.z, rightMiddleMeta.NextJoint.x, rightMiddleMeta.NextJoint.y, rightMiddleMeta.NextJoint.z, rightMiddleMeta.Center.x, rightMiddleMeta.Center.y, rightMiddleMeta.Center.z, rightMiddleMeta.Direction.x, rightMiddleMeta.Direction.y, rightMiddleMeta.Direction.z, rightMiddleMeta.Length, rightMiddleMeta.Width, 0, rightMiddleMeta.Rotation.x, rightMiddleMeta.Rotation.y, rightMiddleMeta.Rotation.z, rightMiddleMeta.Rotation.w,
                    rightMiddleProx.PrevJoint.x, rightMiddleProx.PrevJoint.y, rightMiddleProx.PrevJoint.z, rightMiddleProx.NextJoint.x, rightMiddleProx.NextJoint.y, rightMiddleProx.NextJoint.z, rightMiddleProx.Center.x, rightMiddleProx.Center.y, rightMiddleProx.Center.z, rightMiddleProx.Direction.x, rightMiddleProx.Direction.y, rightMiddleProx.Direction.z, rightMiddleProx.Length, rightMiddleProx.Width, 1, rightMiddleProx.Rotation.x, rightMiddleProx.Rotation.y, rightMiddleProx.Rotation.z, rightMiddleProx.Rotation.w,
                    rightMiddleInter.PrevJoint.x, rightMiddleInter.PrevJoint.y, rightMiddleInter.PrevJoint.z, rightMiddleInter.NextJoint.x, rightMiddleInter.NextJoint.y, rightMiddleInter.NextJoint.z, rightMiddleInter.Center.x, rightMiddleInter.Center.y, rightMiddleInter.Center.z, rightMiddleInter.Direction.x, rightMiddleInter.Direction.y, rightMiddleInter.Direction.z, rightMiddleInter.Length, rightMiddleInter.Width, 2, rightMiddleInter.Rotation.x, rightMiddleInter.Rotation.y, rightMiddleInter.Rotation.z, rightMiddleInter.Rotation.w,
                    rightMiddleDist.PrevJoint.x, rightMiddleDist.PrevJoint.y, rightMiddleDist.PrevJoint.z, rightMiddleDist.NextJoint.x, rightMiddleDist.NextJoint.y, rightMiddleDist.NextJoint.z, rightMiddleDist.Center.x, rightMiddleDist.Center.y, rightMiddleDist.Center.z, rightMiddleDist.Direction.x, rightMiddleDist.Direction.y, rightMiddleDist.Direction.z, rightMiddleDist.Length, rightMiddleDist.Width, 3, rightMiddleDist.Rotation.x, rightMiddleDist.Rotation.y, rightMiddleDist.Rotation.z, rightMiddleDist.Rotation.w,

                    rightRingMeta.PrevJoint.x, rightRingMeta.PrevJoint.y, rightRingMeta.PrevJoint.z, rightRingMeta.NextJoint.x, rightRingMeta.NextJoint.y, rightRingMeta.NextJoint.z, rightRingMeta.Center.x, rightRingMeta.Center.y, rightRingMeta.Center.z, rightRingMeta.Direction.x, rightRingMeta.Direction.y, rightRingMeta.Direction.z, rightRingMeta.Length, rightRingMeta.Width, 0, rightRingMeta.Rotation.x, rightRingMeta.Rotation.y, rightRingMeta.Rotation.z, rightRingMeta.Rotation.w,
                    rightRingProx.PrevJoint.x, rightRingProx.PrevJoint.y, rightRingProx.PrevJoint.z, rightRingProx.NextJoint.x, rightRingProx.NextJoint.y, rightRingProx.NextJoint.z, rightRingProx.Center.x, rightRingProx.Center.y, rightRingProx.Center.z, rightRingProx.Direction.x, rightRingProx.Direction.y, rightRingProx.Direction.z, rightRingProx.Length, rightRingProx.Width, 1, rightRingProx.Rotation.x, rightRingProx.Rotation.y, rightRingProx.Rotation.z, rightRingProx.Rotation.w,
                    rightRingInter.PrevJoint.x, rightRingInter.PrevJoint.y, rightRingInter.PrevJoint.z, rightRingInter.NextJoint.x, rightRingInter.NextJoint.y, rightRingInter.NextJoint.z, rightRingInter.Center.x, rightRingInter.Center.y, rightRingInter.Center.z, rightRingInter.Direction.x, rightRingInter.Direction.y, rightRingInter.Direction.z, rightRingInter.Length, rightRingInter.Width, 2, rightRingInter.Rotation.x, rightRingInter.Rotation.y, rightRingInter.Rotation.z, rightRingInter.Rotation.w,
                    rightRingDist.PrevJoint.x, rightRingDist.PrevJoint.y, rightRingDist.PrevJoint.z, rightRingDist.NextJoint.x, rightRingDist.NextJoint.y, rightRingDist.NextJoint.z, rightRingDist.Center.x, rightRingDist.Center.y, rightRingDist.Center.z, rightRingDist.Direction.x, rightRingDist.Direction.y, rightRingDist.Direction.z, rightRingDist.Length, rightRingDist.Width, 3, rightRingDist.Rotation.x, rightRingDist.Rotation.y, rightRingDist.Rotation.z, rightRingDist.Rotation.w,

                    rightPinkyMeta.PrevJoint.x, rightPinkyMeta.PrevJoint.y, rightPinkyMeta.PrevJoint.z, rightPinkyMeta.NextJoint.x, rightPinkyMeta.NextJoint.y, rightPinkyMeta.NextJoint.z, rightPinkyMeta.Center.x, rightPinkyMeta.Center.y, rightPinkyMeta.Center.z, rightPinkyMeta.Direction.x, rightPinkyMeta.Direction.y, rightPinkyMeta.Direction.z, rightPinkyMeta.Length, rightPinkyMeta.Width, 0, rightPinkyMeta.Rotation.x, rightPinkyMeta.Rotation.y, rightPinkyMeta.Rotation.z, rightPinkyMeta.Rotation.w,
                    rightPinkyProx.PrevJoint.x, rightPinkyProx.PrevJoint.y, rightPinkyProx.PrevJoint.z, rightPinkyProx.NextJoint.x, rightPinkyProx.NextJoint.y, rightPinkyProx.NextJoint.z, rightPinkyProx.Center.x, rightPinkyProx.Center.y, rightPinkyProx.Center.z, rightPinkyProx.Direction.x, rightPinkyProx.Direction.y, rightPinkyProx.Direction.z, rightPinkyProx.Length, rightPinkyProx.Width, 1, rightPinkyProx.Rotation.x, rightPinkyProx.Rotation.y, rightPinkyProx.Rotation.z, rightPinkyProx.Rotation.w,
                    rightPinkyInter.PrevJoint.x, rightPinkyInter.PrevJoint.y, rightPinkyInter.PrevJoint.z, rightPinkyInter.NextJoint.x, rightPinkyInter.NextJoint.y, rightPinkyInter.NextJoint.z, rightPinkyInter.Center.x, rightPinkyInter.Center.y, rightPinkyInter.Center.z, rightPinkyInter.Direction.x, rightPinkyInter.Direction.y, rightPinkyInter.Direction.z, rightPinkyInter.Length, rightPinkyInter.Width, 2, rightPinkyInter.Rotation.x, rightPinkyInter.Rotation.y, rightPinkyInter.Rotation.z, rightPinkyInter.Rotation.w,
                    rightPinkyDist.PrevJoint.x, rightPinkyDist.PrevJoint.y, rightPinkyDist.PrevJoint.z, rightPinkyDist.NextJoint.x, rightPinkyDist.NextJoint.y, rightPinkyDist.NextJoint.z, rightPinkyDist.Center.x, rightPinkyDist.Center.y, rightPinkyDist.Center.z, rightPinkyDist.Direction.x, rightPinkyDist.Direction.y, rightPinkyDist.Direction.z, rightPinkyDist.Length, rightPinkyDist.Width, 3, rightPinkyDist.Rotation.x, rightPinkyDist.Rotation.y, rightPinkyDist.Rotation.z, rightPinkyDist.Rotation.w,

                    //Right Hand Finger Data
                    frame.Id, rightHand.Id,
                    rightThumb.Id, rightThumb.TimeVisible, rightThumb.TipPosition.x, rightThumb.TipPosition.y, rightThumb.TipPosition.z, rightThumb.Direction.x, rightThumb.Direction.y, rightThumb.Direction.z, rightThumb.Width, rightThumb.Length, rightThumb.IsExtended, 0,
                    rightIndex.Id, rightIndex.TimeVisible, rightIndex.TipPosition.x, rightIndex.TipPosition.y, rightIndex.TipPosition.z, rightIndex.Direction.x, rightIndex.Direction.y, rightIndex.Direction.z, rightIndex.Width, rightIndex.Length, rightIndex.IsExtended, 0,
                    rightMiddle.Id, rightMiddle.TimeVisible, rightMiddle.TipPosition.x, rightMiddle.TipPosition.y, rightMiddle.TipPosition.z, rightMiddle.Direction.x, rightMiddle.Direction.y, rightMiddle.Direction.z, rightMiddle.Width, rightMiddle.Length, rightMiddle.IsExtended, 0,
                    rightRing.Id, rightRing.TimeVisible, rightRing.TipPosition.x, rightRing.TipPosition.y, rightRing.TipPosition.z, rightRing.Direction.x, rightRing.Direction.y, rightRing.Direction.z, rightRing.Width, rightRing.Length, rightRing.IsExtended, 0,
                    rightPinky.Id, rightPinky.TimeVisible, rightPinky.TipPosition.x, rightPinky.TipPosition.y, rightPinky.TipPosition.z, rightPinky.Direction.x, rightPinky.Direction.y, rightPinky.Direction.z, rightPinky.Width, rightPinky.Length, rightPinky.IsExtended, 0,

                    //Right Arm Data
                    rightArm.ElbowPosition.x, rightArm.ElbowPosition.y, rightArm.ElbowPosition.z, rightArm.WristPosition.x, rightArm.WristPosition.y, rightArm.WristPosition.z, rightArm.Center.x, rightArm.Center.y, rightArm.Center.z, rightArm.Direction.x, rightArm.Direction.y, rightArm.Direction.z, rightArm.Length, rightArm.Width, rightArm.Rotation.x, rightArm.Rotation.y, rightArm.Rotation.z, rightArm.Rotation.w,

                    //Right Hand Data
                    rightHand.Confidence, rightHand.GrabStrength, rightHand.GrabAngle, rightHand.PinchStrength, rightHand.PinchDistance, rightHand.PalmWidth, rightHand.IsLeft, rightHand.TimeVisible, rightHand.PalmPosition.x, rightHand.PalmPosition.y, rightHand.PalmPosition.z, rightHand.StabilizedPalmPosition.x, rightHand.StabilizedPalmPosition.y, rightHand.StabilizedPalmPosition.z, rightHand.PalmVelocity.x, rightHand.PalmVelocity.y, rightHand.PalmVelocity.z, rightHand.PalmNormal.x, rightHand.PalmNormal.y, rightHand.PalmNormal.z, rightHand.Rotation.x, rightHand.Rotation.y, rightHand.Rotation.z, rightHand.Rotation.w, rightHand.Direction.x, rightHand.Direction.y, rightHand.Direction.z, rightHand.WristPosition.x, rightHand.WristPosition.y, rightHand.WristPosition.z,

                    //Frame Data
                    frame.Timestamp, frame.CurrentFramesPerSecond);

                   //Console.WriteLine("Right hand confidence is " + rightHand.Confidence);
                }
            }

            return leapData;
        }
    }
}
