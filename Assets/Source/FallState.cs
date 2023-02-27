using UnityEngine;

public class FallState : IState
{
    IHuman human;
    IAnimator animator;
    public FallState(IHuman human)
    {
        this.human = human;
        this.animator = human.Animator;
    }
    public void OnEnter() => animator.StartAnimation("Fall");
    public void OnUpdate() => Debug.Log("FallUpdate");
    public void OnFixedUpdate() => Debug.Log("FallFixedUpdate"); 
    public void OnExit() => Debug.Log("FallStateExit");
    public IState NextState()
    {
        if(human.IsOnGround())
        {
            return new LandState(human);
        }
        else return this;
    }
}