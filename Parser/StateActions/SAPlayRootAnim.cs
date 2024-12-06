using MovesetParser.BulkSerialize;
using MovesetParser.FloatSources;

namespace MovesetParser.StateActions
{
    [Serializable]
    public class SAPlayRootAnim : StateAction, IBulkSerializer
    {
        public string Anim;
        public FloatSourceContainer Rate;
        public bool SetRateOnly;
        public FloatSourceContainer Frame;
        public bool SetFrame;

        public SAPlayRootAnim() { }

        private void EnsureStuff()
        {
            Rate ??= new FloatSourceContainer(new FloatSource(1f));
            Frame ??= new FloatSourceContainer(new FloatSource());
        }

        public new static SAPlayRootAnim ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            var version = reader.GetNextInt();

            return new SAPlayRootAnim
            {
                TID = TypeId.SAPlayRootAnim,
                Anim = reader.GetNextString(),
                Rate = ((version > 0) ? FloatSourceContainer.ReadSerial(reader) : new FloatSourceContainer(new FloatSource(reader.GetNextFloat()))),
                SetRateOnly = (reader.GetNextInt() > 0),
                Frame = ((version > 0) ? FloatSourceContainer.ReadSerial(reader) : new FloatSourceContainer(new FloatSource(reader.GetNextFloat()))),
                SetFrame = (reader.GetNextInt() > 0)
            };
        }

        public override void WriteSerial(Writer writer)
        {
            EnsureStuff();

            writer.AddInt(3);
            writer.AddInt(1);

            writer.AddString(Anim);
            Rate.WriteSerial(writer);
            writer.AddInt(SetRateOnly ? 7 : 0);
            Frame.WriteSerial(writer);
            writer.AddInt(SetFrame ? 7 : 0);
        }
    }
}
