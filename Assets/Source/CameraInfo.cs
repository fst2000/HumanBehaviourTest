using UnityEngine;

public class CameraInfo : ICameraInfo
{
    Vector3 offset;
    float smoothness;
    public CameraInfo(Vector3 offset, float smoothness)
    {
        this.offset = offset;
        this.smoothness = smoothness;
    }
    public Vector3 Offset()=> offset;
    public float Smoothness()=> smoothness;
}