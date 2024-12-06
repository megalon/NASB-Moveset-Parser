using MovesetParser.BulkSerialize;

namespace MovesetParser.CheckThings
{
    [Serializable]
    public class CTMultiple : CheckThing, IBulkSerializer
    {
        public CheckMatch Match = CheckMatch.All;
        public CheckThing[] Checklist;

        public CTMultiple() { }

        public new static CTMultiple ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            var cTMultiple = new CTMultiple
            {
                TID = TypeId.CTMultiple,
                Match = (CheckMatch)reader.GetNextInt()
            };

            int checkThingCount = reader.GetNextInt();
            cTMultiple.Checklist = new CheckThing[checkThingCount];

            for (int i = 0; i < checkThingCount; i++)
            {
                cTMultiple.Checklist[i] = CheckThing.ReadSerial(reader);
            }

            return cTMultiple;
        }

        public override void WriteSerial(Writer writer)
        {
            writer.AddInt(1);
            writer.AddInt(0);

            writer.AddInt((int)Match);

            Checklist ??= new CheckThing[0];

            writer.AddInt(Checklist.Length);
            for (int i = 0; i < Checklist.Length; i++)
            {
                Checklist[i] ??= new CheckThing();
                Checklist[i].WriteSerial(writer);
            }
        }

        public enum CheckMatch
        {
            Any,
            All,
            One,
            None
        }
    }
}
