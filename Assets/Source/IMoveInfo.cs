using UnityEngine;
public interface IMoveInfo
{
    float MoveSpeed();
    float RotationSpeed();
    Vector3 Direction();
    Quaternion Rotation();
    
}