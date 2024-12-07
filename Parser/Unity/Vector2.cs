namespace MovesetParser.Unity
{
    [Serializable]
    public class Vector2
    {
        public static Vector2 zero => zeroVector;
        private static readonly Vector2 zeroVector = new Vector2(0, 0);

        public float x;
        public float y;

        public Vector2 (float x, float y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
