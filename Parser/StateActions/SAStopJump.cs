using MovesetParser.BulkSerialize;

namespace MovesetParser.StateActions
{
    public class SAStopJump : StateAction, IBulkSerializer
    {
        public bool StopAll;
        public string JumpId = string.Empty;
        public string[] JumpIds = new string[0];

        public SAStopJump() { }

        public new static SAStopJump ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            var version = reader.GetNextInt();

            var stopJump = new SAStopJump
            {
                TID = TypeId.SAStopJump,
                StopAll = (reader.GetNextInt() > 0),
                JumpId = reader.GetNextString()
            };

            if (version > 0)
            {
                stopJump.JumpIds = new string[reader.GetNextInt()];

                for (int i = 0; i < stopJump.JumpIds.Length; i++)
                {
                    stopJump.JumpIds[i] = reader.GetNextString();
                }
            }
            else
            {
                stopJump.JumpIds = new string[0];
            }

            return stopJump;
        }

        public override void WriteSerial(Writer writer)
        {
            writer.AddInt(61);
            writer.AddInt(1);

            writer.AddInt(StopAll ? 7 : 0);
            writer.AddString(JumpId);

            writer.AddInt(JumpIds.Length);

            for (int i = 0; i < JumpIds.Length; i++)
            {
                writer.AddString(JumpIds[i]);
            }
        }
    }
}
