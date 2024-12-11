using MovesetParser.BulkSerialize;

namespace MovesetParser.FloatSources
{
    [Serializable]
    public class FSCombat : FloatSource, IBulkSerializer
    {
        public CombatAttribute Attribute;

        public FSCombat() { }

        public new static FSCombat ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            return new FSCombat
            {
                TID = TypeId.FSCombat,
                Attribute = (CombatAttribute)reader.GetNextInt()
            };
        }

        public override void WriteSerial(Writer writer)
        {
            writer.AddInt(8);
            writer.AddInt(0);

            writer.AddInt((int)Attribute);
        }

        public enum CombatAttribute
        {
            Weight = 0,
            GetGrabbed = 1,
            GrabInvulnerability = 2,
            BlockPush = 3,
            DamageTaken = 4,
            InvincibleBoonFrames = 5,
            RespawnInvincibleFrames = 6,
            ProjectileLevel = 7,
            BlockHoldVertical = 8,
            BlockHoldHorizontal = 9,
            LastDIType = 10,
            LastDIIn = 11,
            LastDIOut = 12,
            LastBlastzone = 13,
            CheckBlastzones = 14,
            CheckTopBlastzone = 15,
            LastTurn = 16,
            LastRedirectX = 17,
            LastRedirectY = 18,
            LaunchedByPlayerIndex = 19,
            LaunchedByTeam = 20,
            LastHitType = 21,
            LastHitDirection = 22,
            LastHitForward = 23,
            AlwaysLaunch = 24,
            IsProjectile = 25,
            LaunchedByGameTeam = 26,
            LastHitForceJabReset = 27,
            PreventHitstunTurn = 28,
            PreventLaunches = 29,
            ChainCount = 30,
            ComboCount = 31,
            CanGrabClang = 32
        }
    }
}
