using MovesetParser.BulkSerialize;

namespace MovesetParser.StateActions
{
    public class SAProxyMove : StateAction, IBulkSerializer
    {
        public string MoveId;

        public SAProxyMove() { }

        public new static SAProxyMove ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            return new SAProxyMove
            {
                TID = TypeId.SAProxyMove,
                MoveId = reader.GetNextString()
            };
        }

        public override void WriteSerial(Writer writer)
        {
            writer.AddInt(13);
            writer.AddInt(0);

            writer.AddString(MoveId);
        }
    }
}
