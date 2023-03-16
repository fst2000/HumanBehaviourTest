
public class HumanWalkState : IHumanState
{
    IAnimator animator;
    IBoolProducer isOnGround;
    IHuman human;
    public HumanWalkState(IAnimator animator, IBoolProducer isOnGround)
    {
        this.animator = animator;
        this.isOnGround = isOnGround;
        animator.StartAnimation("WalkBlend");

        human = new CommonHuman(new FixedHumanSize(1.8f,0.25f), new HumanMoveInfo(3f));
    }
    public IHumanState NextState()
    {
        if(isOnGround.Get())
        {
            return this;
        }
        else return new HumanFallState(animator, isOnGround);
    }
    public IHuman Human() => human;
}