using MovesetParser.BulkSerialize;
using MovesetParser.FloatSources;
using MovesetParser.Misc;

namespace MovesetParser.StateActions
{
    public class SAManipHurtBox : StateAction, IBulkSerializer
    {
        public HBM[] Manips;

        public SAManipHurtBox() { }

        private void EnsureStuff()
        {
            Manips ??= new HBM[0];

            for (int i = 0; i < Manips.Length; i++)
            {
                Manips[i] ??= new HBM();
            }
        }

        public new static SAManipHurtBox ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            var manipHurtBox = new SAManipHurtBox()
            {
                TID = TypeId.SAManipHurtBox
            };

            var manipsCount = reader.GetNextInt();
            manipHurtBox.Manips = new HBM[manipsCount];

            for (int i = 0; i < manipsCount; i++)
            {
                manipHurtBox.Manips[i] = HBM.ReadSerial(reader);
            }

            return manipHurtBox;
        }

        public override void WriteSerial(Writer writer)
        {
            EnsureStuff();

            writer.AddInt(31);
            writer.AddInt(0);

            writer.AddInt(Manips.Length);

            for (int i = 0; i < Manips.Length; i++)
            {
                Manips[i].WriteSerial(writer);
            }
        }

        public class HBM : IBulkSerializer
        {
            public Manip Manip;
            public int HurtBox;
            public FloatSourceContainer Value;
            public HurtType HurtType;
            public string Bone;
            public string Bone2;

            public HBM() { }

            private void EnsureStuff()
            {
                Value ??= new FloatSourceContainer(new FSMovement());
            }

            public static HBM ReadSerial(Reader r)
            {
                int nextInt = r.GetNextInt();

                HBM hBM = new HBM
                {
                    Manip = (Manip)r.GetNextInt(),
                    HurtBox = r.GetNextInt(),
                    HurtType = (HurtType)r.GetNextInt(),
                    Value = FloatSourceContainer.ReadSerial(r)
                };

                if (nextInt > 0 && (hBM.Manip == Manip.Bone || hBM.Manip == Manip.Bone2))
                {
                    hBM.Bone = r.GetNextString();

                    if (hBM.Manip == Manip.Bone2)
                        hBM.Bone2 = r.GetNextString();
                }

                return hBM;
            }

            public void WriteSerial(Writer w)
            {
                EnsureStuff();

                w.AddInt(1);

                w.AddInt((int)Manip);
                w.AddInt(HurtBox);
                w.AddInt((int)HurtType);
                Value.WriteSerial(w);

                if (Manip == Manip.Bone || Manip == Manip.Bone2)
                {
                    w.AddString(Bone);

                    if (Manip == Manip.Bone2)
                        w.AddString(Bone2);
                }
            }
        }

        public enum Manip
        {
            Radius,
            Type,
            Armor,
            Kbarmor,
            WorldOffsetX,
            WorldOffsetY,
            WorldOffsetZ,
            LocalOffsetX,
            LocalOffsetY,
            LocalOffsetZ,
            WorldOffsetX2nd,
            WorldOffsetY2nd,
            WorldOffsetZ2nd,
            LocalOffsetX2nd,
            LocalOffsetY2nd,
            LocalOffsetZ2nd,
            Bone,
            Bone2
        }
    }
}
