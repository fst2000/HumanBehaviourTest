using UnityEngine;

public class LandState : IState
{
    IBoolProducer isOnGround;
    IAnimator animator;
    IAnimationInfo animationInfo;
    IMoveSystem moveSystem;
    IMovableCollider collider;
    public LandState(IBoolProducer isOnGround, IAnimator animator, IMoveSystem moveSystem, IMovableCollider collider)
    {
        this.isOnGround = isOnGround;
        this.animator = animator;
        this.moveSystem = moveSystem;
        this.collider = collider;
    }
    public void OnEnter() => animationInfo = animator.StartAnimation("Land");
    public void OnUpdate() => Debug.Log("LandUpdate");
    public void OnFixedUpdate() => Debug.Log("LandFixedUpdate"); 
    public void OnExit()
    {

    }
    public IState NextState()
    {
        if(animationInfo.isPlaying())
        {
            return this;
        }
        else return new WalkState(isOnGround,animator,moveSystem,collider);
    }
}