using MovesetParser.BulkSerialize;

namespace MovesetParser.StateActions
{
    [Serializable]
    public class SACustomCall : StateAction, IBulkSerializer
    {
        public string CallId = string.Empty;

        public SACustomCall() { }

        public new static SACustomCall ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            return new SACustomCall
            {
                TID = TypeId.SACustomCall,
                CallId = reader.GetNextString()
            };
        }

        public override void WriteSerial(Writer writer)
        {
            writer.AddInt(10);
            writer.AddInt(0);

            writer.AddString(CallId);
        }
    }
}
