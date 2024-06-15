using MovesetParser.BulkSerialize;

namespace MovesetParser.StateActions
{
    public class SASetCommandGrab : StateAction, IBulkSerializer
    {
        public string State;

        public SASetCommandGrab() { }

        public new static SASetCommandGrab ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            return new SASetCommandGrab
            {
                TID = TypeId.SASetCommandGrab,
                State = reader.GetNextString()
            };
        }

        public override void WriteSerial(Writer writer)
        {
            writer.AddInt(67);
            writer.AddInt(0);

            writer.AddString(State);
        }
    }
}
