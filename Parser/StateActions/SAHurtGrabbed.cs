using MovesetParser.BulkSerialize;

namespace MovesetParser.StateActions
{
    [Serializable]
    public class SAHurtGrabbed : StateAction, IBulkSerializer
    {
        public string AtkProp = string.Empty;

        public SAHurtGrabbed() { }

        public new static SAHurtGrabbed ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            return new SAHurtGrabbed
            {
                TID = TypeId.SAHurtGrabbed,
                AtkProp = reader.GetNextString()
            };
        }

        public override void WriteSerial(Writer writer)
        {
            writer.AddInt(42);
            writer.AddInt(0);

            writer.AddString(AtkProp);
        }
    }
}
