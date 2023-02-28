using UnityEngine;

public class HumanIsOnGround : IBoolProducer
{
    Transform transform;
    IMovableCollider collider;
    public HumanIsOnGround(Transform transform, IMovableCollider collider)
    {
        this.transform = transform;
        this.collider = collider;
    }
    public bool Get()
    {
        return Physics.CheckSphere(transform.position + new Vector3(0, collider.Width * 0.3f, 0), collider.Width * 0.4f);
    }
}