using MovesetParser.BulkSerialize;

namespace MovesetParser.StateActions
{
    public class SADeactivateAction : StateAction, IBulkSerializer
    {
        public int Index;
        public string Id;

        public SADeactivateAction() { }

        public new static SADeactivateAction ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            return new SADeactivateAction
            {
                TID = TypeId.SADeactivateAction,
                Index = reader.GetNextInt(),
                Id = reader.GetNextString()
            };
        }

        public override void WriteSerial(Writer writer)
        {
            writer.AddInt(16);
            writer.AddInt(0);

            writer.AddInt(Index);
            writer.AddString(Id);
        }
    }
}
