using MovesetParser.BulkSerialize;
using MovesetParser.FloatSources;

namespace MovesetParser.Jumps
{
    public class HeightJump : Jump, IBulkSerializer
    {
        public FloatSourceContainer Height;

        public HeightJump() { }

        public new static HeightJump ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            return new HeightJump
            {
                TID = TypeId.HeightJump,
                Height = FloatSourceContainer.ReadSerial(reader)
            };
        }
         
        public override void WriteSerial(Writer writer)
        {
            Height ??= new FloatSourceContainer();

            writer.AddInt(1);
            writer.AddInt(0);

            Height.WriteSerial(writer);
        }
    }
}
