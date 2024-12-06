using MovesetParser.BulkSerialize;
using MovesetParser.FloatSources;

namespace MovesetParser.StateActions
{
    [Serializable]
    public class SAPersistLocalFX : StateAction, IBulkSerializer
    {
        public string Id = string.Empty;
        public FloatSourceContainer Persist;
        public bool MaxOut;

        public SAPersistLocalFX() { }

        private void EnsureStuff()
        {
            Persist ??= new FloatSourceContainer(new FloatSource(-1f));
        }

        public new static SAPersistLocalFX ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            return new SAPersistLocalFX
            {
                TID = TypeId.SAPersistLocalFX,
                Id = reader.GetNextString(),
                Persist = FloatSourceContainer.ReadSerial(reader),
                MaxOut = (reader.GetNextInt() > 0)
            };
        }

        public override void WriteSerial(Writer writer)
        {
            EnsureStuff();

            writer.AddInt(76);
            writer.AddInt(0);

            writer.AddString(Id);
            Persist.WriteSerial(writer);
            writer.AddInt(MaxOut ? 7 : 0);
        }
    }
}
