using MovesetParser.BulkSerialize;
using MovesetParser.FloatSources;

namespace MovesetParser.StateActions
{
    [Serializable]
    public class SABoneScale : StateAction, IBulkSerializer
    {
        public string Bone = string.Empty;
        public FloatSourceContainer Scale;

        public SABoneScale() { }

        private void EnsureStuff()
        {
            Scale ??= new FloatSourceContainer(new FloatSource());
        }

        public new static SABoneScale ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            return new SABoneScale
            {
                TID = TypeId.SABoneScale,
                Bone = reader.GetNextString(),
                Scale = FloatSourceContainer.ReadSerial(reader)
            };
        }

        public override void WriteSerial(Writer writer)
        {
            EnsureStuff();

            writer.AddInt(33);
            writer.AddInt(0);

            writer.AddString(Bone);
            Scale.WriteSerial(writer);
        }
    }
}
