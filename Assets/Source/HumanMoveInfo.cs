public class HumanMoveInfo : IMoveInfo
{
    float moveSpeed;
    public HumanMoveInfo(float moveSpeed)
    {
        this.moveSpeed = moveSpeed;
    }
    public float MoveSpeed()=> moveSpeed;
}