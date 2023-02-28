using UnityEngine;

public class FallState : IState
{
    IAnimator animator;
    IMovableCollider collider;
    IBoolProducer isOnGround;
    IMoveSystem moveSystem;
    public FallState(IBoolProducer isOnGround, IAnimator animator, IMoveSystem moveSystem, IMovableCollider collider)
    {
        this.isOnGround = isOnGround;
        this.animator = animator;
        this.moveSystem = moveSystem;
        this.collider = collider;
    }
    public void OnEnter() => animator.StartAnimation("Fall");
    public void OnUpdate() => Debug.Log("FallUpdate");
    public void OnFixedUpdate() => Debug.Log("FallFixedUpdate"); 
    public void OnExit() => Debug.Log("FallStateExit");
    public IState NextState()
    {
        if(isOnGround.Get())
        {
            return new LandState(isOnGround,animator,moveSystem,collider);
        }
        else return this;
    }
}