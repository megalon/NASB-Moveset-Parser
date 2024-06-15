using MovesetParser.BulkSerialize;
using MovesetParser.FloatSources;

namespace MovesetParser.StateActions
{
    public class SAManipHitBox : StateAction, IBulkSerializer
    {
        public HBM[] Manips;

        public SAManipHitBox() { }

        private void EnsureStuff()
        {
            Manips ??= new HBM[0];

            for (int i = 0; i < Manips.Length; i++)
            {
                Manips[i] ??= new HBM();
            }
        }

        public new static SAManipHitBox ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            var manipHitBox = new SAManipHitBox()
            {
                TID = TypeId.SAManipHitBox
            };

            var manipsCount = reader.GetNextInt();
            manipHitBox.Manips = new HBM[manipsCount];

            for (int i = 0; i < manipsCount; i++)
            {
                manipHitBox.Manips[i] = HBM.ReadSerial(reader);
            }

            return manipHitBox;
        }

        public override void WriteSerial(Writer writer)
        {
            EnsureStuff();

            writer.AddInt(28);
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
            public int HitBox;
            public FloatSourceContainer Value;
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
                    HitBox = r.GetNextInt(),
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

            public void WriteSerial(Writer writer)
            {
                EnsureStuff();

                writer.AddInt(1);

                writer.AddInt((int)Manip);
                writer.AddInt(HitBox);

                Value.WriteSerial(writer);

                if (Manip == Manip.Bone || Manip == Manip.Bone2)
                {
                    writer.AddString(Bone);

                    if (Manip == Manip.Bone2)
                        writer.AddString(Bone2);
                }
            }
        }

        public enum Manip
        {
            Radius,
            InteractWithHurtsets,
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
