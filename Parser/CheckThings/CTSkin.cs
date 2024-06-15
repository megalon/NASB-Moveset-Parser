using MovesetParser.BulkSerialize;

namespace MovesetParser.CheckThings
{
    public class CTSkin : CheckThing, IBulkSerializer
    {
        public string MatchSkin;
        public bool MatchColor;
        public int MatchAgainstColor;

        public CTSkin() { }

        public new static CTSkin ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            return new CTSkin
            {
                TID = TypeId.CTSkin,
                MatchSkin = reader.GetNextString(),
                MatchColor = (reader.GetNextInt() > 0),
                MatchAgainstColor = reader.GetNextInt()
            };
        }

        public override void WriteSerial(Writer writer)
        {
            writer.AddInt(9);
            writer.AddInt(0);

            writer.AddString(MatchSkin);
            writer.AddInt(MatchColor ? 7 : 0);
            writer.AddInt(MatchAgainstColor);
        }
    }
}
