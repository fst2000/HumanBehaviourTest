using UnityEngine;
public class HumanWalkMoveInfo : IMoveInfo
{
    float moveSpeed;
    float rotationSpeed;
    IController controller;
    public HumanWalkMoveInfo(IController controller)
    {
        moveSpeed = 3f;
        rotationSpeed = 3f;
        this.controller = controller;
    }
    public float MoveSpeed()=> moveSpeed;
    public float RotationSpeed()=> rotationSpeed;
    public Vector3 Direction()=> new Vector3(0, 0, controller.Input().y);
    public Quaternion Rotation()=> Quaternion.Euler(0,controller.Input().x,0);
}