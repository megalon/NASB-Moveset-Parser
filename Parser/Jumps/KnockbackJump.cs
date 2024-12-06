using MovesetParser.BulkSerialize;
using MovesetParser.FloatSources;

namespace MovesetParser.Jumps
{
    [Serializable]
    public class KnockbackJump : Jump, IBulkSerializer
    {
        public FloatSourceContainer XDir;
        public FloatSourceContainer YDir;
        public FloatSourceContainer LaunchDistance;
        public FloatSourceContainer Frames;
        public bool DoLaunch;
        public FloatSourceContainer BounceMinVelocity;

        public KnockbackJump() { }

        private void EnsureStuff()
        {
            XDir ??= new FloatSourceContainer(new FloatSource());
            YDir ??= new FloatSourceContainer(new FloatSource());
            LaunchDistance ??= new FloatSourceContainer(new FloatSource());
            Frames ??= new FloatSourceContainer(new FloatSource());
            BounceMinVelocity ??= new FloatSourceContainer(new FloatSource());
        }

        public new static KnockbackJump ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            var version = reader.GetNextInt();

            KnockbackJump knockbackJump = new KnockbackJump
            {
                TID = TypeId.KnockbackJump,
                XDir = FloatSourceContainer.ReadSerial(reader),
                YDir = FloatSourceContainer.ReadSerial(reader),
                LaunchDistance = FloatSourceContainer.ReadSerial(reader),
                Frames = FloatSourceContainer.ReadSerial(reader)
            };

            if (version <= 2)
            {
                FloatSourceContainer.ReadSerial(reader);
                FloatSourceContainer.ReadSerial(reader);
                FloatSourceContainer.ReadSerial(reader);
            }

            if (version == 0)
                return knockbackJump;

            knockbackJump.DoLaunch = reader.GetNextInt() > 0;

            if (version == 1)
                return knockbackJump;

            knockbackJump.BounceMinVelocity = FloatSourceContainer.ReadSerial(reader);

            return knockbackJump;
        }

        public override void WriteSerial(Writer writer)
        {
            EnsureStuff();

            writer.AddInt(4);
            writer.AddInt(3);

            XDir.WriteSerial(writer);
            YDir.WriteSerial(writer);
            LaunchDistance.WriteSerial(writer);
            Frames.WriteSerial(writer);
            writer.AddInt(DoLaunch ? 7 : 0);
            BounceMinVelocity.WriteSerial(writer);
        }
    }
}
