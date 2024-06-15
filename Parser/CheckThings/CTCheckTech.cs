using MovesetParser.BulkSerialize;

namespace MovesetParser.CheckThings
{
    public class CTCheckTech : CheckThing, IBulkSerializer
    {
        public string TechTimerID;

        public CTCheckTech() { }

        public new static CTCheckTech ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();
            return new CTCheckTech
            {
                TID = TypeId.CTCheckTech,
                TechTimerID = reader.GetNextString()
            };
        }

        public override void WriteSerial(Writer writer)
        {
            writer.AddInt(6);
            writer.AddInt(0);
            writer.AddString(TechTimerID);
        }
    }
}
