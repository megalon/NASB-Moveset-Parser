using MovesetParser.BulkSerialize;

namespace MovesetParser.StateActions
{
    public class SAResetOnHits : StateAction, IBulkSerializer
    {
        public SAResetOnHits() { }

        public new static SAResetOnHits ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            return new SAResetOnHits()
            {
                TID = TypeId.SAResetOnHits
            };
        }

        public override void WriteSerial(Writer writer)
        {
            writer.AddInt(51);
            writer.AddInt(0);
        }
    }
}
