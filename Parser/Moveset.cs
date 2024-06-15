using MovesetParser.BulkSerialize;
using System.Diagnostics;

namespace MovesetParser
{
    public class Moveset : IBulkSerializer
    {
        public IdState[] States;

        public Moveset() { }
        private Moveset(Reader reader)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            reader.ResetRead();
            reader.GetNextInt();

            var numStates = reader.GetNextInt();
            States = new IdState[numStates];
            for (int i = 0; i < numStates; i++)
            {
                States[i] = new IdState(reader);
            }

            stopwatch.Stop();
            Console.WriteLine($"Finished parsing moveset in {stopwatch.ElapsedMilliseconds} ms.");
        }

        public static Moveset CreateFromString(string inputText)
        {
            var reader = new Reader(inputText);
            return ReadSerial(reader);
        }

        public static Moveset CreateFromFile(string filePath)
        {
            var inputText = File.ReadAllText(filePath);
            return CreateFromString(inputText);
        }

        public static Moveset CreateFromStream(Stream inputStream)
        {
            var reader = new Reader(inputStream);
            return ReadSerial(reader);
        }

        public static Moveset ReadSerial(Reader reader)
        {
            return new Moveset(reader);
        }

        public void WriteSerial(Writer writer)
        {
            writer.AddInt(0);
            writer.AddInt(States.Length);

            for (int i = 0; i < States.Length; i++)
            {
                States[i].WriteSerial(writer);
            }
        }
    }
}
