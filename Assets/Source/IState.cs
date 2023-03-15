public interface IState
{
    IState NextState();
    IHuman Human();
}