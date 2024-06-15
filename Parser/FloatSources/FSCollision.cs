using MovesetParser.BulkSerialize;

namespace MovesetParser.FloatSources
{
    public class FSCollision : FloatSource, IBulkSerializer
    {
        public CollisionAttribute Attribute;

        public FSCollision() { }

        public new static FSCollision ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            return new FSCollision
            {
                TID = TypeId.FSCollision,
                Attribute = (CollisionAttribute)reader.GetNextInt()
            };
        }

        public override void WriteSerial(Writer writer)
        {
            writer.AddInt(15);
            writer.AddInt(0);

            writer.AddInt((int)Attribute);
        }

        public enum CollisionAttribute
        {
            TouchBottom,
            TouchTop,
            TouchLeft,
            TouchRight,
            ParentOrderAdded
        }
    }
}
