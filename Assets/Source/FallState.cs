using UnityEngine;

public class FallState : IState
{
    public void OnEnter() => Debug.Log("FallEnter");
    public void OnUpdate() => Debug.Log("FallUpdate");
    public void OnFixedUpdate() => Debug.Log("FallFixedUpdate"); 
    public void OnExit() => Debug.Log("FallStateExit");
    public IState NextState()
    {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            return new WalkState();
        }
        else return this;
    }
}