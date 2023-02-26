using UnityEngine;

public class FallState : IState
{
    IAnimationPlayer animationPlayer;
    public FallState(IAnimationPlayer animationPlayer)
    {
        this.animationPlayer = animationPlayer;
    }
    public void OnEnter() => animationPlayer.StartAnimation("Fall");
    public void OnUpdate() => Debug.Log("FallUpdate");
    public void OnFixedUpdate() => Debug.Log("FallFixedUpdate"); 
    public void OnExit() => Debug.Log("FallStateExit");
    public IState NextState()
    {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            return new WalkState(animationPlayer);
        }
        else return this;
    }
}