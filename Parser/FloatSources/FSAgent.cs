using MovesetParser.BulkSerialize;

namespace MovesetParser.FloatSources
{
    [Serializable]
    public class FSAgent : FloatSource, IBulkSerializer
    {
        public AgentAttribute Attribute = AgentAttribute.PlayerIndex;

        public FSAgent() { }

        public new static FSAgent ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            return new FSAgent
            {
                TID = TypeId.FSAgent,
                Attribute = (AgentAttribute)reader.GetNextInt()
            };
        }

        public override void WriteSerial(Writer writer)
        {
            writer.AddInt(1);
            writer.AddInt(0);

            writer.AddInt((int)Attribute);
        }


        public enum AgentAttribute
        {
            DestroyAfterFrame,
            PlayerIndex,
            Attackteam,
            Defendteam,
            PleaseRespawn,
            GameTeam,
            OrderAdded
        }
    }
}
