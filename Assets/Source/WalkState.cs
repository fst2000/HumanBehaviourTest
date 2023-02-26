using UnityEngine;

public class WalkState : IState
{
    IAnimationPlayer animationPlayer;
    public WalkState(IAnimationPlayer animationPlayer)
    {
        this.animationPlayer = animationPlayer;
    }
    public void OnEnter() => animationPlayer.StartAnimation("Land");
    public void OnUpdate() => Debug.Log("WalkUpdate" + animationPlayer.CheckAnimation("Land"));
    public void OnFixedUpdate() => Debug.Log("WalkFixedUpdate"); 
    public void OnExit()
    {

    }
    public IState NextState()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            return new FallState(animationPlayer);
        }
        else return this;
    }
}