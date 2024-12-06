using MovesetParser.BulkSerialize;
using MovesetParser.FloatSources;

namespace MovesetParser.Misc
{
    [Serializable]
    public class HurtSetSetup : IBulkSerializer
    {
        public HurtBone[] HurtBones;

        public HurtSetSetup() { }

        private void EnsureStuff()
        {
            HurtBones ??= new HurtBone[0];
            for (int i = 0; i < HurtBones.Length; i++)
            {
                HurtBones[i] ??= new HurtBone();
            }
        }

        public static HurtSetSetup ReadSerial(Reader reader)
        {
            reader.GetNextInt();

            var hurtSetSetup = new HurtSetSetup();

            var version = reader.GetNextInt();
            hurtSetSetup.HurtBones = new HurtBone[version];

            for (int i = 0; i < version; i++)
            {
                hurtSetSetup.HurtBones[i] = HurtBone.ReadSerial(reader);
            }

            return hurtSetSetup;
        }

        public void WriteSerial(Writer w)
        {
            EnsureStuff();

            w.AddInt(0);

            w.AddInt(HurtBones.Length);

            for (int i = 0; i < HurtBones.Length; i++)
            {
                HurtBones[i].WriteSerial(w);
            }
        }

    [Serializable]
    public class HurtBone : IBulkSerializer
        {
            public HurtType type;
            public FloatSourceContainer armor;
            public FloatSourceContainer knockbackarmor;
            public FloatSourceContainer radius;
            public bool ignoregrab;
            public string bone_a = string.Empty;
            public string bone_b = string.Empty;
            public FloatSourceContainer localOffsetAX;
            public FloatSourceContainer localOffsetAY;
            public FloatSourceContainer localOffsetAZ;
            public FloatSourceContainer worldOffsetAX;
            public FloatSourceContainer worldOffsetAY;
            public FloatSourceContainer worldOffsetAZ;
            public FloatSourceContainer localOffsetBX;
            public FloatSourceContainer localOffsetBY;
            public FloatSourceContainer localOffsetBZ;
            public FloatSourceContainer worldOffsetBX;
            public FloatSourceContainer worldOffsetBY;
            public FloatSourceContainer worldOffsetBZ;

            public HurtBone() { }

            private void EnsureStuff()
            {
                armor ??= new FloatSourceContainer(new FloatSource());
                knockbackarmor ??= new FloatSourceContainer(new FloatSource());
                radius ??= new FloatSourceContainer(new FloatSource(1f));
                localOffsetAX ??= new FloatSourceContainer(new FloatSource());
                localOffsetAY ??= new FloatSourceContainer(new FloatSource());
                localOffsetAZ ??= new FloatSourceContainer(new FloatSource());
                worldOffsetAX ??= new FloatSourceContainer(new FloatSource());
                worldOffsetAY ??= new FloatSourceContainer(new FloatSource());
                worldOffsetAZ ??= new FloatSourceContainer(new FloatSource());
                localOffsetBX ??= new FloatSourceContainer(new FloatSource());
                localOffsetBY ??= new FloatSourceContainer(new FloatSource());
                localOffsetBZ ??= new FloatSourceContainer(new FloatSource());
                worldOffsetBX ??= new FloatSourceContainer(new FloatSource());
                worldOffsetBY ??= new FloatSourceContainer(new FloatSource());
                worldOffsetBZ ??= new FloatSourceContainer(new FloatSource());
            }

