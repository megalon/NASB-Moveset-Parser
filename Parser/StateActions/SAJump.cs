using MovesetParser.BulkSerialize;
using MovesetParser.Jumps;

namespace MovesetParser.StateActions
{
    public class SAJump : StateAction, IBulkSerializer
    {
        public string JumpId;
        public Jump Jump;

        public SAJump() { }

        public new static SAJump ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            return new SAJump
            {
                TID = TypeId.SAJump,
                JumpId = reader.GetNextString(),
                Jump = Jump.ReadSerial(reader)
            };
        }

        public override void WriteSerial(Writer writer)
        {
            writer.AddInt(60);
            writer.AddInt(0);

            writer.AddString(JumpId);

            Jump ??= new Jump();
            Jump.WriteSerial(writer);
        }
    }
}
