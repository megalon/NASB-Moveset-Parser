using MovesetParser.BulkSerialize;

namespace MovesetParser.StateActions
{
    [Serializable]
    public class SAIgnoreGrabbed : StateAction, IBulkSerializer
    {
        public SAIgnoreGrabbed() { }

        public new static SAIgnoreGrabbed ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            return new SAIgnoreGrabbed()
            {
                TID = TypeId.SAIgnoreGrabbed
            };
        }

        public override void WriteSerial(Writer writer)
        {
            writer.AddInt(47);
            writer.AddInt(0);
        }
    }
}
