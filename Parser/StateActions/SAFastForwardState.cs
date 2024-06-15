using MovesetParser.BulkSerialize;
using MovesetParser.FloatSources;

namespace MovesetParser.StateActions
{
    public class SAFastForwardState : StateAction, IBulkSerializer
    {
        public FloatSourceContainer Frames;

        public SAFastForwardState() { }

        private void EnsureStuff()
        {
             Frames ??= new FloatSourceContainer(new FloatSource());
        }

        public new static SAFastForwardState ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            return new SAFastForwardState
            {
                TID = TypeId.SAFastForwardState,
                Frames = FloatSourceContainer.ReadSerial(reader)
            };
        }

        public override void WriteSerial(Writer writer)
        {
            EnsureStuff();

            writer.AddInt(53);
            writer.AddInt(0);

            Frames.WriteSerial(writer);
        }
    }
}
