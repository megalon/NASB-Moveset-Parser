using MovesetParser.BulkSerialize;

namespace MovesetParser.StateActions
{
    [Serializable]
    public class SAUpdateHitboxes : StateAction, IBulkSerializer
    {
        public SAUpdateHitboxes() { }

        public new static SAUpdateHitboxes ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            return new SAUpdateHitboxes()
            {
                TID = TypeId.SAUpdateHitboxes
            };
        }

        public override void WriteSerial(Writer writer)
        {
            writer.AddInt(71);
            writer.AddInt(0);
        }
    }
}
