using MovesetParser.BulkSerialize;
using MovesetParser.FloatSources;

namespace MovesetParser.ObjectSources
{
    [Serializable]
    public class OSVector2 : ObjectSource, IBulkSerializer
    {
        public FloatSourceContainer X;
        public FloatSourceContainer Y;

        public OSVector2() { }

        public new static OSVector2 ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            return new OSVector2
            {
                TID = TypeId.OSVector2,
                X = FloatSourceContainer.ReadSerial(reader),
                Y = FloatSourceContainer.ReadSerial(reader)
            };
        }

        public override void WriteSerial(Writer writer)
        {
            X ??= new FloatSourceContainer();
            Y ??= new FloatSourceContainer();

            writer.AddInt(2);
            writer.AddInt(0);

            X.WriteSerial(writer);
            Y.WriteSerial(writer);
        }
    }
}
