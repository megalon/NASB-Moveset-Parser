using MovesetParser.BulkSerialize;

namespace MovesetParser.Jumps
{
    [Serializable]
    public class ClampMomentumJump : Jump, IBulkSerializer
    {
        public ClampMomentumJump() { }

        public new static ClampMomentumJump ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            return new ClampMomentumJump()
            {
                TID = TypeId.ClampMomentumJump
            };
        }

        public override void WriteSerial(Writer writer)
        {
            writer.AddInt(6);
            writer.AddInt(0);
        }
    }
}
