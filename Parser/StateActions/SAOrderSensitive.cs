using MovesetParser.BulkSerialize;

namespace MovesetParser.StateActions
{
    [Serializable]
    public class SAOrderSensitive : StateAction, IBulkSerializer
    {
        public StateAction[] Actions;

        public SAOrderSensitive() { }

        private void EnsureStuff()
        {
            Actions ??= new StateAction[0];

            for (int i = 0; i < Actions.Length; i++)
            {
                Actions[i] ??= new StateAction();
            }
        }

        public new static SAOrderSensitive ReadSerial(Reader r)
        {
            r.GetNextInt();
            r.GetNextInt();

            var orderSensitive = new SAOrderSensitive()
            {
                TID = TypeId.SAOrderSensitive
            };

            var actionsCount = r.GetNextInt();
            orderSensitive.Actions = new StateAction[actionsCount];

            for (int i = 0; i < actionsCount; i++)
            {
                orderSensitive.Actions[i] = StateAction.ReadSerial(r);
            }

            return orderSensitive;
        }

        public override void WriteSerial(Writer writer)
        {
            EnsureStuff();

            writer.AddInt(12);
            writer.AddInt(0);

            writer.AddInt(Actions.Length);

            for (int i = 0; i < Actions.Length; i++)
            {
                Actions[i].WriteSerial(writer);
            }
        }
    }
}
