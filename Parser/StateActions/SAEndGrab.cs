using MovesetParser.BulkSerialize;

namespace MovesetParser.StateActions
{
    [Serializable]
    public class SAEndGrab : StateAction, IBulkSerializer
    {
        public SAEndGrab() { }

        public new static SAEndGrab ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            return new SAEndGrab()
            {
                TID = TypeId.SAEndGrab
            };
        }

        public override void WriteSerial(Writer writer)
        {
            writer.AddInt(45);
            writer.AddInt(0);
        }
    }
}
