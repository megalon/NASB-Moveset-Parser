using MovesetParser.BulkSerialize;

namespace MovesetParser.FloatSources
{
    [Serializable]
    public class FSLastAtk : FloatSource, IBulkSerializer
    {
        public LastAtkAttribute Attribute;

        public FSLastAtk() { }

        public new static FSLastAtk ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            return new FSLastAtk
            {
                TID = TypeId.FSLastAtk,
                Attribute = (LastAtkAttribute)reader.GetNextInt()
            };
        }

        public override void WriteSerial(Writer writer)
        {
            writer.AddInt(30);
            writer.AddInt(0);

            writer.AddInt((int)Attribute);
        }

        public enum LastAtkAttribute
        {
            Type,
            DamageBase,
            DamageMult,
            KnockbackMult,
            DamageTotal,
            Angle,
            Direction,
            DiType,
            DiIn,
            DiOut,
            Reversible,
            KnockbackType,
            KnockbackBase,
            KnockbackGain,
            ExtraKbAboveKb,
            ExtraKbMult,
            StunCalc,
            StunBase,
            StunGain,
            HitOpponent,
            InteractDirection,
            Blockstun,
            Blockpush,
            Blocklag,
            Hitlag,
            HitlagSelf,
            Launcher,
            LaunchAboveKb,
            LaunchArmorLevel,
            ForceJabReset,
            Grablevel,
            Grabtype,
            Killshot,
            Directionalfx,
            Unblockable,
            Pierceinvincible,
            NoBounce
        }
    }
}
