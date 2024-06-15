using MovesetParser.BulkSerialize;

namespace MovesetParser.StateActions
{
    public class SASnapAnimWeights : StateAction, IBulkSerializer
    {
        public bool ForceSample;

        public SASnapAnimWeights() { }

        public new static SASnapAnimWeights ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            return new SASnapAnimWeights
            {
                TID = TypeId.SASnapAnimWeights,
                ForceSample = (reader.GetNextInt() > 0)
            };
        }

        public override void WriteSerial(Writer writer)
        {
            writer.AddInt(4);
            writer.AddInt(0);

            writer.AddInt(ForceSample ? 7 : 0);
        }
    }
}
