using MovesetParser.BulkSerialize;
using MovesetParser.FloatSources;
using MovesetParser.Misc;

namespace MovesetParser.StateActions
{
    [Serializable]
    public class SASpawnAgent2 : StateAction, IBulkSerializer
    {
        public string Bank = string.Empty;
        public string Id = string.Empty;
        public string Bone = string.Empty;
        public FloatSourceContainer LocalOffsetX;
        public FloatSourceContainer LocalOffsetY;
        public FloatSourceContainer LocalOffsetZ;
        public FloatSourceContainer WorldOffsetX;
        public FloatSourceContainer WorldOffsetY;
        public FloatSourceContainer WorldOffsetZ;
        public bool CustomSpawnMovement;
        public SpawnMovement[] CustomSpawnMovements;
        public string SpawnedAgentDataId = string.Empty;
        public FloatSourceContainer SpawnedAgentDataSetValue;
        public FloatSourceContainer ResultOrderAdded;
        public bool SetPlayerIndex;
        public bool SetAttackTeam;
        public bool SetDefendTeam;
        public bool SetProjectileLevel;
        public bool SetDirection;
        public bool SetRedirect;
        public FloatSourceContainer PlayerIndex;
        public FloatSourceContainer AttackTeam;
        public FloatSourceContainer DefendTeam;
        public FloatSourceContainer ProjectileLevel;
        public FloatSourceContainer Direction;
        public FloatSourceContainer RedirectX;
        public FloatSourceContainer RedirectY;
        public bool ExactSpawn;
        public AddedSpawnedData[] AddedSpawnedDatas;

        public SASpawnAgent2() { }

        private void EnsureStuff()
        {
            LocalOffsetX ??= new FloatSourceContainer(new FloatSource());
            LocalOffsetY ??= new FloatSourceContainer(new FloatSource());
            LocalOffsetZ ??= new FloatSourceContainer(new FloatSource());
            WorldOffsetX ??= new FloatSourceContainer(new FloatSource());
            WorldOffsetY ??= new FloatSourceContainer(new FloatSource());
            WorldOffsetZ ??= new FloatSourceContainer(new FloatSource());
            SpawnedAgentDataSetValue ??= new FloatSourceContainer(new FloatSource());
            ResultOrderAdded ??= new FloatSourceContainer(new FloatSource());
            PlayerIndex ??= new FloatSourceContainer(new FloatSource());
            AttackTeam ??= new FloatSourceContainer(new FloatSource());
            DefendTeam ??= new FloatSourceContainer(new FloatSource());
            ProjectileLevel ??= new FloatSourceContainer(new FloatSource());
            Direction ??= new FloatSourceContainer(new FloatSource());
            RedirectX ??= new FloatSourceContainer(new FloatSource());
            RedirectY ??= new FloatSourceContainer(new FloatSource());
            CustomSpawnMovements ??= new SpawnMovement[0];

            for (int i = 0; i < CustomSpawnMovements.Length; i++)
            {
                CustomSpawnMovements[i] ??= new SpawnMovement();
            }

            AddedSpawnedDatas ??= new AddedSpawnedData[0];

            for (int j = 0; j < AddedSpawnedDatas.Length; j++)
            {
                AddedSpawnedDatas[j] ??= new AddedSpawnedData();
                AddedSpawnedDatas[j].spawnedAgentDataSetValue ??= new FloatSourceContainer(new FloatSource());
            }
        }

