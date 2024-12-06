using MovesetParser.BulkSerialize;
using MovesetParser.Misc;

namespace MovesetParser.StateActions
{
    [Serializable]
    public class SAPlayAnim : StateAction, IBulkSerializer
    {
        public string Anim;
        public bool FromStart = true;
        public AnimConfig Config = AnimConfig.Default;

        public SAPlayAnim() { }

        public new static SAPlayAnim ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            return new SAPlayAnim
            {
                TID = TypeId.SAPlayAnim,
                FromStart = (reader.GetNextInt() > 0),
                Anim = reader.GetNextString(),
                Config = AnimConfig.ReadSerial(reader)
            };
        }

        public override void WriteSerial(Writer writer)
        {
            writer.AddInt(2);
            writer.AddInt(0);

            writer.AddInt(FromStart ? 7 : 0);
            writer.AddString(Anim);
            Config.WriteSerial(writer);
        }
    }
}
