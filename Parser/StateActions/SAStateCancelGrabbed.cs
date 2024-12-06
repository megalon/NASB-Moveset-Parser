using MovesetParser.BulkSerialize;

namespace MovesetParser.StateActions
{
    [Serializable]
    public class SAStateCancelGrabbed : StateAction, IBulkSerializer
    {
        public string ToState;
        public bool Proxy;

        public SAStateCancelGrabbed() { }

        public new static SAStateCancelGrabbed ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            var version = reader.GetNextInt();

            var stateCancelGrabbed = new SAStateCancelGrabbed()
            {
                TID = TypeId.SAStateCancelGrabbed
            };

            if (version > 0) stateCancelGrabbed.Proxy = reader.GetNextInt() > 0;

            stateCancelGrabbed.ToState = reader.GetNextString();

            return stateCancelGrabbed;
        }

        public override void WriteSerial(Writer writer)
        {
            writer.AddInt(44);
            writer.AddInt(1);

            writer.AddInt(Proxy ? 7 : 0);
            writer.AddString(ToState);
        }
    }
}
