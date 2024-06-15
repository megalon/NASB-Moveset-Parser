using MovesetParser.BulkSerialize;

namespace MovesetParser.ObjectSources
{
    public class ObjectSourceContainer : IBulkSerializer
    {
        public ObjectSource ObjectSource;

        public ObjectSourceContainer() { }

        public ObjectSourceContainer(ObjectSource objectSource)
        {
            ObjectSource = objectSource;
        }

        private void EnsureStuff()
        {
            ObjectSource ??= new ObjectSource();
        }

        public static ObjectSourceContainer ReadSerial(Reader reader)
        {
            return new ObjectSourceContainer(ObjectSource.ReadSerial(reader));
        }

        public void WriteSerial(Writer writer)
        {
            EnsureStuff();

            ObjectSource.WriteSerial(writer);
        }
    }
}
