using MovesetParser.BulkSerialize;
using MovesetParser.Misc;

namespace MovesetParser.FloatSources
{
    [Serializable]
    public class FSSpeed : FloatSource, IBulkSerializer
    {
        public SpeedType SpeedType;

        public FSSpeed() { }

        public new static FSSpeed ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            return new FSSpeed
            {
                TID = TypeId.FSSpeed,
                SpeedType = (SpeedType)reader.GetNextInt()
            };
        }

        public override void WriteSerial(Writer writer)
        {
            writer.AddInt(13);
            writer.AddInt(0);

            writer.AddInt((int)SpeedType);
        }
    }
}
