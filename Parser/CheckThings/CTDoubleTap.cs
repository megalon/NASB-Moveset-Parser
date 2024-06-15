using MovesetParser.BulkSerialize;

namespace MovesetParser.CheckThings
{
    public class CTDoubleTap : CheckThing, IBulkSerializer
    {
        public SimpleControlDir TapDirection = SimpleControlDir.Right;
        public int Window = 20;

        public CTDoubleTap() { }

        public new static CTDoubleTap ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();
            return new CTDoubleTap
            {
                TID = TypeId.CTDoubleTap,
                TapDirection = (SimpleControlDir)reader.GetNextInt(),
                Window = reader.GetNextInt()
            };
        }

        public override void WriteSerial(Writer writer)
        {
            writer.AddInt(3);
            writer.AddInt(0);
            writer.AddInt((int)TapDirection);
            writer.AddInt(Window);
        }

        public enum SimpleControlDir
        {
            Neutral,
            Right,
            Left,
            Up,
            Down,
            Forward,
            Backward
        }
    }
}
