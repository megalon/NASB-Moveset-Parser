using MovesetParser.BulkSerialize;
using MovesetParser.FloatSources;

namespace MovesetParser.StateActions
{
    [Serializable]
    public class SAFindFloor : StateAction, IBulkSerializer
    {
        public FloatSourceContainer Range;

        public SAFindFloor() { }

        private void EnsureStuff()
        {
            Range ??= new FloatSourceContainer(new FloatSource());
        }

        public new static SAFindFloor ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            var version = reader.GetNextInt();

            SAFindFloor sAFindFloor = new SAFindFloor()
            {
                TID = TypeId.SAFindFloor
            };

            if (version > 0)
                sAFindFloor.Range = FloatSourceContainer.ReadSerial(reader);
            else
                sAFindFloor.Range = new FloatSourceContainer(new FloatSource(reader.GetNextFloat()));

            return sAFindFloor;
        }

        public override void WriteSerial(Writer writer)
        {
            EnsureStuff();

            writer.AddInt(41);
            writer.AddInt(1);

            Range.WriteSerial(writer);
        }
    }
}
