namespace MovesetParser.Misc
{
    public enum GIEV
    {
        None = 0,
        Unplugged = 1,
        ActionFromFrame = 2,
        SpecialFromFrame = 4,
        OffenseFromFrame = 8,
        DefenseFromFrame = 0x10,
        JumpFromFrame = 0x20,
        Grounded = 0x40
    }
}
