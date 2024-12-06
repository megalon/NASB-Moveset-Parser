using MovesetParser.BulkSerialize;
using MovesetParser.FloatSources;

namespace MovesetParser.StateActions
{
    [Serializable]
    public class SACameraPunch : StateAction, IBulkSerializer
    {
        public FloatSourceContainer X;
        public FloatSourceContainer Y;
        public FloatSourceContainer Z;
        public FloatSourceContainer T;

        public SACameraPunch() { }

        private void EnsureStuff()
        {
            X ??= new FloatSourceContainer(new FloatSource());
            Y ??= new FloatSourceContainer(new FloatSource());
            Z ??= new FloatSourceContainer(new FloatSource());
            T ??= new FloatSourceContainer(new FloatSource());
        }

        public new static SACameraPunch ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            return new SACameraPunch
            {
                TID = TypeId.SACameraPunch,
                X = FloatSourceContainer.ReadSerial(reader),
                Y = FloatSourceContainer.ReadSerial(reader),
                Z = FloatSourceContainer.ReadSerial(reader),
                T = FloatSourceContainer.ReadSerial(reader)
            };
        }

        public override void WriteSerial(Writer writer)
        {
            EnsureStuff();

            writer.AddInt(68);
            writer.AddInt(0);

            X.WriteSerial(writer);
            Y.WriteSerial(writer);
            Z.WriteSerial(writer);
            T.WriteSerial(writer);
        }
    }
}
