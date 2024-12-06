using MovesetParser.BulkSerialize;

namespace MovesetParser.StateActions
{
    [Serializable]
    public class SASampleAnim : StateAction, IBulkSerializer
    {
        public SASampleAnim() { }

        public new static SASampleAnim ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            return new SASampleAnim()
            {
                TID = TypeId.SASampleAnim
            };
        }

        public override void WriteSerial(Writer writer)
        {
            writer.AddInt(72);
            writer.AddInt(0);
        }
    }
}
