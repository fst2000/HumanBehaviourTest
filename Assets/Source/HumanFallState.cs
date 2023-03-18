
public class HumanFallState : IHumanState
{
    IAnimator animator;
    IBoolProducer isOnGround;
    IHuman human;
    IController controller;
    IMoveSystem moveSystem;
    public HumanFallState(IAnimator animator, IBoolProducer isOnGround, IController controller, IMoveSystem moveSystem)
    {
        this.animator = animator;
        this.isOnGround = isOnGround;
        animator.StartAnimation("Fall");
        this.controller = controller;
        this.moveSystem = moveSystem;

        human = new CommonHuman(new FixedHumanSize(1.8f,0.25f), new HumanFallMoveInfo(controller));
    }
    public IHumanState NextState()
    {
        if(isOnGround.Get())
        {
            return new HumanWalkState(animator,isOnGround, controller, moveSystem);
        }
        else return this;
    }
    public IHuman Human() => human;
}