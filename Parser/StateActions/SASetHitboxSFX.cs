using MovesetParser.BulkSerialize;

namespace MovesetParser.StateActions
{
    public class SASetHitboxSFX : StateAction, IBulkSerializer
    {
        public int HitBox;
        public string SfxId = string.Empty;

        public SASetHitboxSFX() { }

        public new static SASetHitboxSFX ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            return new SASetHitboxSFX
            {
                TID = TypeId.SASetHitboxSFX,
                HitBox = reader.GetNextInt(),
                SfxId = reader.GetNextString()
            };
        }

        public override void WriteSerial(Writer writer)
        {
            writer.AddInt(39);
            writer.AddInt(0);

            writer.AddInt(HitBox);
            writer.AddString(SfxId);
        }
    }
}
