using UnityEngine;
public class CameraFollowState : ICameraState
{
    Vector3 offset;
    ICameraInfo cameraInfo;
    public CameraFollowState()
    {
        cameraInfo = new CameraInfo(new Vector3(0,1.5f,-3), 0.5f);
    }
    public ICameraState NextState()=> this;
    public ICameraInfo CameraInfo()=> cameraInfo;
}