using MovesetParser.BulkSerialize;

namespace MovesetParser.StateActions
{
    public class SAOnHit : StateAction, IBulkSerializer
    {
        public bool HitBox = true;
        public int Box = -1;
        public StateAction Action;

        public SAOnHit() { }

        public new static SAOnHit ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            return new SAOnHit
            {
                TID = TypeId.SAOnHit,
                HitBox = (reader.GetNextInt() > 0),
                Box = reader.GetNextInt(),
                Action = StateAction.ReadSerial(reader)
            };
        }

        public override void WriteSerial(Writer writer)
        {
            writer.AddInt(52);
            writer.AddInt(0);

            writer.AddInt(HitBox ? 7 : 0);
            writer.AddInt(Box);

            Action ??= new StateAction();
            Action.WriteSerial(writer);
        }
    }
}
