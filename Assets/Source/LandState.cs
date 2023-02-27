using UnityEngine;

public class LandState : IState
{
    IAnimationPlayer animationPlayer;
    IHuman human;
    public LandState(IHuman human)
    {
        this.human = human;
        this.animationPlayer = human.AnimationPlayer;
    }
    public void OnEnter() => animationPlayer.StartAnimation("Land");
    public void OnUpdate() => Debug.Log("LandUpdate");
    public void OnFixedUpdate() => Debug.Log("LandFixedUpdate"); 
    public void OnExit()
    {

    }
    public IState NextState()
    {
        return new WalkState(human);
    }
}