using MovesetParser.BulkSerialize;

namespace MovesetParser.FloatSources
{
    [Serializable]
    public class FloatSourceContainer : IBulkSerializer
    {
        public FloatSource FloatSource;

        public FloatSourceContainer() => FloatSource = new();

        public FloatSourceContainer(FloatSource floatSource) => FloatSource = floatSource;

        public static FloatSourceContainer ReadSerial(Reader r) => new(FloatSource.ReadSerial(r));

        public void WriteSerial(Writer writer)
        {
            FloatSource ??= new();
            FloatSource.WriteSerial(writer);
        }
    }
}
