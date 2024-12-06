using MovesetParser.BulkSerialize;

namespace MovesetParser.StateActions
{
    [Serializable]
    public class SASetHitboxCount : StateAction, IBulkSerializer
    {
        public int HitBoxes;

        public SASetHitboxCount() { }

        public new static SASetHitboxCount ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            return new SASetHitboxCount
            {
                TID = TypeId.SASetHitboxCount,
                HitBoxes = reader.GetNextInt()
            };
        }

        public override void WriteSerial(Writer writer)
        {
            writer.AddInt(25);
            writer.AddInt(0);

            writer.AddInt(HitBoxes);
        }
    }
}
