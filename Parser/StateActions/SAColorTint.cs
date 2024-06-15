using MovesetParser.BulkSerialize;
using MovesetParser.FloatSources;

namespace MovesetParser.StateActions
{
    public class SAColorTint : StateAction, IBulkSerializer
    {
        public string Id = string.Empty;
        public bool Activate = true;
        public FloatSourceContainer RunForTime;
        public bool Permanent;

        public SAColorTint() { }

        private void EnsureStuff()
        {
            RunForTime ??= new FloatSourceContainer(new FloatSource());
        }

        public new static SAColorTint ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            return new SAColorTint
            {
                TID = TypeId.SAColorTint,
                Id = reader.GetNextString(),
                Activate = (reader.GetNextInt() > 0),
                Permanent = (reader.GetNextInt() > 0),
                RunForTime = FloatSourceContainer.ReadSerial(reader)
            };
        }

        public override void WriteSerial(Writer writer)
        {
            EnsureStuff();

            writer.AddInt(40);
            writer.AddInt(0);

            writer.AddString(Id);
            writer.AddInt(Activate ? 7 : 0);
            writer.AddInt(Permanent ? 7 : 0);
            RunForTime.WriteSerial(writer);
        }
    }
}
