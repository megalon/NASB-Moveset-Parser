using MovesetParser.BulkSerialize;

namespace MovesetParser.FloatSources
{
    public class FSFrame : FloatSource, IBulkSerializer
    {
        public FSFrame() { }

        public new static FSFrame ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            return new FSFrame
            {
                TID = TypeId.FSFrame,
                Value = reader.GetNextFloat()
            };
        }

        public override void WriteSerial(Writer writer)
        {
            writer.AddInt(4);
            writer.AddInt(0);

            writer.AddFloat(Value);
        }
    }
}
