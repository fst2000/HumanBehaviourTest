using UnityEngine;

public class HumanCapsuleCollider : IMovableCollider
{
    public float Height{get;set;}
    public float Width{get;set;}
    CapsuleCollider collider;
    public HumanCapsuleCollider(CapsuleCollider collider)
    {
        this.collider = collider;
        collider.center = new Vector3(0, this.Height * 0.5f, 0);
        collider.height = this.Height;
        collider.radius = this.Width * 0.5f;
    }
    
}