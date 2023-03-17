
public class HumanFallState : IHumanState
{
    IAnimator animator;
    IBoolProducer isOnGround;
    IHuman human;
    IController controller;
    public HumanFallState(IAnimator animator, IBoolProducer isOnGround, IController controller)
    {
        this.animator = animator;
        this.isOnGround = isOnGround;
        animator.StartAnimation("Fall");
        this.controller = controller;

        human = new CommonHuman(new FixedHumanSize(1.8f,0.25f), new WalkMoveInfo(controller));
    }
    public IHumanState NextState()
    {
        if(isOnGround.Get())
        {
            return new HumanWalkState(animator,isOnGround, controller);
        }
        else return this;
    }
    public IHuman Human() => human;
}