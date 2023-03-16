
public class HumanFallState : IHumanState
{
    IAnimator animator;
    IBoolProducer isOnGround;
    IHuman human;
    public HumanFallState(IAnimator animator, IBoolProducer isOnGround)
    {
        this.animator = animator;
        this.isOnGround = isOnGround;
        animator.StartAnimation("Fall");

        human = new CommonHuman(new FixedHumanSize(1.8f,0.25f), new HumanMoveInfo(0f));
    }
    public IHumanState NextState()
    {
        if(isOnGround.Get())
        {
            return new HumanWalkState(animator,isOnGround);
        }
        else return this;
    }
    public IHuman Human() => human;
}