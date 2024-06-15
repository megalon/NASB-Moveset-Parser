using MovesetParser.BulkSerialize;

namespace MovesetParser.StateActions
{
    public class SALeaveGround : StateAction, IBulkSerializer
    {
        public SALeaveGround() { }

        public new static SALeaveGround ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            return new SALeaveGround()
            {
                TID = TypeId.SALeaveGround
            };
        }

        public override void WriteSerial(Writer writer)
        {
            writer.AddInt(63);
            writer.AddInt(0);
        }
    }
}
