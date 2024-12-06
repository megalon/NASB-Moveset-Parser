using MovesetParser.BulkSerialize;
using MovesetParser.StateActions;

namespace MovesetParser.Misc
{
    [Serializable]
    public class InputTrigger : IBulkSerializer
    {
        public int SniffFrames = 1;
        public GIEV BlockedByEvent;
        public GIEV AddEventOnTrigger;
        public InputValidator Validator;
        public StateAction Action;

        public InputTrigger() { }

        private void EnsureStuff()
        {
            Validator ??= new InputValidator();
            Action ??= new StateAction();
        }

        public void ReadSerial(Reader reader)
        {
            reader.GetNextInt();

            SniffFrames = reader.GetNextInt();
            BlockedByEvent = (GIEV)reader.GetNextInt();
            AddEventOnTrigger = (GIEV)reader.GetNextInt();
            Action = StateAction.ReadSerial(reader);
            Validator = InputValidator.ReadSerial(reader);
        }

        public void WriteSerial(Writer writer)
        {
            EnsureStuff();

            writer.AddInt(0);

            writer.AddInt(SniffFrames);
            writer.AddInt((int)BlockedByEvent);
            writer.AddInt((int)AddEventOnTrigger);
            Action.WriteSerial(writer);
            Validator.WriteSerial(writer);
        }
    }
}
