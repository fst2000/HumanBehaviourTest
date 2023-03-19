using UnityEngine;

public class MovementWrapper : IMovement
{
    MoveInfoDelegate moveInfo;
    public MovementWrapper(MoveInfoDelegate moveInfo)
    {
        this.moveInfo = moveInfo;
    }
    public Quaternion Torque() => moveInfo().Torque();

    public Vector3 Velocity() => moveInfo().Velocity();
}
public delegate IMovement MoveInfoDelegate();