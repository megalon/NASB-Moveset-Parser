using MovesetParser.BulkSerialize;

namespace MovesetParser.CheckThings
{
    public class CTGrab : CheckThing, IBulkSerializer
    {
        public CheckType Type;

        public CTGrab() { }

        public new static CTGrab ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();
            return new CTGrab
            {
                TID = TypeId.CTGrab,
                Type = (CheckType)reader.GetNextInt()
            };
        }

        public override void WriteSerial(Writer writer)
        {
            writer.AddInt(7);
            writer.AddInt(0);
            writer.AddInt((int)Type);
        }

        public enum CheckType
        {
            InGrab,
            IsGrabber,
            IsGrabbed,
            AllowedToEscape
        }
    }
}
