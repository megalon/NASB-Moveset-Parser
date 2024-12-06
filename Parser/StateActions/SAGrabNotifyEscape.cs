using MovesetParser.BulkSerialize;

namespace MovesetParser.StateActions
{
    [Serializable]
    public class SAGrabNotifyEscape : StateAction, IBulkSerializer
    {
        public SAGrabNotifyEscape() { }

        public new static SAGrabNotifyEscape ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            return new SAGrabNotifyEscape()
            {
                TID = TypeId.SAGrabNotifyEscape
            };
        }

        public override void WriteSerial(Writer writer)
        {
            writer.AddInt(46);
            writer.AddInt(0);
        }
    }
}
