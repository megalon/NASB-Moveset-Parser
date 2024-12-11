using MovesetParser.BulkSerialize;

namespace MovesetParser.FloatSources
{
    [Serializable]
    public class FSGrabs : FloatSource, IBulkSerializer
    {
        public GrabsAttribute Attribute = GrabsAttribute.AllowedToEscape;

        public FSGrabs() { }

        public new static FSGrabs ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            return new FSGrabs
            {
                TID = TypeId.FSGrabs,
                Attribute = (GrabsAttribute)reader.GetNextInt()
            };
        }

        public override void WriteSerial(Writer writer)
        {
            writer.AddInt(9);
            writer.AddInt(0);

            writer.AddInt((int)Attribute);
        }

        public enum GrabsAttribute
        {
            HardSyncPos = 0,
            AllowGrabEscape = 1,
            AllowedToEscape = 2,
            GrabbedAgentWeight = 3,
            GrabbedByPlayerIndex = 4,
            GrabbedByAttackTeam = 5,
            GroundGrabRadius = 6,
            GroundGrabHitbox1X = 7,
            GroundGrabHitbox1Y = 8,
            GroundGrabHitbox2X = 9,
            GroundGrabHitbox2Y = 10,
            GroundGrabHit = 11,
            GroundGrabTime = 12,
            GroundThrowUpOffsetX = 13,
            GroundThrowUpOffsetY = 14,
            GroundThrowMidOffsetX = 15,
            GroundThrowMidOffsetY = 16,
            GroundThrowDownOffsetX = 17,
            GroundThrowDownOffsetY = 18,
            GroundThrowUpRelease = 19,
            GroundThrowUpTime = 20,
            AirGrabRadius = 21,
            AirGrabHitbox1X = 22,
            AirGrabHitbox1Y = 23,
            AirGrabHitbox2X = 24,
            AirGrabHitbox2Y = 25,
            AirGrabHit = 26,
            AirGrabTime = 27,
            AirThrowUpOffsetX = 28,
            AirThrowUpOffsetY = 29,
            AirThrowMidOffsetX = 30,
            AirThrowMidOffsetY = 31,
            AirThrowDownOffsetX = 32,
            AirThrowDownOffsetY = 33,
            AirThrowUpRelease = 34,
            AirThrowUpTime = 35,
            GroundGrabHitAnim = 36,
            GroundThrowUpReleaseAnim = 37,
            GroundThrowMidRelease = 38,
            GroundThrowMidReleaseAnim = 39,
            GroundThrowMidTime = 40,
            GroundThrowDownRelease = 41,
            GroundThrowDownReleaseAnim = 42,
            GroundThrowDownTime = 43,
            AirGrabHitAnim = 44,
            AirThrowUpReleaseAnim = 45,
            AirThrowMidRelease = 46,
            AirThrowMidReleaseAnim = 47,
            AirThrowMidTime = 48,
            AirThrowDownRelease = 49,
            AirThrowDownReleaseAnim = 50,
            AirThrowDownTime = 51
        }
    }
}
