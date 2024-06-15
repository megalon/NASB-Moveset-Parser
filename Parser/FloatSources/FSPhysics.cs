using MovesetParser.BulkSerialize;

namespace MovesetParser.FloatSources
{
    public class FSPhysics : FloatSource, IBulkSerializer
    {
        public PhysicsAttribute Attribute;

        public FSPhysics() { }

        public new static FSPhysics ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            return new FSPhysics
            {
                TID = TypeId.FSPhysics,
                Attribute = (PhysicsAttribute)reader.GetNextInt()
            };
        }

        public override void WriteSerial(Writer writer)
        {
            writer.AddInt(14);
            writer.AddInt(0);

            writer.AddInt((int)Attribute);
        }

        public enum PhysicsAttribute
        {
            Gravity
        }
    }
}
