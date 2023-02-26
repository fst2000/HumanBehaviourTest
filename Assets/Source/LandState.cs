using UnityEngine;

public class LandState : IState
{
    IAnimationPlayer animationPlayer;
    public LandState(IAnimationPlayer animationPlayer)
    {
        this.animationPlayer = animationPlayer;
    }
    public void OnEnter() => animationPlayer.StartAnimation("Land");
    public void OnUpdate() => Debug.Log("LandUpdate");
    public void OnFixedUpdate() => Debug.Log("LandFixedUpdate"); 
    public void OnExit()
    {

    }
    public IState NextState()
    {
        if(Input.GetKeyDown("H"))
        {
            return new FallState(animationPlayer);
        }
        else return this;
    }
}