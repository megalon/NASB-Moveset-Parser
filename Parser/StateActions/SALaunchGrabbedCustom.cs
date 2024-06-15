using MovesetParser.BulkSerialize;
using MovesetParser.FloatSources;

namespace MovesetParser.StateActions
{
    public class SALaunchGrabbedCustom : StateAction, IBulkSerializer
    {
        public string AtkProp = string.Empty;
        public FloatSourceContainer X;
        public FloatSourceContainer Y;

        public SALaunchGrabbedCustom() { }

        private void EnsureStuff()
        {
            X ??= new FloatSourceContainer(new FloatSource());
            Y ??= new FloatSourceContainer(new FloatSource());
        }

        public new static SALaunchGrabbedCustom ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            return new SALaunchGrabbedCustom
            {
                TID = TypeId.SALaunchGrabbedCustom,
                AtkProp = reader.GetNextString(),
                X = FloatSourceContainer.ReadSerial(reader),
                Y = FloatSourceContainer.ReadSerial(reader)
            };
        }

        public override void WriteSerial(Writer writer)
        {
            EnsureStuff();

            writer.AddInt(74);
            writer.AddInt(0);

            writer.AddString(AtkProp);
            X.WriteSerial(writer);
            Y.WriteSerial(writer);
        }
    }
}
