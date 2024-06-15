using MovesetParser.BulkSerialize;
using MovesetParser.StateActions;

namespace MovesetParser
{
    public class TimedAction : IBulkSerializer
    {
        public float AtFrame;
        public StateAction Action;

        public TimedAction() { }
        public TimedAction(Reader reader)
        {
            reader.GetNextInt();
            AtFrame = reader.GetNextFloat();
            Action = StateAction.ReadSerial(reader);
        }

        public static TimedAction ReadSerial(Reader reader) => new TimedAction(reader);

        public void WriteSerial(Writer writer)
        {
            writer.AddInt(0);
            writer.AddFloat(AtFrame);

            Action ??= new();
            Action.WriteSerial(writer);
        }
    }
}
