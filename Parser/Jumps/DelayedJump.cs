using MovesetParser.BulkSerialize;

namespace MovesetParser.Jumps
{
    public class DelayedJump : Jump, IBulkSerializer
    {
        public DelayedJump() { }

        public new static DelayedJump ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            return new DelayedJump()
            {
                TID = TypeId.DelayedJump
            };
        }

        public override void WriteSerial(Writer writer)
        {
            writer.AddInt(5);
            writer.AddInt(0);
        }
    }
}
