using MovesetParser.BulkSerialize;
using MovesetParser.FloatSources;

namespace MovesetParser.StateActions
{
    public class SAAlterMoveDT : StateAction, IBulkSerializer
    {
        public FloatSourceContainer Alter;
        public FloatSourceContainer Falloff;
        public bool Clear;

        public SAAlterMoveDT() { }

        private void EnsureStuff()
        {
            Alter ??= new FloatSourceContainer(new FloatSource());
            Falloff ??= new FloatSourceContainer(new FloatSource(1f));
        }

        public new static SAAlterMoveDT ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            return new SAAlterMoveDT
            {
                TID = TypeId.SAAlterMoveDT,
                Clear = (reader.GetNextInt() > 0),
                Alter = FloatSourceContainer.ReadSerial(reader),
                Falloff = FloatSourceContainer.ReadSerial(reader)
            };
        }

        public override void WriteSerial(Writer writer)
        {
            EnsureStuff();

            writer.AddInt(56);
            writer.AddInt(0);

            writer.AddInt(Clear ? 7 : 0);
            Alter.WriteSerial(writer);
            Falloff.WriteSerial(writer);
        }
    }
}
