using MovesetParser.BulkSerialize;

namespace MovesetParser.FloatSources
{
    [Serializable]
    public class FSColors : FloatSource, IBulkSerializer
    {
        public string ColorId;
        public bool Permanent;

        public FSColors() { }

        public new static FSColors ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            return new FSColors
            {
                TID = TypeId.FSColors,
                ColorId = reader.GetNextString(),
                Permanent = (reader.GetNextInt() > 0)
            };
        }

        public override void WriteSerial(Writer writer)
        {
            writer.AddInt(19);
            writer.AddInt(0);

            writer.AddString(ColorId);
            writer.AddInt(Permanent ? 7 : 0);
        }
    }
}
