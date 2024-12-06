using MovesetParser.BulkSerialize;

namespace MovesetParser.StateActions
{
    [Serializable]
    public class SAUpdateHurtboxes : StateAction, IBulkSerializer
    {
        public SAUpdateHurtboxes() { }

        public new static SAUpdateHurtboxes ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            return new SAUpdateHurtboxes()
            {
                TID = TypeId.SAUpdateHurtboxes
            };
        }

        public override void WriteSerial(Writer writer)
        {
            writer.AddInt(29);
            writer.AddInt(0);
        }
    }
}
