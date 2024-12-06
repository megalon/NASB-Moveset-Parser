using MovesetParser.BulkSerialize;

namespace MovesetParser.FloatSources
{
    [Serializable]
    public class FSMode : FloatSource, IBulkSerializer
    {
        public ModeAttribute Attribute;

        public FSMode() { }

        public new static FSMode ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            return new FSMode
            {
                TID = TypeId.FSMode,
                Attribute = (ModeAttribute)reader.GetNextInt()
            };
        }

        public override void WriteSerial(Writer writer)
        {
            writer.AddInt(27);
            writer.AddInt(0);

            writer.AddInt((int)Attribute);
        }

        public enum ModeAttribute
        {
            InputAllowed
        }
    }
}
