using MovesetParser.BulkSerialize;

namespace MovesetParser.StateActions
{
    public class SADeactivateInputAction : StateAction, IBulkSerializer
    {
        public string Id;

        public SADeactivateInputAction() { }

        public new static SADeactivateInputAction ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            return new SADeactivateInputAction
            {
                TID = TypeId.SADeactivateInputAction,
                Id = reader.GetNextString()
            };
        }

        public override void WriteSerial(Writer writer)
        {
            writer.AddInt(7);
            writer.AddInt(0);

            writer.AddString(Id);
        }
    }
}
