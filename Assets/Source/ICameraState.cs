public interface ICameraState
{
    ICameraState NextState();
    ICameraInfo CameraInfo();
}