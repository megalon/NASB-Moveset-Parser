using MovesetParser.BulkSerialize;

namespace MovesetParser.FloatSources
{
    [Serializable]
    public class FSMovement : FloatSource, IBulkSerializer
    {
        public MovementAttribute Attribute;

        public FSMovement() { }

        public new static FSMovement ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            return new FSMovement
            {
                TID = TypeId.FSMovement,
                Attribute = (MovementAttribute)reader.GetNextInt()
            };
        }

        public override void WriteSerial(Writer writer)
        {
            writer.AddInt(7);
            writer.AddInt(0);

            writer.AddInt((int)Attribute);
        }

        public enum MovementAttribute
        {
            Vel_X = 0,
            Vel_X_raw = 1,
            Vel_Y = 2,
            Direction = 3,
            Grounded = 36,
            ClosestParentEdge = 60,
            Last_move_X_raw = 50,
            Last_move_Y = 51,
            ClampInitial = 68,
            ClampMovement = 70,
            ClampRemain = 71,
            IncreaseMoveDT = 4,
            IncreaseMoveDTFalloff = 5,
            AllowCtrl = 6,
            RootPosReset = 7,
            ForceNextFloorCheck = 8,
            CheckFloorFromMid = 9,
            ExtendFloorCheckToMid = 58,
            CheckFloorThickness = 53,
            FallSpeed = 10,
            FallSpeedMultiplier = 44,
            Gravity = 11,
            GravityMultiplier = 83,
            Antigravity = 65,
            FloorFriction = 12,
            FloorAcc = 13,
            FloorDec = 61,
            FloorBrake = 14,
            FloorSpeed = 15,
            FloorDecay = 64,
            AirFriction = 63,
            AirAcc = 16,
            AirDec = 62,
            AirBrake = 17,
            AirSpeed = 18,
            AirDecay = 19,
            XSpeedMultiplier = 45,
            RootMotionMult_X = 20,
            RootMotionMult_Y = 21,
            ResizeCollision = 22,
            MinColH = 23,
            MinColW = 24,
            ExtendBottom = 25,
            BottomCollisionWorldPos = 57,
            CrowdPushing = 37,
            CrowdPushRadius = 38,
            CrowdPushWeight = 48,
            CrowdPushMaxDistPerFrame = 52,
            CrowdPushingFromLedge = 66,
            CrowdPushMaxDistOverride = 69,
            GrabEdge = 39,
            GrabEdgeExtendFwd = 40,
            GrabEdgeExtendBack = 41,
            GrabEdgeExtendUp = 42,
            GrabEdgeExtendDown = 43,
            DisableMovement = 56,
            DisableCollision = 59,
            DisableSink = 67,
            GetParented = 26,
            LeaveEdges = 27,
            FallThrough = 28,
            PassThrough = 46,
            IgnoreMovingStage = 29,
            Bounce = 30,
            Stop = 31,
            LeaveParent = 32,
            InheritParentVel = 33,
            LeaveEdgeRestrict = 47,
            SimpleFreeMovement = 54,
            SimpleRadius = 55,
            FloorTilt = 34,
            SolidGround = 35,
            ParentOrderAdded = 49
        }
    }
}
