using MovesetParser.BulkSerialize;

namespace MovesetParser.StateActions
{
    public class SARefreshAttack : StateAction, IBulkSerializer
    {
        public SARefreshAttack() { }

        public new static SARefreshAttack ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            return new SARefreshAttack()
            {
                TID = TypeId.SARefreshAttack
            };
        }

        public override void WriteSerial(Writer writer)
        {
            writer.AddInt(23);
            writer.AddInt(0);
        }
    }
}
