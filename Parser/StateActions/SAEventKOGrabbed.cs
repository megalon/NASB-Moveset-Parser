using MovesetParser.BulkSerialize;

namespace MovesetParser.StateActions
{
    [Serializable]
    public class SAEventKOGrabbed : StateAction, IBulkSerializer
    {
        public SAEventKO.KO KoType;

        public SAEventKOGrabbed() { }

        public new static SAEventKOGrabbed ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            return new SAEventKOGrabbed
            {
                TID = TypeId.SAEventKOGrabbed,
                KoType = (SAEventKO.KO)reader.GetNextInt()
            };
        }

        public override void WriteSerial(Writer writer)
        {
            writer.AddInt(49);
            writer.AddInt(0);

            writer.AddInt((int)KoType);
        }
    }
}
