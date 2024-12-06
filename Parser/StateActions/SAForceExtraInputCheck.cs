using MovesetParser.BulkSerialize;

namespace MovesetParser.StateActions
{
    [Serializable]
    public class SAForceExtraInputCheck : StateAction, IBulkSerializer
    {
        public SAForceExtraInputCheck() { }

        public new static SAForceExtraInputCheck ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            return new SAForceExtraInputCheck()
            {
                TID = TypeId.SAForceExtraInputCheck
            };
        }

        public override void WriteSerial(Writer writer)
        {
            writer.AddInt(73);
            writer.AddInt(0);
        }
    }
}
