using UnityEngine;

public class WalkState : IState
{
    IAnimator animator;
    IMovableCollider collider;
    IBoolProducer isOnGround;
    IMoveSystem moveSystem;
    public WalkState(IBoolProducer isOnGround, IAnimator animator, IMoveSystem moveSystem, IMovableCollider collider)
    {
        this.isOnGround = isOnGround;
        this.animator = animator;
        this.moveSystem = moveSystem;
        this.collider = collider;
    }
    public void OnEnter()
    {
        animator.StartAnimation("WalkBlend");
        collider.Height = 1.8f;
        collider.Width = 0.4f;
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
        else return new FallState(isOnGround,animator,moveSystem,collider);
    }
}