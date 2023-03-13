using UnityEngine;

public class HumanWalkState : IState
{
    IAnimator animator;
    IBoolProducer isOnGround;
    IMoveSystem moveSystem;
    IHumanSize humanSize;

    float moveSpeed = 5f;
    public HumanWalkState(IAnimator animator, IBoolProducer isOnGround, IMoveSystem moveSystem)
    {
        this.animator = animator;
        this.isOnGround = isOnGround;
        this.moveSystem = moveSystem;
        humanSize = new FixedHumanSize(1.8f, 0.25f);
    }
    public void OnEnter()
    {
        animator.StartAnimation("WalkBlend");
    }
    public void OnUpdate()
    {
        Debug.Log("WalkUpdate");
    }
    public void OnFixedUpdate()
    {
        Debug.Log("WalkFixedUpdate"); 
    }
    public void OnExit()
    {

    }
    public IState NextState()
    {
        if(isOnGround.Get())
        {
            return this;
        }
        else return new HumanWalkState(animator, isOnGround, moveSystem);
    }

    public float MoveSpeed()
    {
        return moveSpeed;
    }
    public IHumanSize HumanSize() => humanSize;
}