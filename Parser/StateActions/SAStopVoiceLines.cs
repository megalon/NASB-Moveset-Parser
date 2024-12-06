using MovesetParser.BulkSerialize;

namespace MovesetParser.StateActions
{
    [Serializable]
    public class SAStopVoiceLines : StateAction, IBulkSerializer
    {
        public string CategoryId;

        public SAStopVoiceLines() { }

        public new static SAStopVoiceLines ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            var version = reader.GetNextInt();

            var stopVoiceLines = new SAStopVoiceLines()
            {
                TID = TypeId.SAStopVoiceLines
            };

            if (version > 0) stopVoiceLines.CategoryId = reader.GetNextString();

            return stopVoiceLines;
        }

        public override void WriteSerial(Writer writer)
        {
            writer.AddInt(102);
            writer.AddInt(1);

            writer.AddString(CategoryId);
        }
    }
}
