using MovesetParser.BulkSerialize;

namespace MovesetParser.StateActions
{
    public class SASetAtkProp : StateAction, IBulkSerializer
    {
        public int HitBox = -1;
        public string Prop = string.Empty;

        public SASetAtkProp() { }

        public new static SASetAtkProp ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            return new SASetAtkProp
            {
                TID = TypeId.SASetAtkProp,
                HitBox = reader.GetNextInt(),
                Prop = reader.GetNextString()
            };
        }

        public override void WriteSerial(Writer writer)
        {
            writer.AddInt(27);
            writer.AddInt(0);

            writer.AddInt(HitBox);
            writer.AddString(Prop);
        }
    }
}
