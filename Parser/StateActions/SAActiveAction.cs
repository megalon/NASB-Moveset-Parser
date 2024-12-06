using MovesetParser.BulkSerialize;
using MovesetParser.FloatSources;
using MovesetParser.Misc;

namespace MovesetParser.StateActions
{
    [Serializable]
    public class SAActiveAction : StateAction, IBulkSerializer
    {
        public StateAction Action;
        public FloatSourceContainer Frames;
        public string Id = "";
        public Phase Phase = Phase.PreStateUpd;

        private void EnsureStuff()
        {
            Action ??= new StateAction();
            Frames ??= new FloatSourceContainer(new FloatSource());
        }

        public SAActiveAction() { }

        public new static SAActiveAction ReadSerial(Reader r)
        {
            r.GetNextInt();
            r.GetNextInt();

            return new SAActiveAction
            {
                TID = TypeId.SAActiveAction,
                Action = StateAction.ReadSerial(r),
                Frames = FloatSourceContainer.ReadSerial(r),
                Id = r.GetNextString(),
                Phase = (Phase)r.GetNextInt()
            };
        }

        public override void WriteSerial(Writer w)
        {
            EnsureStuff();

            w.AddInt(15);
            w.AddInt(0);

            Action.WriteSerial(w);
            Frames.WriteSerial(w);
            w.AddString(Id);
            w.AddInt((int)Phase);
        }
    }
}
