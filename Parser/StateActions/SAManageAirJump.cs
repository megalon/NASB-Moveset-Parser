using MovesetParser.BulkSerialize;
using MovesetParser.Misc;

namespace MovesetParser.StateActions
{
    [Serializable]
    public class SAManageAirJump : StateAction, IBulkSerializer
    {
        public Manage Manage;

        public SAManageAirJump() { }

        public new static SAManageAirJump ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            return new SAManageAirJump
            {
                TID = TypeId.SAManageAirJump,
                Manage = (Manage)reader.GetNextInt()
            };
        }

        public override void WriteSerial(Writer writer)
        {
            writer.AddInt(62);
            writer.AddInt(0);

            writer.AddInt((int)Manage);
        }
    }
}
