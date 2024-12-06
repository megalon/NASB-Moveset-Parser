using MovesetParser.BulkSerialize;
using MovesetParser.FloatSources;

namespace MovesetParser.StateActions
{
    [Serializable]
    public class SASetFloatTarget : StateAction, IBulkSerializer
    {
        public SetFloat[] Sets;

        public SASetFloatTarget() { }

        private void EnsureStuff()
        {
            Sets ??= new SetFloat[0];
            for (int i = 0; i < Sets.Length; i++)
            {
                Sets[i] ??= new SetFloat();
            }
        }

        public new static SASetFloatTarget ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            var setFloatTarget = new SASetFloatTarget()
            {
                TID = TypeId.SASetFloatTarget
            };

            var setsCount = reader.GetNextInt();
            setFloatTarget.Sets = new SetFloat[setsCount];

            for (int i = 0; i < setsCount; i++)
            {
                setFloatTarget.Sets[i] = new SetFloat(reader);
            }

            return setFloatTarget;
        }

        public override void WriteSerial(Writer writer)
        {
            EnsureStuff();

            writer.AddInt(17);
            writer.AddInt(0);

            writer.AddInt(Sets.Length);
            for (int i = 0; i < Sets.Length; i++)
            {
                Sets[i].WriteSerial(writer);
            }
        }

    [Serializable]
    public class SetFloat : IBulkSerializer
        {
            public ManipWay Way;
            public FloatSourceContainer Target;
            public FloatSourceContainer Source;

            public SetFloat() { }

            private void EnsureStuff()
            {
                Target ??= new FloatSourceContainer(new FSMovement());
                Source ??= new FloatSourceContainer(new FloatSource());
            }

            public SetFloat(Reader reader)
            {
                reader.GetNextInt();

                Target = FloatSourceContainer.ReadSerial(reader);
                Source = FloatSourceContainer.ReadSerial(reader);
                Way = (ManipWay)reader.GetNextInt();
            }

            public void WriteSerial(Writer writer)
            {
                EnsureStuff();

                writer.AddInt(0);

                Target.WriteSerial(writer);
                Source.WriteSerial(writer);
                writer.AddInt((int)Way);
            }

            public enum ManipWay
            {
                Set,
                Add,
                Mult
            }
        }
    }
}
