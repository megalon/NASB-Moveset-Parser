using MovesetParser.BulkSerialize;
using MovesetParser.FloatSources;

namespace MovesetParser.Jumps
{
    [Serializable]
    public class HoldJump : Jump, IBulkSerializer
    {
        public FloatSourceContainer Height;
        public FloatSourceContainer AutoHoldFrames;
        public FloatSourceContainer YVelocityMaxOnRelease;

        public HoldJump() { }

        private void EnsureStuff()
        {
            Height ??= new FloatSourceContainer(new FloatSource(5f));
            AutoHoldFrames ??= new FloatSourceContainer(new FloatSource(3f));
            YVelocityMaxOnRelease ??= new FloatSourceContainer(new FloatSource(5f));
        }

        public new static HoldJump ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            return new HoldJump
            {
                TID = TypeId.HoldJump,
                Height = FloatSourceContainer.ReadSerial(reader),
                AutoHoldFrames = FloatSourceContainer.ReadSerial(reader),
                YVelocityMaxOnRelease = FloatSourceContainer.ReadSerial(reader)
            };
        }

        public override void WriteSerial(Writer writer)
        {
            EnsureStuff();

            writer.AddInt(2);
            writer.AddInt(0);

            Height.WriteSerial(writer);
            AutoHoldFrames.WriteSerial(writer);
            YVelocityMaxOnRelease.WriteSerial(writer);
        }
    }
}
