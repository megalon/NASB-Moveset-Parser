using MovesetParser.BulkSerialize;

namespace MovesetParser.FloatSources
{
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
            BlockHoldVertical = 8,
            BlockHoldHorizontal = 9,
            CheckBlastzones = 14,
            CheckTopBlastzone = 15,
            AlwaysLaunch = 24,
            PreventHitstunTurn = 28,
            PreventLaunches = 29,
            CanGrabClang = 32,
            DamageTaken = 4,
            InvincibleBoonFrames = 5,
            RespawnInvincibleFrames = 6,
            IsProjectile = 25,
            ProjectileLevel = 7,
            LastDIType = 10,
            LastDIIn = 11,
            LastDIOut = 12,
            LastBlastzone = 13,
            LastTurn = 16,
            LastRedirectX = 17,
            LastRedirectY = 18,
            LaunchedByPlayerIndex = 19,
            LaunchedByTeam = 20,
            LaunchedByGameTeam = 26,
            LastHitType = 21,
            LastHitDirection = 22,
            LastHitForceJabReset = 27,
            LastHitForward = 23,
            ChainCount = 30,
            ComboCount = 31
        }
    }
}
