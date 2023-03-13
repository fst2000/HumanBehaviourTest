using UnityEngine;
public class UnityCollider : ICollider
{
    IHumanSize humanSize;
    CapsuleCollider collider;
    public UnityCollider(IEvent fixedUpdateEvent, GameObject gameObject, IHumanSize humanSize)
    {
        this.humanSize = humanSize;
        collider = gameObject.AddComponent<CapsuleCollider>();
        fixedUpdateEvent.Subscribe(FixedUpdate);
    }
    void FixedUpdate()
    {
        collider.height = humanSize.Height();
        collider.radius = humanSize.Radius();
        collider.center = new Vector3(0,humanSize.Height() * 0.5f,0);
    }
}