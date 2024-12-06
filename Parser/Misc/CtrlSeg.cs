namespace MovesetParser.Misc
{
    [Serializable]
    public enum CtrlSeg
    {
        Neutral = 1,
        Up = 2,
        Down = 4,
        Right = 8,
        Left = 0x10,
        UpRight = 0x20,
        UpLeft = 0x40,
        DownRight = 0x80,
        DownLeft = 0x100
    }
}
