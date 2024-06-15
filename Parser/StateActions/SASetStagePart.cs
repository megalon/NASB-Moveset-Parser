using MovesetParser.BulkSerialize;

namespace MovesetParser.StateActions
{
    public class SASetStagePart : StateAction, IBulkSerializer
    {
        public bool SetTo;
        public string PartId;

        public SASetStagePart() { }

        public new static SASetStagePart ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            return new SASetStagePart
            {
                TID = TypeId.SASetStagePart,
                SetTo = (reader.GetNextInt() > 0),
                PartId = reader.GetNextString()
            };
        }

        public override void WriteSerial(Writer writer)
        {
            writer.AddInt(58);
            writer.AddInt(0);

            writer.AddInt(SetTo ? 7 : 0);
            writer.AddString(PartId);
        }
    }
}
