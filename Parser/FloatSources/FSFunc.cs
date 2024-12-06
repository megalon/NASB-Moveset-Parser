using MovesetParser.BulkSerialize;

namespace MovesetParser.FloatSources
{
    [Serializable]
    public class FSFunc : FloatSource, IBulkSerializer
    {
        public FuncWay Way;
        public FloatSourceContainer A;
        public FloatSourceContainer B;
        public FloatSourceContainer C;

        public FSFunc() { }

        private void EnsureStuff()
        {
            A ??= new FloatSourceContainer(new FloatSource());
            B ??= new FloatSourceContainer(new FloatSource());
            C ??= new FloatSourceContainer(new FloatSource());
        }

        public new static FSFunc ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            return new FSFunc
            {
                TID = TypeId.FSFunc,
                Way = (FuncWay)reader.GetNextInt(),
                A = FloatSourceContainer.ReadSerial(reader),
                B = FloatSourceContainer.ReadSerial(reader),
                C = FloatSourceContainer.ReadSerial(reader)
            };
        }

        public override void WriteSerial(Writer writer)
        {
            EnsureStuff();

            writer.AddInt(6);
            writer.AddInt(0);

            writer.AddInt((int)Way);

            A.WriteSerial(writer);
            B.WriteSerial(writer);
            C.WriteSerial(writer);
        }

        public enum FuncWay
        {
            Abs,
            Add,
            Sub,
            Div,
            Mult,
            Sin,
            Cos,
            Mod,
            Clamp,
            Floor,
            Ceil,
            MoveTo,
            MoveToAng,
            MoveToF,
            MoveToAngF,
            Sign,
            Lerp,
            InvLerp,
            Repeat,
            Pow,
            Sqrt,
            Log,
            Log10,
            Atan,
            Atan2,
            RoundToInt,
            Max,
            Min,
            Pi,
            Frame,
            InvFrame
        }
    }
}
