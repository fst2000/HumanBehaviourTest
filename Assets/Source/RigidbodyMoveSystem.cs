using UnityEngine;
public class RigidBodyMoveSystem : IMoveSystem
{
    Rigidbody rigidbody;
    Transform transform;
    IController controller;
    public RigidBodyMoveSystem(IEvent fixedUpdate, GameObject gameObject, IController controller)
    {
        fixedUpdate.Subscribe(FixedUpdate);
        this.rigidbody = gameObject.AddComponent<Rigidbody>();
        this.controller = controller;

        rigidbody.freezeRotation = true;
    }
    public void FixedUpdate()
    {
        Vector2 input = controller.Input();
        Vector3 direction = new Vector3(input.x,0,input.y);
        rigidbody.velocity = direction;
    }
}