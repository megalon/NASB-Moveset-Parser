using MovesetParser.BulkSerialize;
using MovesetParser.FloatSources;

namespace MovesetParser.StateActions
{
    [Serializable]
    public class SAConfigHitbox : StateAction, IBulkSerializer
    {
        public int Hitbox;
        public string Prop = string.Empty;
        public string Bone = string.Empty;
        public FloatSourceContainer Radius;
        public FloatSourceContainer LocalOffsetX;
        public FloatSourceContainer LocalOffsetY;
        public FloatSourceContainer LocalOffsetZ;
        public FloatSourceContainer WorldOffsetX;
        public FloatSourceContainer WorldOffsetY;
        public FloatSourceContainer WorldOffsetZ;
        public string FxId = string.Empty;
        public string SfxId = string.Empty;
        public bool Inactive;
        public bool SecondTrack;
        public string Bone2nd = string.Empty;
        public FloatSourceContainer LocalOffset2ndX;
        public FloatSourceContainer LocalOffset2ndY;
        public FloatSourceContainer LocalOffset2ndZ;
        public FloatSourceContainer WorldOffset2ndX;
        public FloatSourceContainer WorldOffset2ndY;
        public FloatSourceContainer WorldOffset2ndZ;

        public SAConfigHitbox() { }

        private void EnsureStuff()
        {
            Radius ??= new FloatSourceContainer(new FloatSource(1f));
            LocalOffsetX ??= new FloatSourceContainer(new FloatSource());
            LocalOffsetY ??= new FloatSourceContainer(new FloatSource());
            LocalOffsetZ ??= new FloatSourceContainer(new FloatSource());
            WorldOffsetX ??= new FloatSourceContainer(new FloatSource());
            WorldOffsetY ??= new FloatSourceContainer(new FloatSource());
            WorldOffsetZ ??= new FloatSourceContainer(new FloatSource());
            LocalOffset2ndX ??= new FloatSourceContainer(new FloatSource());
            LocalOffset2ndY ??= new FloatSourceContainer(new FloatSource());
            LocalOffset2ndZ ??= new FloatSourceContainer(new FloatSource());
            WorldOffset2ndX ??= new FloatSourceContainer(new FloatSource());
            WorldOffset2ndY ??= new FloatSourceContainer(new FloatSource());
            WorldOffset2ndZ ??= new FloatSourceContainer(new FloatSource());
        }

        public new static SAConfigHitbox ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            int version = reader.GetNextInt();

            SAConfigHitbox sAConfigHitbox = new SAConfigHitbox
            {
                TID = TypeId.SAConfigHitbox,
                Hitbox = reader.GetNextInt(),
                Inactive = reader.GetNextInt() > 0
            };

            if (version > 1)
            {
                sAConfigHitbox.Radius = FloatSourceContainer.ReadSerial(reader);
                sAConfigHitbox.LocalOffsetX = FloatSourceContainer.ReadSerial(reader);
                sAConfigHitbox.LocalOffsetY = FloatSourceContainer.ReadSerial(reader);
                sAConfigHitbox.LocalOffsetZ = FloatSourceContainer.ReadSerial(reader);
                sAConfigHitbox.WorldOffsetX = FloatSourceContainer.ReadSerial(reader);
                sAConfigHitbox.WorldOffsetY = FloatSourceContainer.ReadSerial(reader);
                sAConfigHitbox.WorldOffsetZ = FloatSourceContainer.ReadSerial(reader);
            }
            else
            {
                sAConfigHitbox.Radius = new FloatSourceContainer(new FloatSource(reader.GetNextFloat()));
                sAConfigHitbox.LocalOffsetX = new FloatSourceContainer(new FloatSource(reader.GetNextFloat()));
                sAConfigHitbox.LocalOffsetY = new FloatSourceContainer(new FloatSource(reader.GetNextFloat()));
                sAConfigHitbox.LocalOffsetZ = new FloatSourceContainer(new FloatSource(reader.GetNextFloat()));
                sAConfigHitbox.WorldOffsetX = new FloatSourceContainer(new FloatSource(reader.GetNextFloat()));
                sAConfigHitbox.WorldOffsetY = new FloatSourceContainer(new FloatSource(reader.GetNextFloat()));
                sAConfigHitbox.WorldOffsetZ = new FloatSourceContainer(new FloatSource(reader.GetNextFloat()));
            }

