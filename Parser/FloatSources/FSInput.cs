using MovesetParser.BulkSerialize;

namespace MovesetParser.FloatSources
{
    [Serializable]
    public class FSInput : FloatSource, IBulkSerializer
    {
        public CheckInput Input;

        public FSInput() { }

        public new static FSInput ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            return new FSInput
            {
                TID = TypeId.FSInput,
                Input = (CheckInput)reader.GetNextInt()
            };
        }

        public override void WriteSerial(Writer writer)
        {
            writer.AddInt(5);
            writer.AddInt(0);

            writer.AddInt((int)Input);
        }

        public enum CheckInput
        {
            CtrlX = 0,
            CtrlXRaw = 1,
            CtrlY = 2,
            Attack = 3,
            Strong = 4,
            Special = 5,
            Jump = 6,
            Defend = 7,
            Fun = 8,
            Grabmacro = 9,
            CtrlX2nd = 10,
            CtrlX2ndRaw = 11,
            CtrlY2nd = 12,
        }
    }
}
