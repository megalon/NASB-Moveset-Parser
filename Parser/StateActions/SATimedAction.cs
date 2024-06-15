using MovesetParser.BulkSerialize;
using MovesetParser.FloatSources;

namespace MovesetParser.StateActions
{
    public class SATimedAction : StateAction, IBulkSerializer
    {
        public FloatSourceContainer Time;
        public bool Repeat;
        public StateAction Action;

        public SATimedAction() { }

        private void EnsureStuff()
        {
            Time ??= new FloatSourceContainer(new FloatSource());
            Action ??= new StateAction();
        }

        public new static SATimedAction ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            return new SATimedAction
            {
                TID = TypeId.SATimedAction,
                Time = FloatSourceContainer.ReadSerial(reader),
                Repeat = (reader.GetNextInt() > 0),
                Action = StateAction.ReadSerial(reader)
            };
        }

        public override void WriteSerial(Writer writer)
        {
            EnsureStuff();

            writer.AddInt(11);
            writer.AddInt(0);

            Time.WriteSerial(writer);
            writer.AddInt(Repeat ? 7 : 0);
            Action.WriteSerial(writer);
        }
    }
}
