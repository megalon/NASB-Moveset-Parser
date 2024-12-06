using MovesetParser.BulkSerialize;

namespace MovesetParser.StateActions
{
    [Serializable]
    public class SASetHitboxFX : StateAction, IBulkSerializer
    {
        public int HitBox;
        public string FxId = string.Empty;

        public SASetHitboxFX() { }

        public new static SASetHitboxFX ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            return new SASetHitboxFX
            {
                TID = TypeId.SASetHitboxFX,
                HitBox = reader.GetNextInt(),
                FxId = reader.GetNextString()
            };
        }

        public override void WriteSerial(Writer writer)
        {
            writer.AddInt(37);
            writer.AddInt(0);

            writer.AddInt(HitBox);
            writer.AddString(FxId);
        }
    }
}
