using MovesetParser.BulkSerialize;
using MovesetParser.Misc;

namespace MovesetParser.CheckThings
{
    public class CTInputSeries : CheckThing, IBulkSerializer
    {
        public int CheckFrames;
        public LookForInput[] InputSeries;
        public LookForInput[] StopLooking;

        public CTInputSeries() { }

        public new static CTInputSeries ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            var inputSeries = new CTInputSeries
            {
                TID = TypeId.CTInputSeries,
                CheckFrames = reader.GetNextInt()
            };

            var inputSeriesLength = reader.GetNextInt();
            inputSeries.InputSeries = new LookForInput[inputSeriesLength];

            for (int i = 0; i < inputSeriesLength; i++)
            {
                inputSeries.InputSeries[i] = LookForInput.ReadSerial(reader);
            }

            var stopLookingSeries = reader.GetNextInt();
            inputSeries.StopLooking = new LookForInput[stopLookingSeries];

            for (int j = 0; j < stopLookingSeries; j++)
            {
                inputSeries.StopLooking[j] = LookForInput.ReadSerial(reader);
            }

            return inputSeries;
        }

        public override void WriteSerial(Writer writer)
        {
            writer.AddInt(5);
            writer.AddInt(0);

            writer.AddInt(CheckFrames);

            InputSeries ??= new LookForInput[0];
            writer.AddInt(InputSeries.Length);

            for (int i = 0; i < InputSeries.Length; i++)
            {
                InputSeries[i] ??= new LookForInput();
                InputSeries[i].WriteSerial(writer);
            }

            StopLooking ??= new LookForInput[0];
            writer.AddInt(StopLooking.Length);

            for (int j = 0; j < StopLooking.Length; j++)
            {
                StopLooking[j] ??= new LookForInput();
                StopLooking[j].WriteSerial(writer);
            }
        }

        public class LookForInput : IBulkSerializer
        {
            public int matchMinFrames;

            public InputValidator iv;

            public void WriteSerial(Writer writer)
            {
                writer.AddInt(0);
                writer.AddInt(matchMinFrames);
                iv ??= new InputValidator();
                iv.WriteSerial(writer);
            }

            public static LookForInput ReadSerial(Reader reader)
            {
                reader.GetNextInt();
                return new LookForInput
                {
                    matchMinFrames = reader.GetNextInt(),
                    iv = InputValidator.ReadSerial(reader)
                };
            }
        }
    }
}
