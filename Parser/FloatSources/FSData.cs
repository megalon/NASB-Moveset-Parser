using MovesetParser.BulkSerialize;

namespace MovesetParser.FloatSources
{
    [Serializable]
    public class FSData : FloatSource, IBulkSerializer
    {
        public string Id;

        public FSData() { }

        public new static FSData ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            return new FSData
            {
                TID = TypeId.FSData,
                Id = reader.GetNextString()
            };
        }

        public override void WriteSerial(Writer writer)
        {
            writer.AddInt(10);
            writer.AddInt(0);

            writer.AddString(Id);
        }
    }
}
