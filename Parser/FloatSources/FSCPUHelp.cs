using MovesetParser.BulkSerialize;

namespace MovesetParser.FloatSources
{
    [Serializable]
    public class FSCPUHelp : FloatSource, IBulkSerializer
    {
        public CPUHelpAttribute Attribute = CPUHelpAttribute.DoingAttack;

        public FSCPUHelp() { }

        public new static FSCPUHelp ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            return new FSCPUHelp
            {
                TID = TypeId.FSCPUHelp,
                Attribute = (CPUHelpAttribute)reader.GetNextInt()
            };
        }

        public override void WriteSerial(Writer writer)
        {
            writer.AddInt(25);
            writer.AddInt(0);

            writer.AddInt((int)Attribute);
        }

        public enum CPUHelpAttribute
        {
            AntiMixup = 0,
            AntiHang = 1,
            AntiBlock = 2,
            AntiDown = 3,
            AntiVulnerable = 4,
            AntiStun = 5,
            QuirkOpportunity = 6,
            Dead = 7,
            Helpless = 14,
            Launched = 15,
            DoingAttack = 8,
            DoingStrongAttack = 9,
            DoingSpecialAttack = 10,
            DoingAttackUp = 11,
            DoingAttackMid = 12,
            DoingAttackDown = 13
        }
    }
}
