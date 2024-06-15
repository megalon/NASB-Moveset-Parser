using MovesetParser.BulkSerialize;
using MovesetParser.Misc;

namespace MovesetParser.StateActions
{
    public class SASetupHurtboxes : StateAction, IBulkSerializer
    {
        public HurtSetSetup HurtSetSetup;

        public SASetupHurtboxes() { }

        private void EnsureStuff()
        {
            HurtSetSetup ??= new HurtSetSetup();
        }

        public new static SASetupHurtboxes ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            return new SASetupHurtboxes
            {
                TID = TypeId.SASetupHurtboxes,
                HurtSetSetup = HurtSetSetup.ReadSerial(reader)
            };
        }

        public override void WriteSerial(Writer writer)
        {
            EnsureStuff();

            writer.AddInt(30);
            writer.AddInt(0);

            HurtSetSetup.WriteSerial(writer);
        }
    }
}
