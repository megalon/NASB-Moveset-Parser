using MovesetParser.BulkSerialize;

namespace MovesetParser.FloatSources
{
    public class FSSports : FloatSource, IBulkSerializer
    {
        public SportsAttribute Attribute;

        public FSSports() { }

        public new static FSSports ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            return new FSSports
            {
                TID = TypeId.FSSports,
                Attribute = (SportsAttribute)reader.GetNextInt()
            };
        }

        public override void WriteSerial(Writer writer)
        {
            writer.AddInt(23);
            writer.AddInt(0);

            writer.AddInt((int)Attribute);
        }

        public enum SportsAttribute
        {
            ActiveBall,
            BounceOnGoalEdge,
            GoalScore,
            RespawnBall,
            InheritPush,
            LastBallPushX,
            LastBallPushY
        }
    }
}
