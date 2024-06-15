using MovesetParser.BulkSerialize;

namespace MovesetParser.FloatSources
{
    public class FSAnim : FloatSource, IBulkSerializer
    {
        public string Animation;
        public AnimationAttribute Attribute;

        public FSAnim() { }

        public new static FSAnim ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            return new FSAnim
            {
                TID = TypeId.FSAnim,
                Animation = reader.GetNextString(),
                Attribute = (AnimationAttribute)reader.GetNextInt()
            };
        }

        public override void WriteSerial(Writer writer)
        {
            writer.AddInt(12);
            writer.AddInt(0);

            writer.AddString(Animation);
            writer.AddInt((int)Attribute);
        }

        public enum AnimationAttribute
        {
            Rate,
            Weight,
            AtTime,
            AtFrame,
            RealWeight,
            Exists,
            FrameLength
        }

    }
}
