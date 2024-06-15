using MovesetParser.BulkSerialize;
using MovesetParser.CheckThings;

namespace MovesetParser.StateActions
{
    public class SACheckThing : StateAction, IBulkSerializer
    {
        public CheckThing CheckThing;
        public StateAction Action;
        public bool Else;
        public StateAction ElseAction;

        public SACheckThing() { }

        private void EnsureStuff()
        {
            CheckThing ??= new CTInput();
            Action ??= new StateAction();
            ElseAction ??= new StateAction();
        }

        public new static SACheckThing ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            return new SACheckThing
            {
                TID = TypeId.SACheckThing,
                CheckThing = CheckThing.ReadSerial(reader),
                Action = StateAction.ReadSerial(reader),
                Else = (reader.GetNextInt() > 0),
                ElseAction = StateAction.ReadSerial(reader)
            };
        }

        public override void WriteSerial(Writer writer)
        {
            EnsureStuff();

            writer.AddInt(14);
            writer.AddInt(0);

            CheckThing.WriteSerial(writer);
            Action.WriteSerial(writer);
            writer.AddInt(Else ? 7 : 0);
            ElseAction.WriteSerial(writer);
        }
    }
}
