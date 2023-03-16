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
        this.transform = gameObject.transform;
        this.rigidbody = gameObject.AddComponent<Rigidbody>();
        rigidbody.freezeRotation = true;
        rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
        rigidbody.interpolation = RigidbodyInterpolation.Interpolate;
        this.moveInfo = moveInfo;
        this.controller = controller;
    }
    public void FixedUpdate()
    {
        Vector2 input = controller.Input();
        float moveSpeed = moveInfo.MoveSpeed();
        Vector3 gravityVector = new Vector3(0,rigidbody.velocity.y,0);
        Vector3 localDirection = new Vector3(input.x,0,input.y);
        Vector3 globalDirection = transform.TransformDirection(localDirection);
        Vector3 velocity = new Vector3(globalDirection.x,0,globalDirection.z).normalized * moveSpeed + gravityVector;
        rigidbody.velocity = velocity;
    }
}