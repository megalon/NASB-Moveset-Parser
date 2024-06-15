using MovesetParser.BulkSerialize;

namespace MovesetParser.StateActions
{
    public class SACancelToState : StateAction, IBulkSerializer
    {
        public string ToState;
        public bool Soft;

        public SACancelToState() { }

        public new static SACancelToState ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            return new SACancelToState
            {
                TID = TypeId.SACancelToState,
                ToState = reader.GetNextString(),
                Soft = (reader.GetNextInt() > 0)
            };
        }

        public override void WriteSerial(Writer writer)
        {
            writer.AddInt(9);
            writer.AddInt(0);

            writer.AddString(ToState);
            writer.AddInt(Soft ? 7 : 0);
        }
    }
}
