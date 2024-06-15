using MovesetParser.BulkSerialize;

namespace MovesetParser.StateActions
{
    public class SAPlayVoiceLine : StateAction, IBulkSerializer
    {
        public string LineId;

        public SAPlayVoiceLine() { }

        public new static SAPlayVoiceLine ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            return new SAPlayVoiceLine
            {
                TID = TypeId.SAPlayVoiceLine,
                LineId = reader.GetNextString()
            };
        }

        public override void WriteSerial(Writer writer)
        {
            writer.AddInt(100);
            writer.AddInt(0);

            writer.AddString(LineId);
        }
    }
}
