using MovesetParser.BulkSerialize;

namespace MovesetParser.Misc
{
    [Serializable]
    public class MovementConfig : IBulkSerializer
    {
        public bool GetParented;
        public bool LeaveEdges;
        public bool PassThrough;
        public bool FallThrough;
        public bool IgnoreMovingStage;
        public bool Bounce;
        public bool Stop;
        public bool LeaveParent;
        public float InheritParentVelocity;
        public StageLayer IgnoreStageLayer = StageLayer.None;
        public float LeaveEdgeRestrict;
        public bool SimpleFreeMovement;
        public float SimpleRadius;

        public MovementConfig() { }

        public void ReadSerial(Reader reader)
        {
            var version = reader.GetNextInt();

            GetParented = reader.GetNextInt() > 0;
            LeaveEdges = reader.GetNextInt() > 0;
            PassThrough = reader.GetNextInt() > 0;
            FallThrough = reader.GetNextInt() > 0;
            IgnoreMovingStage = reader.GetNextInt() > 0;
            Bounce = reader.GetNextInt() > 0;
            Stop = reader.GetNextInt() > 0;
            LeaveParent = reader.GetNextInt() > 0;
            IgnoreStageLayer = (StageLayer)reader.GetNextInt();
            InheritParentVelocity = reader.GetNextFloat();
            LeaveEdgeRestrict = reader.GetNextFloat();

            if (version > 0)
            {
                SimpleFreeMovement = reader.GetNextInt() > 0;
                SimpleRadius = reader.GetNextFloat();
            }
        }

        public void WriteSerial(Writer writer)
        {
            writer.AddInt(1);

            writer.AddInt(GetParented ? 7 : 0);
            writer.AddInt(LeaveEdges ? 7 : 0);
            writer.AddInt(PassThrough ? 7 : 0);
            writer.AddInt(FallThrough ? 7 : 0);
            writer.AddInt(IgnoreMovingStage ? 7 : 0);
            writer.AddInt(Bounce ? 7 : 0);
            writer.AddInt(Stop ? 7 : 0);
            writer.AddInt(LeaveParent ? 7 : 0);
            writer.AddInt((int)IgnoreStageLayer);
            writer.AddFloat(InheritParentVelocity);
            writer.AddFloat(LeaveEdgeRestrict);
            writer.AddInt(SimpleFreeMovement ? 7 : 0);
            writer.AddFloat(SimpleRadius);
        }
    }
}
