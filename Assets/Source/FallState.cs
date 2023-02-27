using UnityEngine;

public class FallState : IState
{
    IHuman human;
    IAnimationPlayer animationPlayer;
    public FallState(IHuman human)
    {
        this.animationPlayer = human.AnimationPlayer;
    }
    public void OnEnter() => animationPlayer.StartAnimation("Fall");
    public void OnUpdate() => Debug.Log("FallUpdate");
    public void OnFixedUpdate() => Debug.Log("FallFixedUpdate"); 
    public void OnExit() => Debug.Log("FallStateExit");
    public IState NextState()
    {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            return new WalkState(human);
        }
        else return this;
    }
}