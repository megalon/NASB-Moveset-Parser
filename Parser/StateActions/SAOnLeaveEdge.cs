using MovesetParser.BulkSerialize;

namespace MovesetParser.StateActions
{
    public class SAOnLeaveEdge : StateAction, IBulkSerializer
    {
        public StateAction Action;

        public SAOnLeaveEdge() { }

        public new static SAOnLeaveEdge ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            return new SAOnLeaveEdge
            {
                TID = TypeId.SAOnLeaveEdge,
                Action = StateAction.ReadSerial(reader)
            };
        }

        public override void WriteSerial(Writer writer)
        {
            writer.AddInt(19);
            writer.AddInt(0);

            Action ??= new StateAction();
            Action.WriteSerial(writer);
        }
    }
}
