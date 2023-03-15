using UnityEngine;

public class HumanWalkState : IState
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
    public IState NextState()
    {
        if(isOnGround.Get())
        {
            return this;
        }
        else return new HumanWalkState(animator, isOnGround);
    }
    public IHuman Human() => human;
}