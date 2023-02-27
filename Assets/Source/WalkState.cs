using UnityEngine;

public class WalkState : IState
{
    IHuman human;
    IAnimator animator;
    public WalkState(IHuman human)
    {
        this.human = human;
        this.animator = human.Animator;
    }
    public void OnEnter() => animator.StartAnimation("WalkBlend");
    public void OnUpdate() => Debug.Log("WalkUpdate");
    public void OnFixedUpdate() => Debug.Log("WalkFixedUpdate"); 
    public void OnExit()
    {

    }
    public IState NextState()
    {
        if(human.IsOnGround())
        {
            return this;
        }
        else return new FallState(human);
    }
}