using UnityEngine;

class RigidbodyMoveSystem : IMoveSystem
{
    Rigidbody rigidbody;
    public RigidbodyMoveSystem(Rigidbody rigidbody)
    {
        this.rigidbody = rigidbody;
    }
    public void Move(Vector3 direction)
    {
        float velocityY = rigidbody.velocity.y;
        rigidbody.velocity = new Vector3(direction.x  * Time.deltaTime,direction.y  * Time.deltaTime + velocityY,direction.z  * Time.deltaTime);
    }
}