        public new static SASpawnAgent2 ReadSerial(Reader reader)
        {
            reader.GetNextInt();

            var version = reader.GetNextInt();

            var spawnAgent = new SASpawnAgent2
            {
                TID = TypeId.SASpawnAgent2,
                Bank = reader.GetNextString(),
                Id = reader.GetNextString(),
                Bone = reader.GetNextString()
            };

            if (version > 2)
            {
                spawnAgent.LocalOffsetX = FloatSourceContainer.ReadSerial(reader);
                spawnAgent.LocalOffsetY = FloatSourceContainer.ReadSerial(reader);
                spawnAgent.LocalOffsetZ = FloatSourceContainer.ReadSerial(reader);
                spawnAgent.WorldOffsetX = FloatSourceContainer.ReadSerial(reader);
                spawnAgent.WorldOffsetY = FloatSourceContainer.ReadSerial(reader);
                spawnAgent.WorldOffsetZ = FloatSourceContainer.ReadSerial(reader);
            }
            else
            {
                spawnAgent.LocalOffsetX = new FloatSourceContainer(new FloatSource(reader.GetNextFloat()));
                spawnAgent.LocalOffsetY = new FloatSourceContainer(new FloatSource(reader.GetNextFloat()));
                spawnAgent.LocalOffsetZ = new FloatSourceContainer(new FloatSource(reader.GetNextFloat()));
                spawnAgent.WorldOffsetX = new FloatSourceContainer(new FloatSource(reader.GetNextFloat()));
                spawnAgent.WorldOffsetY = new FloatSourceContainer(new FloatSource(reader.GetNextFloat()));
                spawnAgent.WorldOffsetZ = new FloatSourceContainer(new FloatSource(reader.GetNextFloat()));
            }

            spawnAgent.CustomSpawnMovement = reader.GetNextInt() > 0;
            var customSpawnMovementsCount = reader.GetNextInt();
            spawnAgent.CustomSpawnMovements = new SpawnMovement[customSpawnMovementsCount];

            for (int i = 0; i < customSpawnMovementsCount; i++)
            {
                SpawnMovement spawnMovement = new SpawnMovement();
                spawnMovement.ReadSerial(reader);
                spawnAgent.CustomSpawnMovements[i] = spawnMovement;
            }

            spawnAgent.SpawnedAgentDataId = reader.GetNextString();
            spawnAgent.SpawnedAgentDataSetValue = FloatSourceContainer.ReadSerial(reader);
            spawnAgent.ResultOrderAdded = FloatSourceContainer.ReadSerial(reader);

            var b = (byte)reader.GetNextInt();
            spawnAgent.SetPlayerIndex = ByteUtility.GetBit(b, 0);
            spawnAgent.SetAttackTeam = ByteUtility.GetBit(b, 1);
            spawnAgent.SetDefendTeam = ByteUtility.GetBit(b, 2);
            spawnAgent.SetProjectileLevel = ByteUtility.GetBit(b, 3);
            spawnAgent.SetDirection = ByteUtility.GetBit(b, 4);
            spawnAgent.SetRedirect = ByteUtility.GetBit(b, 5);

            spawnAgent.PlayerIndex = FloatSourceContainer.ReadSerial(reader);
            spawnAgent.AttackTeam = FloatSourceContainer.ReadSerial(reader);
            spawnAgent.DefendTeam = FloatSourceContainer.ReadSerial(reader);
            spawnAgent.ProjectileLevel = FloatSourceContainer.ReadSerial(reader);
            spawnAgent.Direction = FloatSourceContainer.ReadSerial(reader);
            spawnAgent.RedirectX = FloatSourceContainer.ReadSerial(reader);
            spawnAgent.RedirectY = FloatSourceContainer.ReadSerial(reader);

            if (version > 0)
                spawnAgent.ExactSpawn = reader.GetNextInt() > 0;

            if (version > 1)
            {
                int nextInt3 = reader.GetNextInt();
                spawnAgent.AddedSpawnedDatas = new AddedSpawnedData[nextInt3];

                for (int j = 0; j < nextInt3; j++)
                {
                    var addedSpawnedData = new AddedSpawnedData
                    {
                        spawnedAgentDataId = reader.GetNextString(),
                        spawnedAgentDataSetValue = FloatSourceContainer.ReadSerial(reader)
                    };

                    spawnAgent.AddedSpawnedDatas[j] = addedSpawnedData;
                }
            }
            else
            {
                spawnAgent.AddedSpawnedDatas = new AddedSpawnedData[0];
            }

            return spawnAgent;
        }

        public override void WriteSerial(Writer writer)
        {
            EnsureStuff();

            writer.AddInt(69);
            writer.AddInt(3);

            writer.AddString(Bank);
            writer.AddString(Id);
            writer.AddString(Bone);
            LocalOffsetX.WriteSerial(writer);
            LocalOffsetY.WriteSerial(writer);
            LocalOffsetZ.WriteSerial(writer);
            WorldOffsetX.WriteSerial(writer);
            WorldOffsetY.WriteSerial(writer);
            WorldOffsetZ.WriteSerial(writer);
            writer.AddInt(CustomSpawnMovement ? 7 : 0);

            writer.AddInt(CustomSpawnMovements.Length);

            for (int i = 0; i < CustomSpawnMovements.Length; i++)
            {
                CustomSpawnMovements[i].WriteSerial(writer);
            }

            writer.AddString(SpawnedAgentDataId);
            SpawnedAgentDataSetValue.WriteSerial(writer);
            ResultOrderAdded.WriteSerial(writer);

            byte b = 0;
            b = ByteUtility.SetBit(b, 0, SetPlayerIndex);
            b = ByteUtility.SetBit(b, 1, SetAttackTeam);
            b = ByteUtility.SetBit(b, 2, SetDefendTeam);
            b = ByteUtility.SetBit(b, 3, SetProjectileLevel);
            b = ByteUtility.SetBit(b, 4, SetDirection);
            b = ByteUtility.SetBit(b, 5, SetRedirect);
            writer.AddInt(b);

            PlayerIndex.WriteSerial(writer);
            AttackTeam.WriteSerial(writer);
            DefendTeam.WriteSerial(writer);
            ProjectileLevel.WriteSerial(writer);
            Direction.WriteSerial(writer);
            RedirectX.WriteSerial(writer);
            RedirectY.WriteSerial(writer);
            writer.AddInt(ExactSpawn ? 7 : 0);

            writer.AddInt(AddedSpawnedDatas.Length);

            for (int j = 0; j < AddedSpawnedDatas.Length; j++)
            {
                writer.AddString(AddedSpawnedDatas[j].spawnedAgentDataId);
                AddedSpawnedDatas[j].spawnedAgentDataSetValue.WriteSerial(writer);
            }
        }

    [Serializable]
    public class AddedSpawnedData : IBulkSerializer
        {
            public string spawnedAgentDataId;
            public FloatSourceContainer spawnedAgentDataSetValue;

            public AddedSpawnedData() { }

            public void WriteSerial(Writer w)
            {
                w.AddString(spawnedAgentDataId);
                spawnedAgentDataSetValue.WriteSerial(w);
            }
        }
    }
}
