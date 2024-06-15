using MovesetParser.BulkSerialize;
using MovesetParser.FloatSources;

namespace MovesetParser.Misc
{
    public class SpawnMovement : IBulkSerializer
    {
        public string toBone = string.Empty;
        public FloatSourceContainer localOffsetX;
        public FloatSourceContainer localOffsetY;
        public FloatSourceContainer localOffsetZ;
        public FloatSourceContainer worldOffsetX;
        public FloatSourceContainer worldOffsetY;
        public FloatSourceContainer worldOffsetZ;
        public MovementConfig cfg = new MovementConfig();

        public SpawnMovement() { }

        private void EnsureStuff()
        {
            localOffsetX ??= new FloatSourceContainer(new FloatSource());
            localOffsetY ??= new FloatSourceContainer(new FloatSource());
            localOffsetZ ??= new FloatSourceContainer(new FloatSource());
            worldOffsetX ??= new FloatSourceContainer(new FloatSource());
            worldOffsetY ??= new FloatSourceContainer(new FloatSource());
            worldOffsetZ ??= new FloatSourceContainer(new FloatSource());
        }

        public void ReadSerial(Reader reader)
        {
            var version = reader.GetNextInt();
            toBone = reader.GetNextString();

            if (version > 0)
            {
                localOffsetX = FloatSourceContainer.ReadSerial(reader);
                localOffsetY = FloatSourceContainer.ReadSerial(reader);
                localOffsetZ = FloatSourceContainer.ReadSerial(reader);
                worldOffsetX = FloatSourceContainer.ReadSerial(reader);
                worldOffsetY = FloatSourceContainer.ReadSerial(reader);
                worldOffsetZ = FloatSourceContainer.ReadSerial(reader);
            }
            else
            {
                localOffsetX = new FloatSourceContainer(new FloatSource(reader.GetNextFloat()));
                localOffsetY = new FloatSourceContainer(new FloatSource(reader.GetNextFloat()));
                localOffsetZ = new FloatSourceContainer(new FloatSource(reader.GetNextFloat()));
                worldOffsetX = new FloatSourceContainer(new FloatSource(reader.GetNextFloat()));
                worldOffsetY = new FloatSourceContainer(new FloatSource(reader.GetNextFloat()));
                worldOffsetZ = new FloatSourceContainer(new FloatSource(reader.GetNextFloat()));
            }

            cfg.ReadSerial(reader);
        }

        public void WriteSerial(Writer writer)
        {
            EnsureStuff();

            writer.AddInt(1);

            writer.AddString(toBone);
            localOffsetX.WriteSerial(writer);
            localOffsetY.WriteSerial(writer);
            localOffsetZ.WriteSerial(writer);
            worldOffsetX.WriteSerial(writer);
            worldOffsetY.WriteSerial(writer);
            worldOffsetZ.WriteSerial(writer);
            cfg.WriteSerial(writer);
        }
    }
}
