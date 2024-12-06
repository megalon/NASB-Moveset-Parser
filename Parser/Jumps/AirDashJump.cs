using MovesetParser.BulkSerialize;

namespace MovesetParser.Jumps
{
    [Serializable]
    public class AirDashJump : Jump, IBulkSerializer
    {
        public AirDashJump() { }

        public new static AirDashJump ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            return new AirDashJump()
            {
                TID = TypeId.AirDashJump
            };
        }

        public override void WriteSerial(Writer writer)
        {
            writer.AddInt(3);
            writer.AddInt(2);
        }
    }
}
