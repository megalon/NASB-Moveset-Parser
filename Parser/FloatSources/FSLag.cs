using MovesetParser.BulkSerialize;
using MovesetParser.Misc;

namespace MovesetParser.FloatSources
{
    [Serializable]
    public class FSLag : FloatSource, IBulkSerializer
    {
        public LagType LagType;
        public ManipLag ManipLag;

        public FSLag() { }

        public new static FSLag ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            return new FSLag
            {
                TID = TypeId.FSLag,
                LagType = (LagType)reader.GetNextInt(),
                ManipLag = (ManipLag)reader.GetNextInt()
            };
        }

        public override void WriteSerial(Writer writer)
        {
            writer.AddInt(17);
            writer.AddInt(0);

            writer.AddInt((int)LagType);
            writer.AddInt((int)ManipLag);
        }
    }
}
