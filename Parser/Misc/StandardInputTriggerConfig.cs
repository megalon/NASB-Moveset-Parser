using MovesetParser.BulkSerialize;

namespace MovesetParser.Misc
{
    public class StandardInputTriggerConfig : IBulkSerializer
    {
        public byte[] DontCheckBytes = new byte[4];

        public StandardInputTriggerConfig() { }

        public void ReadSerial(Reader reader)
        {
            reader.GetNextInt();

            DontCheckBytes[0] = (byte)reader.GetNextInt();
            DontCheckBytes[1] = (byte)reader.GetNextInt();
            DontCheckBytes[2] = (byte)reader.GetNextInt();
            DontCheckBytes[3] = (byte)reader.GetNextInt();
        }

        public void WriteSerial(Writer writer)
        {
            writer.AddInt(0);

            writer.AddInt(DontCheckBytes[0]);
            writer.AddInt(DontCheckBytes[1]);
            writer.AddInt(DontCheckBytes[2]);
            writer.AddInt(DontCheckBytes[3]);
        }
    }
}
