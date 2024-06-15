using MovesetParser.BulkSerialize;

namespace MovesetParser.FloatSources
{
    public class FSItem : FloatSource, IBulkSerializer
    {
        public ItemAttribute Attribute = ItemAttribute.InterestWeight;

        public FSItem() { }

        public new static FSItem ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            return new FSItem
            {
                TID = TypeId.FSItem,
                Attribute = (ItemAttribute)reader.GetNextInt()
            };
        }

        public override void WriteSerial(Writer writer)
        {
            writer.AddInt(26);
            writer.AddInt(0);

            writer.AddInt((int)Attribute);
        }

        public enum ItemAttribute
        {
            ActivatedByHit,
            ActivatedByGrab,
            ActivatedByThrow,
            Weapon,
            Avoid,
            Beneficial,
            InterestWeight
        }
    }
}
