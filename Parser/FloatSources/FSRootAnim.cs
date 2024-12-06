using MovesetParser.BulkSerialize;

namespace MovesetParser.FloatSources
{
    [Serializable]
    public class FSRootAnim : FloatSource, IBulkSerializer
    {
        public RootAnimAttribute Attribute;

        public FSRootAnim() { }

        public new static FSRootAnim ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            return new FSRootAnim
            {
                TID = TypeId.FSRootAnim,
                Attribute = (RootAnimAttribute)reader.GetNextInt()
            };
        }

        public override void WriteSerial(Writer writer)
        {
            writer.AddInt(29);
            writer.AddInt(0);

            writer.AddInt((int)Attribute);
        }

        public enum RootAnimAttribute
        {
            RootRate,
            RootFrame
        }
    }
}
