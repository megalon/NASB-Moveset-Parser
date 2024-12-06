using MovesetParser.BulkSerialize;

namespace MovesetParser.FloatSources
{
    [Serializable]
    public class FSJumps : FloatSource, IBulkSerializer
    {
        public JumpsAttribute Attribute;

        public FSJumps() { }

        public new static FSJumps ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            return new FSJumps
            {
                TID = TypeId.FSJumps,
                Attribute = (JumpsAttribute)reader.GetNextInt()
            };
        }

        public override void WriteSerial(Writer writer)
        {
            writer.AddInt(28);
            writer.AddInt(0);

            writer.AddInt((int)Attribute);
        }

        public enum JumpsAttribute
        {
            TotalAirJumpsLeft = 0,
            TotalAirDashesLeft = 1,
            JumpGround = 2,
            JumpAir = 3,
            JumpEdge = 4,
            JumpWall = 5,
            JumpMultiplier = 6,
            DelayedEnable = 7,
            DelayedSpeedInitial = 8,
            DelayedSpeedEnd = 9,
            DelayedFrames = 10,
            DelayedEase = 11,
            AirDashSpeedInitial = 12,
            AirDashSpeedEnd = 13,
            AirDashSpeedMultUp = 14,
            AirDashSpeedMultDown = 15,
            AirDashFrames = 16,
            AirDashFramesWarmup = 17,
            AirDashEase = 18,
            KnockbackOnlyFlinch = 27,
            KnockbackApproximateDestinationX = 28,
            KnockbackApproximateDestinationY = 29,
            KnockbackExpectedDistanceX = 30,
            KnockbackExpectedDistanceY = 31,
            KnockbackExpectedDistanceTotal = 32,
            KnockbackTraveledX = 33,
            KnockbackTraveledY = 34,
            KnockbackTraveledTotal = 35,
            KnockbackTraveledAbsoluteX = 36,
            KnockbackTraveledAbsoluteY = 37,
            KnockbackTraveledAbsoluteTotal = 38,
            KnockbackLaunchVelocityX = 39,
            KnockbackLaunchVelocityY = 40,
            KnockbackLaunchVelocityTotal = 41,
            KnockbackLaunchVelocityTrueX = 42,
            KnockbackLaunchVelocityTrueY = 43,
            KnockbackLaunchVelocityTrueTotal = 44,
            KnockbackLaunchLastFrameX = 45,
            KnockbackLaunchLastFrameY = 46,
            KnockbackLaunchLastFrameTotal = 47,
            KnockbackAngle = 48,
            KnockbackFrames = 49,
            KnockbackDidDI = 50,
            KnockbackDiType = 51,
            KnockbackDiIn = 52,
            KnockbackDiOut = 53,
            KnockbackActFallSpeed = 54,
            KnockbackActGravity = 55,
            KnockbackRate = 56,
            KnockbackTargetRate = 57,
            KnockbackChangeRate = 58
        }
    }
}
