using MovesetParser.BulkSerialize;

namespace MovesetParser.FloatSources
{
    public class FSAttack : FloatSource, IBulkSerializer
    {
        public AttackAttribute Attribute;

        public FSAttack() { }

        public new static FSAttack ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            return new FSAttack
            {
                TID = TypeId.FSAttack,
                Attribute = (AttackAttribute)reader.GetNextInt()
            };
        }

        public override void WriteSerial(Writer writer)
        {
            writer.AddInt(3);
            writer.AddInt(0);

            writer.AddInt((int)Attribute);
        }

        public enum AttackAttribute
        {
            UnIgnoreFrames,
            DamageMult,
            KnockbackMult,
            NumberOfHitboxes
        }
    }
}
