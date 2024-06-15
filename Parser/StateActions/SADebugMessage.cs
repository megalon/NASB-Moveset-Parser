using MovesetParser.BulkSerialize;

namespace MovesetParser.StateActions
{
    public class SADebugMessage : StateAction, IBulkSerializer
    {
        public string Message = string.Empty;

        public SADebugMessage() { }

        public new static SADebugMessage ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            return new SADebugMessage
            {
                TID = TypeId.SADebugMessage,
                Message = reader.GetNextString()
            };
        }

        public override void WriteSerial(Writer writer)
        {
            writer.AddInt(1);
            writer.AddInt(0);

            writer.AddString(Message);
        }
    }
}
