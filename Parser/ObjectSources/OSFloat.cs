using MovesetParser.BulkSerialize;
using MovesetParser.FloatSources;

namespace MovesetParser.ObjectSources
{
    [Serializable]
    public class OSFloat : ObjectSource, IBulkSerializer
    {
        public FloatSourceContainer Float;

        public OSFloat() { }

        public new static OSFloat ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            return new OSFloat
            {
                TID = TypeId.OSFloat,
                Float = FloatSourceContainer.ReadSerial(reader)
            };
        }

        public override void WriteSerial(Writer writer)
        {
            Float ??= new FloatSourceContainer();

            writer.AddInt(1);
            writer.AddInt(0);

            Float.WriteSerial(writer);
        }
    }
}
