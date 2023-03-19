using UnityEngine;
public interface IMovable
{
    void Velocity(Vector3 velocity);
    void Torque(Quaternion torque);
}