using MovesetParser.BulkSerialize;

namespace MovesetParser.StateActions
{
    public class SALaunchGrabbed : StateAction, IBulkSerializer
    {
        public string AtkProp = string.Empty;

        public SALaunchGrabbed() { }

        public new static SALaunchGrabbed ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            return new SALaunchGrabbed
            {
                TID = TypeId.SALaunchGrabbed,
                AtkProp = reader.GetNextString()
            };
        }

        public override void WriteSerial(Writer writer)
        {
            writer.AddInt(43);
            writer.AddInt(0);

            writer.AddString(AtkProp);
        }
    }
}
