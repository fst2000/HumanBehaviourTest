using UnityEngine;

public class WalkState : IState
{
    IHuman human;
    IAnimationPlayer animationPlayer;
    public WalkState(IHuman human)
    {
        this.human = human;
        this.animationPlayer = human.AnimationPlayer;
    }
    public void OnEnter() => animationPlayer.StartAnimation("WalkBlend");
    public void OnUpdate() => Debug.Log("WalkUpdate");
    public void OnFixedUpdate() => Debug.Log("WalkFixedUpdate"); 
    public void OnExit()
    {

    }
    public IState NextState()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            return new FallState(human);
        }
        else return this;
    }
}