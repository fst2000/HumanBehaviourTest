public class CameraStateMachine : ICameraState
{
    ICameraState state;
    public CameraStateMachine(ICameraState state)
    {
        this.state = state;
    }
    public ICameraState NextState()=> state = state.NextState();
    public ICameraInfo CameraInfo()=> state.CameraInfo();
}