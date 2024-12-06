using MovesetParser.BulkSerialize;

namespace MovesetParser.Misc
{
    [Serializable]
    public class AnimConfig : IBulkSerializer
    {
        public float Rate;
        public float Weight;
        public WrapMode WrapMode;
        public bool ClingToFrames;

        public AnimConfig() { }

        public static AnimConfig Default => new AnimConfig()
        {
            Rate = 1f,
            Weight = 1f,
            WrapMode = WrapMode.Default,
            ClingToFrames = false
        };

        public static AnimConfig ReadSerial(Reader reader)
        {
            reader.GetNextInt();

            return new AnimConfig
            {
                Rate = reader.GetNextFloat(),
                Weight = reader.GetNextFloat(),
                WrapMode = (WrapMode)reader.GetNextInt(),
                ClingToFrames = reader.GetNextInt() > 0
            };
        }

        public void WriteSerial(Writer writer)
        {
            writer.AddInt(0);

            writer.AddFloat(Rate);
            writer.AddFloat(Weight);
            writer.AddInt((int)WrapMode);
            writer.AddInt(ClingToFrames ? 7 : 0);
        }
    }
}
