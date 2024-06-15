using MovesetParser.BulkSerialize;

namespace MovesetParser.CheckThings
{
    public class CheckThing : IBulkSerializer
    {
        public TypeId TID = 0;

        public CheckThing() { }

        private static CheckThing ReadSerialBase(Reader r)
        {
            r.GetNextInt();
            r.GetNextInt();
            return new CheckThing();
        }

        public static CheckThing ReadSerial(Reader reader)
        {
            var typeId = (TypeId)reader.PeekNextInt();
            switch (typeId)
            {
                case TypeId.CheckThing:
                    return ReadSerialBase(reader);
                case TypeId.CTMultiple:
                    return CTMultiple.ReadSerial(reader);
                case TypeId.CTCompareFloat:
                    return CTCompareFloat.ReadSerial(reader);
                case TypeId.CTDoubleTap:
                    return CTDoubleTap.ReadSerial(reader);
                case TypeId.CTInput:
                    return CTInput.ReadSerial(reader);
                case TypeId.CTInputSeries:
                    return CTInputSeries.ReadSerial(reader);
                case TypeId.CTCheckTech:
                    return CTCheckTech.ReadSerial(reader);
                case TypeId.CTGrab:
                    return CTGrab.ReadSerial(reader);
                case TypeId.CTGrabbedAgent:
                    return CTGrabbedAgent.ReadSerial(reader);
                case TypeId.CTSkin:
                    return CTSkin.ReadSerial(reader);
                case TypeId.CTMove:
                    return CTMove.ReadSerial(reader);
                default:
                    throw new ReadException(reader, $"Unimplemented StateAction serialization for id: {typeId}");
            }
        }

        public virtual void WriteSerial(Writer writer)
        {
            writer.AddInt(0);
            writer.AddInt(0);
        }

        public enum CheckWay
        {
            Equal,
            NotEqual,
            Less,
            Larger,
            EOLess,
            EOLarger
        }

        public enum TypeId
        {
            CheckThing,
            CTMultiple,
            CTCompareFloat,
            CTDoubleTap,
            CTInput,
            CTInputSeries,
            CTCheckTech,
            CTGrab,
            CTGrabbedAgent,
            CTSkin,
            CTMove
        }
    }
}
