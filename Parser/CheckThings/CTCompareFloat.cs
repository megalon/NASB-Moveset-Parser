using MovesetParser.BulkSerialize;
using MovesetParser.FloatSources;

namespace MovesetParser.CheckThings
{
    [Serializable]
    public class CTCompareFloat : CheckThing, IBulkSerializer
    {
        public CheckWay Way;
        public FloatSourceContainer A;
        public FloatSourceContainer B;

        public CTCompareFloat() { }

        private void EnsureStuff()
        {
            A ??= new FloatSourceContainer();
            B ??= new FloatSourceContainer();
        }

        public new static CTCompareFloat ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();
            return new CTCompareFloat
            {
                TID = TypeId.CTCompareFloat,
                Way = (CheckWay)reader.GetNextInt(),
                A = FloatSourceContainer.ReadSerial(reader),
                B = FloatSourceContainer.ReadSerial(reader)
            };
        }

        public override void WriteSerial(Writer writer)
        {
            EnsureStuff();

            writer.AddInt(2);
            writer.AddInt(0);

            writer.AddInt((int)Way);
            A.WriteSerial(writer);
            B.WriteSerial(writer);
        }
    }
}
