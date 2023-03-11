public class UnityStateHandler : IStateHandler
{
    IState currentState;
    public UnityStateHandler(IEvent update, IEvent fixedUpdate, IState currentState)
    {
        this.currentState = currentState;
        update.Subscribe(Update);
        fixedUpdate.Subscribe(FixedUpdate);
    }
    void Update()
    {
        currentState.OnUpdate();
        if(currentState != currentState.NextState())
        {
            currentState.OnExit();
            currentState = currentState.NextState();
            currentState.OnEnter();
        }
    }
    void FixedUpdate()
    {
        currentState.OnFixedUpdate();
    }
}