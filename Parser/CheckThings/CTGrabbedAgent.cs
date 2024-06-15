using MovesetParser.BulkSerialize;

namespace MovesetParser.CheckThings
{
    public class CTGrabbedAgent : CheckThing, IBulkSerializer
    {
        public int MatchTagsCount;
        public string[] MatchTags;

        public CTGrabbedAgent() { }

        public new static CTGrabbedAgent ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            var cTGrabbedAgent = new CTGrabbedAgent
            {
                TID = TypeId.CTGrabbedAgent,
                MatchTagsCount = reader.GetNextInt()
            };

            var matchTagsCount = reader.GetNextInt();
            cTGrabbedAgent.MatchTags = new string[matchTagsCount];

            for (int i = 0; i < matchTagsCount; i++)
            {
                cTGrabbedAgent.MatchTags[i] = reader.GetNextString();
            }

            return cTGrabbedAgent;
        }

        public override void WriteSerial(Writer writer)
        {
            writer.AddInt(8);
            writer.AddInt(0);

            writer.AddInt(MatchTagsCount);

            MatchTags ??= new string[0];
            writer.AddInt(MatchTags.Length);

            for (int i = 0; i < MatchTags.Length; i++)
            {
                writer.AddString(MatchTags[i]);
            }
        }
    }
}
