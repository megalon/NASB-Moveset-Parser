using MovesetParser.BulkSerialize;

namespace MovesetParser.StateActions
{
    [Serializable]
    public class SAOnLeaveParent : StateAction, IBulkSerializer
    {
        public StateAction Action;

        public SAOnLeaveParent() { }

        public new static SAOnLeaveParent ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            return new SAOnLeaveParent
            {
                TID = TypeId.SAOnLeaveParent,
                Action = StateAction.ReadSerial(reader)
            };
        }

        public override void WriteSerial(Writer writer)
        {
            writer.AddInt(77);
            writer.AddInt(0);

            Action ??= new StateAction();
            Action.WriteSerial(writer);
        }
    }
}
