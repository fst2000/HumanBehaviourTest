using UnityEngine;
public class HumanFallMovement : IMovement
{
    public Vector3 Velocity()=> Vector3.zero;
    public Quaternion Torque()=> Quaternion.identity;

}