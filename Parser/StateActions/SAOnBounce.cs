using MovesetParser.BulkSerialize;

namespace MovesetParser.StateActions
{
    [Serializable]
    public class SAOnBounce : StateAction, IBulkSerializer
    {
        public StateAction Action;

        public SAOnBounce() { }

        public new static SAOnBounce ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            return new SAOnBounce
            {
                TID = TypeId.SAOnBounce,
                Action = StateAction.ReadSerial(reader)
            };
        }

        public override void WriteSerial(Writer writer)
        {
            writer.AddInt(18);
            writer.AddInt(0);

            Action ??= new StateAction();
            Action.WriteSerial(writer);
        }
    }
}
