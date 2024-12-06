using MovesetParser.BulkSerialize;

namespace MovesetParser.FloatSources
{
    [Serializable]
    public class FSVector2Mag : FloatSource, IBulkSerializer
    {
        public FloatSourceContainer X;
        public FloatSourceContainer Y;

        public FSVector2Mag() { }

        private void EnsureStuff()
        {
            X ??= new FloatSourceContainer(new FloatSource());
            Y ??= new FloatSourceContainer(new FloatSource());
        }

        public new static FSVector2Mag ReadSerial(Reader r)
        {
            r.GetNextInt();
            r.GetNextInt();

            return new FSVector2Mag
            {
                TID = TypeId.FSVector2Mag,
                X = FloatSourceContainer.ReadSerial(r),
                Y = FloatSourceContainer.ReadSerial(r)
            };
        }

        public override void WriteSerial(Writer w)
        {
            EnsureStuff();

            w.AddInt(24);
            w.AddInt(0);

            X.WriteSerial(w);
            Y.WriteSerial(w);
        }
    }
}
