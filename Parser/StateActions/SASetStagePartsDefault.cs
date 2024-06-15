using MovesetParser.BulkSerialize;

namespace MovesetParser.StateActions
{
    public class SASetStagePartsDefault : StateAction, IBulkSerializer
    {
        public SASetStagePartsDefault() { }

        public new static SASetStagePartsDefault ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            return new SASetStagePartsDefault()
            {
                TID = TypeId.SASetStagePartsDefault
            };
        }

        public override void WriteSerial(Writer writer)
        {
            writer.AddInt(59);
            writer.AddInt(0);
        }
    }
}
