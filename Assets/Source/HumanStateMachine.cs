public class HumanStateMachine : IHumanState
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
    IHumanState state;
    public HumanStateMachine(IHumanState state)
    {
        this.state = state;
        this.human = new StateMachineHuman(this);
    }
    public IHumanState NextState() => state = state.NextState();
    public IHuman Human() => human;
}