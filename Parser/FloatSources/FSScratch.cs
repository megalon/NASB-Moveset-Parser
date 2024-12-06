using MovesetParser.BulkSerialize;

namespace MovesetParser.FloatSources
{
    [Serializable]
    public class FSScratch : FloatSource, IBulkSerializer
    {
        public int Scratch;

        public FSScratch() { }

        public new static FSScratch ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            return new FSScratch
            {
                TID = TypeId.FSScratch,
                Scratch = reader.GetNextInt()
            };
        }

        public override void WriteSerial(Writer writer)
        {
            writer.AddInt(11);
            writer.AddInt(0);

            writer.AddInt(Scratch);
        }
    }
}
