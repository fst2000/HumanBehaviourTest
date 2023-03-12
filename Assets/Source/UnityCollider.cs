using UnityEngine;
public class UnityCollider : ICollider
{
    CapsuleCollider collider;
    public UnityCollider(GameObject gameObject,IHumanSize humanSize)
    {
        collider = gameObject.AddComponent<CapsuleCollider>();
        collider.height = humanSize.Height();
        collider.radius = humanSize.Radius();
        collider.center = new Vector3(0,humanSize.Height() * 0.5f,0);
    }
}