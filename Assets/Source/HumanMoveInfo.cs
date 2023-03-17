using UnityEngine;
public class WalkMoveInfo : IMoveInfo
{
    float moveSpeed;
    IController controller;
    public WalkMoveInfo(IController controller)
    {
        moveSpeed = 3f;
        this.controller = controller;
    }
    public float Speed()=> moveSpeed;
    public Vector3 Direction()=> new Vector3(controller.Input().x, 0, controller.Input().y);
}