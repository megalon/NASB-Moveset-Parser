using MovesetParser.BulkSerialize;
using MovesetParser.FloatSources;
using MovesetParser.Misc;

namespace MovesetParser.StateActions
{
    public class SAStandardInput : StateAction, IBulkSerializer
    {
        public FloatSourceContainer Frames;
        public bool ForceCheck;
        public StandardInputTriggerConfig Config;

        public SAStandardInput() { }

        private void EnsureStuff()
        {
            Frames ??= new FloatSourceContainer(new FloatSource());
            Config ??= new StandardInputTriggerConfig();
        }

        public new static SAStandardInput ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            var version = reader.GetNextInt();

            var standardInput = new SAStandardInput
            {
                TID = TypeId.SAStandardInput,
                Frames = ((version > 0) ? FloatSourceContainer.ReadSerial(reader) : new FloatSourceContainer(new FloatSource(reader.GetNextFloat()))),
                ForceCheck = reader.GetNextInt() > 0,
                Config = new StandardInputTriggerConfig()
            };

            standardInput.Config.ReadSerial(reader);

            return standardInput;
        }

        public override void WriteSerial(Writer writer)
        {
            EnsureStuff();

            writer.AddInt(5);
            writer.AddInt(1);

            Frames.WriteSerial(writer);
            writer.AddInt(ForceCheck ? 7 : 0);

            Config ??= new StandardInputTriggerConfig();
            Config.WriteSerial(writer);
        }
    }
}
