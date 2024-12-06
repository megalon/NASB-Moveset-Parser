using MovesetParser.BulkSerialize;

namespace MovesetParser.FloatSources
{
    [Serializable]
    public class FSRandom : FloatSource, IBulkSerializer
    {
        public bool Ratio;
        public FloatSourceContainer A;
        public FloatSourceContainer B;

        public FSRandom() { }

        private void EnsureStuff()
        {
            A ??= new FloatSourceContainer(new FloatSource());
            B ??= new FloatSourceContainer(new FloatSource());
        }

        public new static FSRandom ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            return new FSRandom
            {
                TID = TypeId.FSRandom,
                Ratio = (reader.GetNextInt() > 0),
                A = FloatSourceContainer.ReadSerial(reader),
                B = FloatSourceContainer.ReadSerial(reader)
            };
        }

        public override void WriteSerial(Writer writer)
        {
            EnsureStuff();

            writer.AddInt(21);
            writer.AddInt(0);

            writer.AddInt(Ratio ? 7 : 0);

            A.WriteSerial(writer);
            B.WriteSerial(writer);
        }
    }
}
