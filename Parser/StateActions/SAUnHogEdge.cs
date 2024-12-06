using MovesetParser.BulkSerialize;

namespace MovesetParser.StateActions
{
    [Serializable]
    public class SAUnHogEdge : StateAction, IBulkSerializer
    {
        public SAUnHogEdge() { }

        public new static SAUnHogEdge ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            return new SAUnHogEdge()
            {
                TID = TypeId.SAUnHogEdge
            };
        }

        public override void WriteSerial(Writer writer)
        {
            writer.AddInt(64);
            writer.AddInt(0);
        }
    }
}