            sAConfigHitbox.Prop = reader.GetNextString();
            sAConfigHitbox.Bone = reader.GetNextString();
            sAConfigHitbox.FxId = reader.GetNextString();
            sAConfigHitbox.SfxId = reader.GetNextString();

            if (version == 0) return sAConfigHitbox;

            sAConfigHitbox.SecondTrack = reader.GetNextInt() > 0;

            if (sAConfigHitbox.SecondTrack)
            {
                sAConfigHitbox.Bone2nd = reader.GetNextString();

                if (version > 1)
                {
                    sAConfigHitbox.LocalOffset2ndX = FloatSourceContainer.ReadSerial(reader);
                    sAConfigHitbox.LocalOffset2ndY = FloatSourceContainer.ReadSerial(reader);
                    sAConfigHitbox.LocalOffset2ndZ = FloatSourceContainer.ReadSerial(reader);
                    sAConfigHitbox.WorldOffset2ndX = FloatSourceContainer.ReadSerial(reader);
                    sAConfigHitbox.WorldOffset2ndY = FloatSourceContainer.ReadSerial(reader);
                    sAConfigHitbox.WorldOffset2ndZ = FloatSourceContainer.ReadSerial(reader);
                }
                else
                {
                    sAConfigHitbox.LocalOffset2ndX = new FloatSourceContainer(new FloatSource(reader.GetNextFloat()));
                    sAConfigHitbox.LocalOffset2ndY = new FloatSourceContainer(new FloatSource(reader.GetNextFloat()));
                    sAConfigHitbox.LocalOffset2ndZ = new FloatSourceContainer(new FloatSource(reader.GetNextFloat()));
                    sAConfigHitbox.WorldOffset2ndX = new FloatSourceContainer(new FloatSource(reader.GetNextFloat()));
                    sAConfigHitbox.WorldOffset2ndY = new FloatSourceContainer(new FloatSource(reader.GetNextFloat()));
                    sAConfigHitbox.WorldOffset2ndZ = new FloatSourceContainer(new FloatSource(reader.GetNextFloat()));
                }
            }

            return sAConfigHitbox;
        }

        public override void WriteSerial(Writer writer)
        {
            EnsureStuff();

            writer.AddInt(26);
            writer.AddInt(2);

            writer.AddInt(Hitbox);
            writer.AddInt(Inactive ? 7 : 0);

            Radius.WriteSerial(writer);
            LocalOffsetX.WriteSerial(writer);
            LocalOffsetY.WriteSerial(writer);
            LocalOffsetZ.WriteSerial(writer);
            WorldOffsetX.WriteSerial(writer);
            WorldOffsetY.WriteSerial(writer);
            WorldOffsetZ.WriteSerial(writer);

            writer.AddString(Prop);
            writer.AddString(Bone);
            writer.AddString(FxId);
            writer.AddString(SfxId);

            writer.AddInt(SecondTrack ? 7 : 0);

            if (SecondTrack)
            {
                writer.AddString(Bone2nd);
                LocalOffset2ndX.WriteSerial(writer);
                LocalOffset2ndY.WriteSerial(writer);
                LocalOffset2ndZ.WriteSerial(writer);
                WorldOffset2ndX.WriteSerial(writer);
                WorldOffset2ndY.WriteSerial(writer);
                WorldOffset2ndZ.WriteSerial(writer);
            }
        }
    }
}
