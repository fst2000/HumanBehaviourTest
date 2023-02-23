using UnityEngine;

public class WalkState : IState
{
    public void OnEnter() => Debug.Log("WalkEnter");
    public void OnUpdate() => Debug.Log("WalkUpdate");
    public void OnFixedUpdate() => Debug.Log("WalkFixedUpdate"); 
    public void OnExit()
    {

    }
    public IState NextState()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            return new FallState();
        }
        else return this;
    }
}