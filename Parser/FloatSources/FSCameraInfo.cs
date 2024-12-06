using MovesetParser.BulkSerialize;

namespace MovesetParser.FloatSources
{
    [Serializable]
    public class FSCameraInfo : FloatSource, IBulkSerializer
    {
        public CameraAttribute Attribute;

        public FSCameraInfo() { }

        public new static FSCameraInfo ReadSerial(Reader reader)
        {
            reader.GetNextInt();
            reader.GetNextInt();

            return new FSCameraInfo
            {
                TID = TypeId.FSCameraInfo,
                Attribute = (CameraAttribute)reader.GetNextInt()
            };
        }

        public override void WriteSerial(Writer writer)
        {
            writer.AddInt(22);
            writer.AddInt(0);

            writer.AddInt((int)Attribute);
        }


        public enum CameraAttribute
        {
            ActiveInclude = 0,
            CenterRadius = 1,
            TrackLastGrounded = 2,
            AddXMovement = 3,
            AddYUpMovement = 4,
            AddYDownMovement = 5,
            ClampAddYDownByFloor = 6,
            AddUp = 7,
            AddDown = 8,
            AddRight = 9,
            AddLeft = 10,
            IncludeRespawnPoint = 11,
            IncludeLaunchDestination = 12,
            MoveResultsCamToFixedPos = 13,
            DontIncludeVertical = 14
        }
    }
}
