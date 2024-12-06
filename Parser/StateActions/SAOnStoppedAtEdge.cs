using MovesetParser.BulkSerialize;

namespace MovesetParser.StateActions
{
    [Serializable]
    public class SAOnStoppedAtEdge : StateAction, IBulkSerializer
    {
        public StateAction Action;

        public SAOnStoppedAtEdge() { }

        public new static SAOnStoppedAtEdge ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            return new SAOnStoppedAtEdge
            {
                TID = TypeId.SAOnStoppedAtEdge,
                Action = StateAction.ReadSerial(reader)
            };
        }

        public override void WriteSerial(Writer writer)
        {
            writer.AddInt(20);
            writer.AddInt(0);

            Action ??= new StateAction();
            Action.WriteSerial(writer);
        }
    }
}
