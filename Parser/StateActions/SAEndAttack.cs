using MovesetParser.BulkSerialize;

namespace MovesetParser.StateActions
{
    public class SAEndAttack : StateAction, IBulkSerializer
    {
        public SAEndAttack() { }

        public new static SAEndAttack ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            return new SAEndAttack()
            {
                TID = TypeId.SAEndAttack
            };
        }

        public override void WriteSerial(Writer writer)
        {
            writer.AddInt(24);
            writer.AddInt(0);
        }
    }
}
