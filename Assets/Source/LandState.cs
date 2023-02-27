using UnityEngine;

public class LandState : IState
{
    IAnimator animator;
    IHuman human;
    IAnimationInfo animationInfo;
    public LandState(IHuman human)
    {
        this.human = human;
        this.animator = human.Animator;
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
        else return new WalkState(human);
    }
}