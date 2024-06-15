using MovesetParser.BulkSerialize;

namespace MovesetParser.StateActions
{
    public class SAOnCancel : StateAction, IBulkSerializer
    {
        public string Id;
        public StateAction Action;

        public SAOnCancel() { }

        public new static SAOnCancel ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            return new SAOnCancel
            {
                TID = TypeId.SAOnCancel,
                Id = reader.GetNextString(),
                Action = StateAction.ReadSerial(reader)
            };
        }

        public override void WriteSerial(Writer writer)
        {
            writer.AddInt(22);
            writer.AddInt(0);

            writer.AddString(Id);

            Action ??= new StateAction();
            Action.WriteSerial(writer);
        }
    }
}
