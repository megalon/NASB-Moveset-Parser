using MovesetParser.BulkSerialize;
using MovesetParser.FloatSources;

namespace MovesetParser.StateActions
{
    public class SAAlterMoveVel : StateAction, IBulkSerializer
    {
        public FloatSourceContainer AlterX;
        public FloatSourceContainer AlterY;
        public FloatSourceContainer FalloffX;
        public FloatSourceContainer FalloffY;
        public bool Clear;

        public SAAlterMoveVel() { }

        private void EnsureStuff()
        {
            AlterX ??= new FloatSourceContainer(new FloatSource());
            AlterY ??= new FloatSourceContainer(new FloatSource());
            FalloffX ??= new FloatSourceContainer(new FloatSource(1f));
            FalloffY ??= new FloatSourceContainer(new FloatSource(1f));
        }

        public new static SAAlterMoveVel ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            return new SAAlterMoveVel
            {
                TID = TypeId.SAAlterMoveVel,
                Clear = (reader.GetNextInt() > 0),
                AlterX = FloatSourceContainer.ReadSerial(reader),
                AlterY = FloatSourceContainer.ReadSerial(reader),
                FalloffX = FloatSourceContainer.ReadSerial(reader),
                FalloffY = FloatSourceContainer.ReadSerial(reader)
            };
        }

        public override void WriteSerial(Writer writer)
        {
            EnsureStuff();

            writer.AddInt(57);
            writer.AddInt(0);

            writer.AddInt(Clear ? 7 : 0);
            AlterX.WriteSerial(writer);
            AlterY.WriteSerial(writer);
            FalloffX.WriteSerial(writer);
            FalloffY.WriteSerial(writer);
        }
    }
}
