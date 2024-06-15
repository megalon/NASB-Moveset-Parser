using MovesetParser.BulkSerialize;

namespace MovesetParser.FloatSources
{
    public class FSEffects : FloatSource, IBulkSerializer
    {
        public string LocalFxId;
        public EffectsAttribute Attribute;

        public FSEffects() { }

        public new static FSEffects ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            return new FSEffects
            {
                TID = TypeId.FSEffects,
                LocalFxId = reader.GetNextString(),
                Attribute = (EffectsAttribute)reader.GetNextInt()
            };
        }

        public override void WriteSerial(Writer writer)
        {
            writer.AddInt(18);
            writer.AddInt(0);

            writer.AddString(LocalFxId);
            writer.AddInt((int)Attribute);
        }

        public enum EffectsAttribute
        {
            TimeElapsed,
            Length,
            AddToElapsed
        }
    }
}
