public class HumanStateMachine : IState
{
    class StateMachineHuman : IHuman
    {
        HumanStateMachine stateMachine;
        public StateMachineHuman(HumanStateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
        }

        public IHumanSize HumanSize()=> stateMachine.state.Human().HumanSize();
        public IMoveInfo MoveInfo()=> stateMachine.state.Human().MoveInfo();
    }
    IHuman human;
    IState state;
    public HumanStateMachine(IState state)
    {
        this.state = state;
        this.human = new StateMachineHuman(this);
    }
    public IState NextState() => state = state.NextState();
    public IHuman Human() => human;
}