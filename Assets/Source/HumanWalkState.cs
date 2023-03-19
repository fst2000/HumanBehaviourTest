public class HumanWalkState : IHumanState
{
    IAnimator animator;
    IBoolProducer isOnGround;
    IHuman human;
    IController controller;
    IMoveSystem moveSystem;
    public HumanWalkState(IAnimator animator, IBoolProducer isOnGround, IController controller, IMoveSystem moveSystem)
    {
        this.animator = animator;
        this.isOnGround = isOnGround;
        this.controller = controller;
        animator.StartAnimation("WalkBlend");
        human = new CommonHuman(new FixedHumanSize(1.8f,0.25f), new HumanWalkMovement(controller));
    }
    public IHumanState NextState()
    {
        if(isOnGround.Get())
        {
            return this;
        }
        else return new HumanFallState(animator, isOnGround, controller, moveSystem);
    }
    public IHuman Human() => human;
}