            public static HurtBone ReadSerial(Reader r)
            {
                var version = r.GetNextInt();

                HurtBone hurtBone = new HurtBone();

                hurtBone.type = (HurtType)r.GetNextInt();

                if (version > 1)
                {
                    hurtBone.armor = FloatSourceContainer.ReadSerial(r);
                    hurtBone.knockbackarmor = FloatSourceContainer.ReadSerial(r);
                }
                else
                {
                    hurtBone.armor = new FloatSourceContainer(new FloatSource(r.GetNextInt()));
                    hurtBone.knockbackarmor = new FloatSourceContainer(new FloatSource((version > 0) ? r.GetNextInt() : 0));
                }

                hurtBone.ignoregrab = r.GetNextInt() > 0;
                hurtBone.bone_a = r.GetNextString();
                hurtBone.bone_b = r.GetNextString();

                if (version > 1)
                {
                    hurtBone.radius = FloatSourceContainer.ReadSerial(r);
                    hurtBone.localOffsetAX = FloatSourceContainer.ReadSerial(r);
                    hurtBone.localOffsetAY = FloatSourceContainer.ReadSerial(r);
                    hurtBone.localOffsetAZ = FloatSourceContainer.ReadSerial(r);
                    hurtBone.worldOffsetAX = FloatSourceContainer.ReadSerial(r);
                    hurtBone.worldOffsetAY = FloatSourceContainer.ReadSerial(r);
                    hurtBone.worldOffsetAZ = FloatSourceContainer.ReadSerial(r);
                    hurtBone.localOffsetBX = FloatSourceContainer.ReadSerial(r);
                    hurtBone.localOffsetBY = FloatSourceContainer.ReadSerial(r);
                    hurtBone.localOffsetBZ = FloatSourceContainer.ReadSerial(r);
                    hurtBone.worldOffsetBX = FloatSourceContainer.ReadSerial(r);
                    hurtBone.worldOffsetBY = FloatSourceContainer.ReadSerial(r);
                    hurtBone.worldOffsetBZ = FloatSourceContainer.ReadSerial(r);
                }
                else
                {
                    hurtBone.radius = new FloatSourceContainer(new FloatSource(r.GetNextFloat()));
                    hurtBone.localOffsetAX = new FloatSourceContainer(new FloatSource(r.GetNextFloat()));
                    hurtBone.localOffsetAY = new FloatSourceContainer(new FloatSource(r.GetNextFloat()));
                    hurtBone.localOffsetAZ = new FloatSourceContainer(new FloatSource(r.GetNextFloat()));
                    hurtBone.worldOffsetAX = new FloatSourceContainer(new FloatSource(r.GetNextFloat()));
                    hurtBone.worldOffsetAY = new FloatSourceContainer(new FloatSource(r.GetNextFloat()));
                    hurtBone.worldOffsetAZ = new FloatSourceContainer(new FloatSource(r.GetNextFloat()));
                    hurtBone.localOffsetBX = new FloatSourceContainer(new FloatSource(r.GetNextFloat()));
                    hurtBone.localOffsetBY = new FloatSourceContainer(new FloatSource(r.GetNextFloat()));
                    hurtBone.localOffsetBZ = new FloatSourceContainer(new FloatSource(r.GetNextFloat()));
                    hurtBone.worldOffsetBX = new FloatSourceContainer(new FloatSource(r.GetNextFloat()));
                    hurtBone.worldOffsetBY = new FloatSourceContainer(new FloatSource(r.GetNextFloat()));
                    hurtBone.worldOffsetBZ = new FloatSourceContainer(new FloatSource(r.GetNextFloat()));
                }

                return hurtBone;
            }

            public void WriteSerial(Writer w)
            {
                EnsureStuff();

                w.AddInt(2);

                w.AddInt((int)type);
                armor.WriteSerial(w);
                knockbackarmor.WriteSerial(w);
                w.AddInt(ignoregrab ? 7 : 0);
                w.AddString(bone_a);
                w.AddString(bone_b);
                radius.WriteSerial(w);
                localOffsetAX.WriteSerial(w);
                localOffsetAY.WriteSerial(w);
                localOffsetAZ.WriteSerial(w);
                worldOffsetAX.WriteSerial(w);
                worldOffsetAY.WriteSerial(w);
                worldOffsetAZ.WriteSerial(w);
                localOffsetBX.WriteSerial(w);
                localOffsetBY.WriteSerial(w);
                localOffsetBZ.WriteSerial(w);
                worldOffsetBX.WriteSerial(w);
                worldOffsetBY.WriteSerial(w);
                worldOffsetBZ.WriteSerial(w);
            }
        }
    }
}
