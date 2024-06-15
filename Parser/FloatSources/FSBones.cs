using MovesetParser.BulkSerialize;

namespace MovesetParser.FloatSources
{
    public class FSBones : FloatSource, IBulkSerializer
    {
        public BoneAttribute Attribute = BoneAttribute.TiltAngle;
        public string Bone;

        public FSBones() { }

        public new static FSBones ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            var version = reader.GetNextInt();

            var fSBones = new FSBones
            {
                TID = TypeId.FSBones,
                Attribute = (BoneAttribute)reader.GetNextInt()
            };

            if (version > 0 && fSBones.Attribute == BoneAttribute.BoneActive)
            {
                fSBones.Bone = reader.GetNextString();
            }

            return fSBones;
        }

        public override void WriteSerial(Writer writer)
        {
            writer.AddInt(2);
            writer.AddInt(1);

            writer.AddInt((int)Attribute);

            if (Attribute == BoneAttribute.BoneActive)
            {
                writer.AddString(Bone);
            }
        }

        public enum BoneAttribute
        {
            RotationAngle,
            LookAngle,
            TiltAngle,
            MirrorByDirection,
            OffsetX,
            OffsetY,
            BoneActive
        }
    }
}
