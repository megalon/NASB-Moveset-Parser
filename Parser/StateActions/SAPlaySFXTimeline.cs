using MovesetParser.BulkSerialize;
using MovesetParser.FloatSources;

namespace MovesetParser.StateActions
{
    public class SAPlaySFXTimeline : StateAction
    {
        public ManipType Manip;
        public string Timeline;
        public FloatSourceContainer Value;
        public bool Loop;

        public SAPlaySFXTimeline() { }

        private void EnsureStuff()
        {
            Value ??= new FloatSourceContainer(new FloatSource(1f));
        }

        public new static SAPlaySFXTimeline ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            return new SAPlaySFXTimeline
            {
                TID = TypeId.SAPlaySFXTimeline,
                Manip = (ManipType)reader.GetNextInt(),
                Loop = (reader.GetNextInt() > 0),
                Value = FloatSourceContainer.ReadSerial(reader),
                Timeline = reader.GetNextString()
            };
        }

        public override void WriteSerial(Writer writer)
        {
            EnsureStuff();

            writer.AddInt(65);
            writer.AddInt(0);

            writer.AddInt((int)Manip);
            writer.AddInt(Loop ? 7 : 0);
            Value.WriteSerial(writer);
            writer.AddString(Timeline);
        }

        public enum ManipType
        {
            Play,
            Rate,
            Position
        }
    }
}
