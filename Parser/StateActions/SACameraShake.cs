using MovesetParser.BulkSerialize;
using MovesetParser.FloatSources;

namespace MovesetParser.StateActions
{
    [Serializable]
    public class SACameraShake : StateAction, IBulkSerializer
    {
        public FloatSourceContainer Shake;
        public FloatSourceContainer Intensity;

        public SACameraShake() { }

        private void EnsureStuff()
        {
            Shake ??= new FloatSourceContainer(new FloatSource());
            Intensity ??= new FloatSourceContainer(new FloatSource(1f));
        }

        public new static SACameraShake ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            var version = reader.GetNextInt();

            var sACameraShake = new SACameraShake()
            {
                TID = TypeId.SACameraShake
            };

            if (version > 1)
            {
                sACameraShake.Shake = FloatSourceContainer.ReadSerial(reader);
                sACameraShake.Intensity = FloatSourceContainer.ReadSerial(reader);
            }
            else
            {
                sACameraShake.Shake = new FloatSourceContainer(new FloatSource(reader.GetNextFloat()));
                sACameraShake.Intensity = new FloatSourceContainer(new FloatSource((version > 0) ? reader.GetNextFloat() : 1f));
            }

            return sACameraShake;
        }

        public override void WriteSerial(Writer writer)
        {
            EnsureStuff();

            writer.AddInt(50);
            writer.AddInt(2);

            Shake.WriteSerial(writer);
            Intensity.WriteSerial(writer);
        }
    }
}
