namespace MovesetParser.Unity
{
    [Serializable]
    public class Vector3
    {
        public static Vector3 zero => zeroVector;
        private static readonly Vector3 zeroVector = new Vector3(0, 0, 0);

        public float x, y, z;

        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }
}
