public class CommonHuman : IHuman
{
    IHumanSize size;
    IMovement moveInfo;
    public CommonHuman(IHumanSize size, IMovement moveInfo)
    {
        this.size = size;
        this.moveInfo = moveInfo;
    }
    public IHumanSize HumanSize()=> size;
    public IMovement MoveInfo()=> moveInfo;

}