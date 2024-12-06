using MovesetParser.BulkSerialize;

namespace MovesetParser.StateActions
{
    [Serializable]
    public class SAPlayCategoryVoiceLine : StateAction, IBulkSerializer
    {
        public string CategoryId;
        public bool CheckAvailableLines;

        public SAPlayCategoryVoiceLine() { }

        public new static SAPlayCategoryVoiceLine ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            var version = reader.GetNextInt();

            var playCategoryVoiceLine = new SAPlayCategoryVoiceLine
            {
                TID = TypeId.SAPlayCategoryVoiceLine,
                CategoryId = reader.GetNextString()
            };

            if (version > 0) playCategoryVoiceLine.CheckAvailableLines = reader.GetNextInt() == 1;

            return playCategoryVoiceLine;
        }

        public override void WriteSerial(Writer writer)
        {
            writer.AddInt(101);
            writer.AddInt(1);

            writer.AddString(CategoryId);
            writer.AddInt(CheckAvailableLines ? 1 : 0);
        }
    }
}
