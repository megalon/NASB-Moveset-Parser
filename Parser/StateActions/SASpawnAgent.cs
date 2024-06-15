using MovesetParser.BulkSerialize;
using MovesetParser.FloatSources;
using MovesetParser.Misc;

namespace MovesetParser.StateActions
{
    public class SASpawnAgent : StateAction, IBulkSerializer
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
        public SAGUAMessageObject GuaMessageObject = new SAGUAMessageObject();
        public FloatSourceContainer ResultOrderAdded;

        public SASpawnAgent() { }

        private void EnsureStuff()
        {
            LocalOffsetX ??= new FloatSourceContainer(new FloatSource());
            LocalOffsetY ??= new FloatSourceContainer(new FloatSource());
            LocalOffsetZ ??= new FloatSourceContainer(new FloatSource());
            WorldOffsetX ??= new FloatSourceContainer(new FloatSource());
            WorldOffsetY ??= new FloatSourceContainer(new FloatSource());
            WorldOffsetZ ??= new FloatSourceContainer(new FloatSource());
            ResultOrderAdded ??= new FloatSourceContainer(new FloatSource());
            GuaMessageObject ??= new SAGUAMessageObject();
            CustomSpawnMovements ??= new SpawnMovement[0];

            for (int i = 0; i < CustomSpawnMovements.Length; i++)
            {
                CustomSpawnMovements[i] ??= new SpawnMovement();
            }
        }

        public new static SASpawnAgent ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            var version = reader.GetNextInt();

            var spawnAgent = new SASpawnAgent
            {
                TID = TypeId.SASpawnAgent,
                Bank = reader.GetNextString(),
                Id = reader.GetNextString(),
                Bone = reader.GetNextString()
            };

            if (version > 1)
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

            spawnAgent.GuaMessageObject = SAGUAMessageObject.ReadSerial(reader);
            spawnAgent.CustomSpawnMovement = reader.GetNextInt() > 0;

            int customSpawnMovementsCount = reader.GetNextInt();
            spawnAgent.CustomSpawnMovements = new SpawnMovement[customSpawnMovementsCount];

            for (int i = 0; i < customSpawnMovementsCount; i++)
            {
                SpawnMovement spawnMovement = new SpawnMovement();
                spawnMovement.ReadSerial(reader);
                spawnAgent.CustomSpawnMovements[i] = spawnMovement;
            }

            if (version < 1)
            {
                spawnAgent.EnsureStuff();
                return spawnAgent;
            }

            spawnAgent.ResultOrderAdded = FloatSourceContainer.ReadSerial(reader);

            return spawnAgent;
        }

        public override void WriteSerial(Writer writer)
        {
            EnsureStuff();

            writer.AddInt(34);
            writer.AddInt(2);

            writer.AddString(Bank);
            writer.AddString(Id);
            writer.AddString(Bone);
            LocalOffsetX.WriteSerial(writer);
            LocalOffsetY.WriteSerial(writer);
            LocalOffsetZ.WriteSerial(writer);
            WorldOffsetX.WriteSerial(writer);
            WorldOffsetY.WriteSerial(writer);
            WorldOffsetZ.WriteSerial(writer);
            GuaMessageObject.WriteSerial(writer);
            writer.AddInt(CustomSpawnMovement ? 7 : 0);
            writer.AddInt(CustomSpawnMovements.Length);

            for (int i = 0; i < CustomSpawnMovements.Length; i++)
            {
                CustomSpawnMovements[i].WriteSerial(writer);
            }

            ResultOrderAdded.WriteSerial(writer);
        }
    }
}
