using MovesetParser.BulkSerialize;

namespace MovesetParser.StateActions
{
    public class SAEventKO : StateAction, IBulkSerializer
    {
        public KO KoType;

        public SAEventKO() { }

        public new static SAEventKO ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            return new SAEventKO
            {
                TID = TypeId.SAEventKO,
                KoType = (KO)reader.GetNextInt()
            };
        }

        public override void WriteSerial(Writer writer)
        {
            writer.AddInt(48);
            writer.AddInt(0);

            writer.AddInt((int)KoType);
        }

        public enum KO
        {
            Top,
            Left,
            Right,
            Bottom,
            Box,
            Enemy,
            Grabbed,
            Critical
        }
    }
}
