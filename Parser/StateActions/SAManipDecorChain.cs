using MovesetParser.BulkSerialize;
using MovesetParser.FloatSources;

namespace MovesetParser.StateActions
{
    [Serializable]
    public class SAManipDecorChain : StateAction, IBulkSerializer
    {
        public int ManipIndex;
        public Manip ManipType;
        public FloatSourceContainer MaxDistEnds;

        public SAManipDecorChain() { }

        private void EnsureStuff()
        {
            MaxDistEnds ??= new FloatSourceContainer(new FloatSource());
        }

        public new static SAManipDecorChain ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            return new SAManipDecorChain
            {
                TID = TypeId.SAManipDecorChain,
                ManipIndex = reader.GetNextInt(),
                ManipType = (Manip)reader.GetNextInt(),
                MaxDistEnds = FloatSourceContainer.ReadSerial(reader)
            };
        }

        public override void WriteSerial(Writer writer)
        {
            EnsureStuff();

            writer.AddInt(70);
            writer.AddInt(0);

            writer.AddInt(ManipIndex);
            writer.AddInt((int)ManipType);
            MaxDistEnds.WriteSerial(writer);
        }

        public enum Manip
        {
            MaxDistEnds
        }
    }
}
