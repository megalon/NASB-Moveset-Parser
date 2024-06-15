using MovesetParser.BulkSerialize;

namespace MovesetParser.FloatSources
{
    public class FSTimer : FloatSource, IBulkSerializer
    {
        public string Id;

        public FSTimer() { }

        public new static FSTimer ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            return new FSTimer
            {
                TID = TypeId.FSTimer,
                Id = reader.GetNextString()
            };
        }

        public override void WriteSerial(Writer writer)
        {
            writer.AddInt(16);
            writer.AddInt(0);

            writer.AddString(Id);
        }
    }
}
