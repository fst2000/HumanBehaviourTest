using UnityEngine;

public class HumanStateMachine : IHumanState
{
    IHuman human;
    IHumanState state;
    public HumanStateMachine(IHumanState state)
    {
        this.state = state;
        this.human = new CommonHuman(
            new HumanSizeWrapper(() => this.state.Human().HumanSize()),
            new MovementWrapper(() => this.state.Human().MoveInfo()));
    }
    public IHumanState NextState() => state = state.NextState();
    public IHuman Human() => human;
}