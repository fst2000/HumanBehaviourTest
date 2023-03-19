using UnityEngine;
public class RigidBodyMoveSystem : IMoveSystem
{
    Rigidbody rigidbody;
    Transform transform;
    IMovement moveInfo;
    public RigidBodyMoveSystem(IEvent fixedUpdate, GameObject gameObject, IMovement moveInfo)
    {
        fixedUpdate.Subscribe(FixedUpdate);
        this.transform = gameObject.transform;
        this.rigidbody = gameObject.AddComponent<Rigidbody>();
        rigidbody.freezeRotation = true;
        rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
        rigidbody.interpolation = RigidbodyInterpolation.Interpolate;
        this.moveInfo = moveInfo;
    }
    public void FixedUpdate()
    {
        Vector3 gravity = new Vector3(0, rigidbody.velocity.y, 0);
        rigidbody.velocity = transform.TransformDirection(moveInfo.Velocity()) + gravity;
        transform.rotation = moveInfo.Torque() * transform.rotation;
        Debug.Log(moveInfo.GetType());
    }
    public Vector3 Velocity()=> rigidbody.velocity;
}