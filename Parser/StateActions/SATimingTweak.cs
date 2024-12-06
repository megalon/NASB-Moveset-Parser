using MovesetParser.BulkSerialize;
using MovesetParser.FloatSources;
using MovesetParser.Misc;

namespace MovesetParser.StateActions
{
    [Serializable]
    public class SATimingTweak : StateAction, IBulkSerializer
    {
        public string AnimId;
        public string RootAnimId;
        public AnimConfig AnimConfig = AnimConfig.Default;
        public FloatSourceContainer AnimFrames;
        public FloatSourceContainer StateFrames;
        public FloatSourceContainer FramesToA;
        public FloatSourceContainer FramesToBe;
        public StateAction ActionA;
        public StateAction ActionB;
        public StateAction ActionEnd;

        public SATimingTweak() { }

        private void EnsureStuff()
        {
            AnimFrames ??= new FloatSourceContainer(new FloatSource());
            StateFrames ??= new FloatSourceContainer(new FloatSource());
            FramesToA ??= new FloatSourceContainer(new FloatSource());
            FramesToBe ??= new FloatSourceContainer(new FloatSource());

            ActionA ??= new StateAction();
            ActionB ??= new StateAction();
            ActionEnd ??= new StateAction();
        }

        public new static SATimingTweak ReadSerial(Reader r)
        {
            r.GetNextInt();
            r.GetNextInt();

            return new SATimingTweak
            {
                TID = TypeId.SATimingTweak,

                AnimId = r.GetNextString(),
                RootAnimId = r.GetNextString(),

                AnimConfig = AnimConfig.ReadSerial(r),

                AnimFrames = FloatSourceContainer.ReadSerial(r),
                StateFrames = FloatSourceContainer.ReadSerial(r),
                FramesToA = FloatSourceContainer.ReadSerial(r),
                FramesToBe = FloatSourceContainer.ReadSerial(r),

                ActionA = StateAction.ReadSerial(r),
                ActionB = StateAction.ReadSerial(r),
                ActionEnd = StateAction.ReadSerial(r)
            };
        }

        public override void WriteSerial(Writer w)
        {
            EnsureStuff();

            w.AddInt(54);
            w.AddInt(0);

            w.AddString(AnimId);
            w.AddString(RootAnimId);

            AnimConfig.WriteSerial(w);

            AnimFrames.WriteSerial(w);
            StateFrames.WriteSerial(w);
            FramesToA.WriteSerial(w);
            FramesToBe.WriteSerial(w);

            ActionA.WriteSerial(w);
            ActionB.WriteSerial(w);
            ActionEnd.WriteSerial(w);
        }
    }
}
