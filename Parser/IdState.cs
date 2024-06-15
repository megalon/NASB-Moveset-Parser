using MovesetParser.BulkSerialize;

namespace MovesetParser
{
    public class IdState : IBulkSerializer
    {
        public string Id;
        public string[] Tags;
        public AgentState State;

        public IdState() { }
        public IdState(Reader reader)
        {
            reader.GetNextInt();
            Id = reader.GetNextString();

            var tagsCount = reader.GetNextInt();
            Tags = new string[tagsCount];

            for (int i = 0; i < tagsCount; i++)
            {
                Tags[i] = reader.GetNextString();
            }

            State = AgentState.ReadSerial(reader);
        }

        public void WriteSerial(Writer writer)
        {
            writer.AddInt(0);
            writer.AddString(Id);

            Tags ??= new string[0];

            var count = Tags.Length;
            writer.AddInt(count);

            for (int i = 0; i < count; i++)
            {
                writer.AddString(Tags[i]);
            }

            State ??= new();

            State.WriteSerial(writer);
        }
    }
}
