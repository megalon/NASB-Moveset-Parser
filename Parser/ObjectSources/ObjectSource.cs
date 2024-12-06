using MovesetParser.BulkSerialize;

namespace MovesetParser.ObjectSources
{
    [Serializable]
    public class ObjectSource : IBulkSerializer
    {
        public TypeId TID = 0;

        public ObjectSource() { }

        private static ObjectSource ReadSerialBase(Reader r)
        {
            r.GetNextInt();
            r.GetNextInt();
            return new ObjectSource();
        }

        public static ObjectSource ReadSerial(Reader reader)
        {
            TypeId typeId = (TypeId)reader.PeekNextInt();
            switch (typeId)
            {
                case TypeId.ObjectSource:
                    return ReadSerialBase(reader);
                case TypeId.OSFloat:
                    return OSFloat.ReadSerial(reader);
                case TypeId.OSVector2:
                    return OSVector2.ReadSerial(reader);
                default:
                    throw new ReadException(reader, $"Unimplemented ObjectSource serialization for id: {typeId}");
            }
        }

        public virtual void WriteSerial(Writer writer)
        {
            writer.AddInt(0);
            writer.AddInt(0);
        }

        public enum TypeId
        {
            ObjectSource,
            OSFloat,
            OSVector2
        }
    }
}
