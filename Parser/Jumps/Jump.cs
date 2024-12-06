using MovesetParser.BulkSerialize;

namespace MovesetParser.Jumps
{
    [Serializable]
    public class Jump : IBulkSerializer
    {
        public TypeId TID = 0;

        public Jump() { }

        private static Jump ReadSerialBase(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();
            return new Jump();
        }

        public static Jump ReadSerial(Reader reader)
        {
            TypeId typeId = (TypeId)reader.PeekNextInt();
            switch (typeId)
            {
                case TypeId.Jump:
                    return ReadSerialBase(reader);
                case TypeId.HeightJump:
                    return HeightJump.ReadSerial(reader);
                case TypeId.HoldJump:
                    return HoldJump.ReadSerial(reader);
                case TypeId.AirDashJump:
                    return AirDashJump.ReadSerial(reader);
                case TypeId.KnockbackJump:
                    return KnockbackJump.ReadSerial(reader);
                case TypeId.DelayedJump:
                    return DelayedJump.ReadSerial(reader);
                case TypeId.ClampMomentumJump:
                    return ClampMomentumJump.ReadSerial(reader);
                default:
                    throw new ReadException(reader, "Unimplemented Jump serialization for id: " + typeId);
            }
        }

        public virtual void WriteSerial(Writer writer)
        {
            writer.AddInt(0);
            writer.AddInt(0);
        }

        public enum TypeId
        {
            Jump,
            HeightJump,
            HoldJump,
            AirDashJump,
            KnockbackJump,
            DelayedJump,
            ClampMomentumJump
        }
    }
}
