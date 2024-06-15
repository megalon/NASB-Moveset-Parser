using MovesetParser.BulkSerialize;
using MovesetParser.Misc;

namespace MovesetParser.StateActions
{
    public class SALocalFX : StateAction, IBulkSerializer
    {
        public string Id = string.Empty;
        public LocalFXAction LocalFXAction;

        public SALocalFX() { }

        public new static SALocalFX ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            return new SALocalFX
            {
                TID = TypeId.SALocalFX,
                LocalFXAction = (LocalFXAction)reader.GetNextInt(),
                Id = reader.GetNextString()
            };
        }

        public override void WriteSerial(Writer writer)
        {
            writer.AddInt(35);
            writer.AddInt(0);

            writer.AddInt((int)LocalFXAction);
            writer.AddString(Id);
        }
    }
}
