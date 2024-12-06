using MovesetParser.BulkSerialize;

namespace MovesetParser.FloatSources
{
    [Serializable]
    public class FSOnHit : FloatSource, IBulkSerializer
    {
        public OnHitAttribute Attribute;

        public FSOnHit() { }

        public new static FSOnHit ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            return new FSOnHit
            {
                TID = TypeId.FSOnHit,
                Attribute = (OnHitAttribute)reader.GetNextInt()
            };
        }

        public override void WriteSerial(Writer writer)
        {
            writer.AddInt(20);
            writer.AddInt(0);

            writer.AddInt((int)Attribute);
        }

        public enum OnHitAttribute
        {
            Hitpos_x = 0,
            Hitpos_y = 1,
            Hitpos_z = 2,
            Hitwasinvincible = 3,
            Hitwasblock = 4,
            Hitwellblocked = 6,
            Hitperfectblocked = 7,
            Hitwasclean = 13,
            Hurtdamage = 5,
            Hurtknockback = 12,
            Hitdamage = 9,
            Hurtwellblocked = 11,
            Hurtperfectblocked = 8,
            Hurtattacktype = 10
        }
    }
}
