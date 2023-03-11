using UnityEngine;

public class HumanIsOnGround : IBoolProducer
{
    Transform transform;
    public HumanIsOnGround(Transform transform)
    {
        this.transform = transform;
    }
    public bool Get()
    {
        return Physics.CheckSphere(transform.position, 0.4f);
    }
}