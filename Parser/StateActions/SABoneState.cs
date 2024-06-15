using MovesetParser.BulkSerialize;

namespace MovesetParser.StateActions
{
    public class SABoneState : StateAction, IBulkSerializer
    {
        public string Bone = string.Empty;
        public bool State = true;

        public SABoneState() { }

        public new static SABoneState ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            return new SABoneState
            {
                TID = TypeId.SABoneState,
                State = (reader.GetNextInt() > 0),
                Bone = reader.GetNextString()
            };
        }

        public override void WriteSerial(Writer writer)
        {
            writer.AddInt(32);
            writer.AddInt(0);

            writer.AddInt(State ? 7 : 0);
            writer.AddString(Bone);
        }
    }
}
