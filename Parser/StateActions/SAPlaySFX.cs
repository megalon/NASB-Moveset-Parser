using MovesetParser.BulkSerialize;

namespace MovesetParser.StateActions
{
    [Serializable]
    public class SAPlaySFX : StateAction, IBulkSerializer
    {
        public string SfxId = string.Empty;

        public SAPlaySFX() { }

        public new static SAPlaySFX ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            return new SAPlaySFX
            {
                TID = TypeId.SAPlaySFX,
                SfxId = reader.GetNextString()
            };
        }

        public override void WriteSerial(Writer writer)
        {
            writer.AddInt(38);
            writer.AddInt(0);

            writer.AddString(SfxId);
        }
    }
}
