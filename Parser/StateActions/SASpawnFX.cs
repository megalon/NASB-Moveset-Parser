using MovesetParser.BulkSerialize;
using MovesetParser.FloatSources;

namespace MovesetParser.StateActions
{
    public class SASpawnFX : StateAction, IBulkSerializer
    {
        public string Id = string.Empty;
        public string Bone = string.Empty;
        public FloatSourceContainer LocalOffsetX;
        public FloatSourceContainer LocalOffsetY;
        public FloatSourceContainer LocalOffsetZ;
        public FloatSourceContainer WorldOffsetX;
        public FloatSourceContainer WorldOffsetY;
        public FloatSourceContainer WorldOffsetZ;
        public FloatSourceContainer DirX;
        public FloatSourceContainer DirY;
        public FloatSourceContainer DirZ;
        public FloatSourceContainer Scale;
        public bool Dynamic;
        public FloatSourceContainer DynamicX;
        public FloatSourceContainer DynamicY;
        public FloatSourceContainer DynamicZ;
        public bool Track;
        public bool BoneDirection;

        public SASpawnFX() { }

        private void EnsureStuff()
        {
            LocalOffsetX ??= new FloatSourceContainer(new FloatSource());
            LocalOffsetY ??= new FloatSourceContainer(new FloatSource());
            LocalOffsetZ ??= new FloatSourceContainer(new FloatSource());
            WorldOffsetX ??= new FloatSourceContainer(new FloatSource());
            WorldOffsetY ??= new FloatSourceContainer(new FloatSource());
            WorldOffsetZ ??= new FloatSourceContainer(new FloatSource());
            DirX ??= new FloatSourceContainer(new FloatSource());
            DirY ??= new FloatSourceContainer(new FloatSource());
            DirZ ??= new FloatSourceContainer(new FloatSource());
            DynamicX ??= new FloatSourceContainer(new FloatSource());
            DynamicY ??= new FloatSourceContainer(new FloatSource());
            DynamicZ ??= new FloatSourceContainer(new FloatSource());
            Scale ??= new FloatSourceContainer(new FloatSource(1f));
        }

        public new static SASpawnFX ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            var version = reader.GetNextInt();

            var spawnFX = new SASpawnFX
            {
                TID = TypeId.SASpawnFX,
                Dynamic = (reader.GetNextInt() > 0),
                Track = (reader.GetNextInt() > 0),
                BoneDirection = (reader.GetNextInt() > 0),
                Id = reader.GetNextString(),
                Bone = reader.GetNextString()
            };

            if (version > 0)
            {
                spawnFX.LocalOffsetX = FloatSourceContainer.ReadSerial(reader);
                spawnFX.LocalOffsetY = FloatSourceContainer.ReadSerial(reader);
                spawnFX.LocalOffsetZ = FloatSourceContainer.ReadSerial(reader);
                spawnFX.WorldOffsetX = FloatSourceContainer.ReadSerial(reader);
                spawnFX.WorldOffsetY = FloatSourceContainer.ReadSerial(reader);
                spawnFX.WorldOffsetZ = FloatSourceContainer.ReadSerial(reader);
            }
            else
            {
                spawnFX.LocalOffsetX = new FloatSourceContainer(new FloatSource(reader.GetNextFloat()));
                spawnFX.LocalOffsetY = new FloatSourceContainer(new FloatSource(reader.GetNextFloat()));
                spawnFX.LocalOffsetZ = new FloatSourceContainer(new FloatSource(reader.GetNextFloat()));
                spawnFX.WorldOffsetX = new FloatSourceContainer(new FloatSource(reader.GetNextFloat()));
                spawnFX.WorldOffsetY = new FloatSourceContainer(new FloatSource(reader.GetNextFloat()));
                spawnFX.WorldOffsetZ = new FloatSourceContainer(new FloatSource(reader.GetNextFloat()));
            }

            spawnFX.DirX = FloatSourceContainer.ReadSerial(reader);
            spawnFX.DirY = FloatSourceContainer.ReadSerial(reader);
            spawnFX.DirZ = FloatSourceContainer.ReadSerial(reader);
            spawnFX.DynamicX = FloatSourceContainer.ReadSerial(reader);
            spawnFX.DynamicY = FloatSourceContainer.ReadSerial(reader);
            spawnFX.DynamicZ = FloatSourceContainer.ReadSerial(reader);
            spawnFX.Scale = FloatSourceContainer.ReadSerial(reader);

            return spawnFX;
        }

        public override void WriteSerial(Writer writer)
        {
            EnsureStuff();

            writer.AddInt(36);
            writer.AddInt(1);

            writer.AddInt(Dynamic ? 7 : 0);
            writer.AddInt(Track ? 7 : 0);
            writer.AddInt(BoneDirection ? 7 : 0);
            writer.AddString(Id);
            writer.AddString(Bone);

            LocalOffsetX.WriteSerial(writer);
            LocalOffsetY.WriteSerial(writer);
            LocalOffsetZ.WriteSerial(writer);
            WorldOffsetX.WriteSerial(writer);
            WorldOffsetY.WriteSerial(writer);
            WorldOffsetZ.WriteSerial(writer);

            DirX.WriteSerial(writer);
            DirY.WriteSerial(writer);
            DirZ.WriteSerial(writer);
            DynamicX.WriteSerial(writer);
            DynamicY.WriteSerial(writer);
            DynamicZ.WriteSerial(writer);

            Scale.WriteSerial(writer);
        }
    }
}
