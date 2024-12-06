using MovesetParser.BulkSerialize;
using MovesetParser.Misc;

namespace MovesetParser.StateActions
{
    [Serializable]
    public class SAFindLastHorizontalInput : StateAction, IBulkSerializer
    {
        public Search Search;
        public Stick Stick;
        public int ResultInScratch;
        public int DurationFrames;

        public SAFindLastHorizontalInput() { }

        public new static SAFindLastHorizontalInput ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            var version = reader.GetNextInt();

            SAFindLastHorizontalInput sAFindLastHorizontalInput = new SAFindLastHorizontalInput
            {
                TID = TypeId.SAFindLastHorizontalInput,
                Search = (Search)reader.GetNextInt(),
                ResultInScratch = reader.GetNextInt()
            };

            if (version < 1) return sAFindLastHorizontalInput;

            sAFindLastHorizontalInput.Stick = (Stick)reader.GetNextInt();
            sAFindLastHorizontalInput.DurationFrames = reader.GetNextInt();

            return sAFindLastHorizontalInput;
        }

        public override void WriteSerial(Writer writer)
        {
            writer.AddInt(66);
            writer.AddInt(1);

            writer.AddInt((int)Search);
            writer.AddInt(ResultInScratch);
            writer.AddInt((int)Stick);
            writer.AddInt(DurationFrames);
        }
    }
}
