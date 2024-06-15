using MovesetParser.BulkSerialize;

namespace MovesetParser.StateActions
{
    public class SAOnLand : StateAction, IBulkSerializer
    {
        public StateAction Action;

        public SAOnLand() { }

        public new static SAOnLand ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            return new SAOnLand
            {
                TID = TypeId.SAOnLand,
                Action = StateAction.ReadSerial(reader)
            };
        }

        public override void WriteSerial(Writer writer)
        {
            writer.AddInt(21);
            writer.AddInt(0);

            Action ??= new StateAction();
            Action.WriteSerial(writer);
        }
    }
}
