using MovesetParser.BulkSerialize;
using MovesetParser.Misc;

namespace MovesetParser.StateActions
{
    [Serializable]
    public class SAAddInputEventFromFrame : StateAction, IBulkSerializer
    {
        public GIEV AddEvent = GIEV.ActionFromFrame;

        public SAAddInputEventFromFrame() { }

        public new static SAAddInputEventFromFrame ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();
            return new SAAddInputEventFromFrame
            {
                TID = TypeId.SAAddInputEventFromFrame,
                AddEvent = (GIEV)reader.GetNextInt()
            };
        }

        public override void WriteSerial(Writer writer)
        {
            writer.AddInt(8);
            writer.AddInt(0);

            writer.AddInt((int)AddEvent);
        }
    }
}
