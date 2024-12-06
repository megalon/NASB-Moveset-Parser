using MovesetParser.BulkSerialize;

namespace MovesetParser.CheckThings
{
    [Serializable]
    public class CTMove : CheckThing, IBulkSerializer
    {
        public string MovesetId;
        public string[] Extras;
        public bool Previous;
        public bool Not;

        public CTMove() { }

        public new static CTMove ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            int version = reader.GetNextInt();

            var cTMove = new CTMove
            {
                TID = TypeId.CTMove,
                MovesetId = reader.GetNextString(),
                Previous = (reader.GetNextInt() > 0)
            };

            if (version > 0) cTMove.Not = reader.GetNextInt() > 0;

            int extrasLength = reader.GetNextInt();
            cTMove.Extras = new string[extrasLength];

            for (int i = 0; i < extrasLength; i++)
            {
                cTMove.Extras[i] = reader.GetNextString();
            }

            return cTMove;
        }

        public override void WriteSerial(Writer writer)
        {
            writer.AddInt(10);
            writer.AddInt(1);

            writer.AddString(MovesetId);

            writer.AddInt(Previous ? 7 : 0);

            writer.AddInt(Not ? 7 : 0);

            Extras ??= new string[0];
            writer.AddInt(Extras.Length);

            for (int i = 0; i < Extras.Length; i++)
            {
                writer.AddString(Extras[i]);
            }
        }
    }
}
