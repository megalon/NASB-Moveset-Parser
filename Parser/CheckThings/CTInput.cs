using MovesetParser.BulkSerialize;
using MovesetParser.Misc;

namespace MovesetParser.CheckThings
{
    [Serializable]
    public class CTInput : CheckThing, IBulkSerializer
    {
        public InputValidator InputValidator;
        public int Frames = 1;
        public GIEV BlockedBy;

        public CTInput() { }

        public new static CTInput ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();
            return new CTInput
            {
                TID = TypeId.CTInput,
                InputValidator = InputValidator.ReadSerial(reader),
                Frames = reader.GetNextInt(),
                BlockedBy = (GIEV)reader.GetNextInt()
            };
        }

        public override void WriteSerial(Writer writer)
        {
            writer.AddInt(4);
            writer.AddInt(0);
            InputValidator ??= new InputValidator();
            InputValidator.WriteSerial(writer);
            writer.AddInt(Frames);
            writer.AddInt((int)BlockedBy);
        }
    }
}
