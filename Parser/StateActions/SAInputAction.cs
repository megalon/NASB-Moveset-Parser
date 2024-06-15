using MovesetParser.BulkSerialize;
using MovesetParser.FloatSources;
using MovesetParser.Misc;

namespace MovesetParser.StateActions
{
    public class SAInputAction : StateAction, IBulkSerializer
    {
        public FloatSourceContainer Frames;
        public string Id;
        public InputTrigger Trigger;

        public SAInputAction() { }

        private void EnsureStuff()
        {
            Frames ??= new FloatSourceContainer(new FloatSource());
            Trigger ??= new InputTrigger();
        }

        public new static SAInputAction ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            var version = reader.GetNextInt();

            var inputAction = new SAInputAction
            {
                TID = TypeId.SAInputAction,
                Frames = ((version > 0) ? FloatSourceContainer.ReadSerial(reader) : new FloatSourceContainer(new FloatSource(reader.GetNextFloat()))),
                Id = reader.GetNextString(),
                Trigger = new InputTrigger()
            };

            inputAction.Trigger.ReadSerial(reader);

            return inputAction;
        }

        public override void WriteSerial(Writer writer)
        {
            EnsureStuff();

            writer.AddInt(6);
            writer.AddInt(1);

            Frames.WriteSerial(writer);
            writer.AddString(Id);
            Trigger.WriteSerial(writer);
        }
    }
}
