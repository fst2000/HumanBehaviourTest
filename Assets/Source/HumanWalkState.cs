
public class HumanWalkState : IHumanState
{
    IAnimator animator;
    IBoolProducer isOnGround;
    IHuman human;
    IController controller;
    public HumanWalkState(IAnimator animator, IBoolProducer isOnGround, IController controller)
    {
        this.animator = animator;
        this.isOnGround = isOnGround;
        animator.StartAnimation("WalkBlend");
        this.controller = controller;

        human = new CommonHuman(new FixedHumanSize(1.8f,0.25f), new WalkMoveInfo(controller));
    }
    public IHumanState NextState()
    {
        if(isOnGround.Get())
        {
            return this;
        }
        else return new HumanFallState(animator, isOnGround, controller);
    }
    public IHuman Human() => human;
}