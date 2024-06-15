using MovesetParser.BulkSerialize;
using System;

namespace MovesetParser
{
    public partial class AgentState : IBulkSerializer
    {
        public TimedAction[] Timeline;
        public string CustomCall = string.Empty;

        public AgentState() { }
        public AgentState(Reader r)
        {
            r.GetNextInt();
            r.GetNextInt();

            CustomCall = r.GetNextString();
            var nextInt = r.GetNextInt();

            Timeline = new TimedAction[nextInt];
            for (int i = 0; i < nextInt; i++)
            {
                Timeline[i] = new TimedAction(r);
            }
        }

        public static AgentState ReadSerial(Reader reader)
        {
            int num = reader.PeekNextInt();
            if (num == 0) return new AgentState(reader);

            throw new ReadException(reader, $"Unimplemented AgentState serialization for id: {num}");
        }

        public void WriteSerial(Writer writer)
        {
            writer.AddInt(0);
            writer.AddInt(0);
            writer.AddString(CustomCall);

            Timeline ??= new TimedAction[0];
            writer.AddInt(Timeline.Length);
            for (int i = 0; i < Timeline.Length; i++)
            {
                Timeline[i] ??= new TimedAction();
                Timeline[i].WriteSerial(writer);
            }
        }
    }
}
