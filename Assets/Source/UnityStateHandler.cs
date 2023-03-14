public class UnityStateHandler : IStateHandler
{
    IState currentState;
    public UnityStateHandler(IEvent update, IState currentState)
    {
        this.currentState = currentState;
        update.Subscribe(Update);
    }
    void Update()
    {
        if(currentState != currentState.NextState())
        {
            currentState = currentState.NextState();
        }
    }
    public IState CurrentState() => currentState;
}