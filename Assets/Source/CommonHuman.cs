public class CommonHuman : IHuman
{
    IHumanSize size;
    IMoveInfo moveInfo;
    public CommonHuman(IHumanSize size, IMoveInfo moveInfo)
    {
        this.size = size;
        this.moveInfo = moveInfo;
    }
    public IHumanSize HumanSize()=> size;
    public IMoveInfo MoveInfo()=> moveInfo;

}