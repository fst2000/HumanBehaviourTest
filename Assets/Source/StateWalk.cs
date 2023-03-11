using UnityEngine;

public class StateWalk : IState
{
    IAnimator animator;
    IBoolProducer isOnGround;
    IMoveSystem moveSystem;

    float moveSpeed = 5f;
    public StateWalk(IAnimator animator, IBoolProducer isOnGround, IMoveSystem moveSystem)
    {
        this.animator = animator;
        this.isOnGround = isOnGround;
        this.moveSystem = moveSystem;
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
        else return new StateWalk(animator, isOnGround, moveSystem);
    }

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }
}