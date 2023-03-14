using UnityEngine;
public class RigidBodyMoveSystem : IMoveSystem
{
    Rigidbody rigidbody;
    Transform transform;
    IController controller;
    IMoveInfo moveInfo;
    public RigidBodyMoveSystem(IEvent fixedUpdate, GameObject gameObject, IController controller, IMoveInfo moveInfo)
    {
        fixedUpdate.Subscribe(FixedUpdate);
        this.rigidbody = gameObject.AddComponent<Rigidbody>();
        rigidbody.freezeRotation = true;
        this.moveInfo = moveInfo;
        this.controller = controller;
    }
    public void FixedUpdate()
    {
        Vector2 input = controller.Input();
        float moveSpeed = moveInfo.MoveSpeed();
        Vector3 direction = new Vector3(input.x * moveSpeed,rigidbody.velocity.y,input.y * moveSpeed);
        rigidbody.velocity = direction;
    }
}