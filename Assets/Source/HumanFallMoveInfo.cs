using UnityEngine;
public class HumanFallMoveInfo : IMoveInfo
{
    float moveSpeed;
    float rotationSpeed;
    IController controller;
    public HumanFallMoveInfo(IController controller)
    {
        moveSpeed = 0f;
        rotationSpeed = 0f;
        this.controller = controller;
    }
    public float MoveSpeed()=> moveSpeed;
    public float RotationSpeed()=> rotationSpeed;
    public Vector3 Direction()=> Vector3.zero;
    public Quaternion Rotation()=> Quaternion.Euler(0,0,0);

}