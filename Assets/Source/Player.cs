using UnityEngine;

public class Player : IHuman
{
    GameObject gameObject;
    Transform transform;
    Rigidbody rigidbody;
    CapsuleCollider collider;
    IState currentState;
    public IAnimator Animator {get;}
    public Player(GameObject gameObject, Event updateEvent,Event fixedUpdateEvent)
    {
        this.gameObject = gameObject;
        this.transform = gameObject.transform;

        this.rigidbody = gameObject.AddComponent<Rigidbody>();
        rigidbody.freezeRotation = true;
        rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
        rigidbody.interpolation = RigidbodyInterpolation.Interpolate;

        collider = gameObject.AddComponent<CapsuleCollider>();
        collider.height = 1.8f;
        collider.radius = 0.4f;
        collider.center = new Vector3(0,0.9f,0);

        updateEvent.Subscribe(Update);
        fixedUpdateEvent.Subscribe(FixedUpdate);

        this.Animator = new UnityAnimator(gameObject.GetComponent<Animator>());
        currentState = new WalkState(this);
    }
    void Update()
    {
        currentState.OnUpdate();
        if(currentState != currentState.NextState())
        {
            currentState.OnExit();
            currentState = currentState.NextState();
            currentState.OnEnter();
        }
    }
    void FixedUpdate()
    {
        currentState.OnFixedUpdate();
    }
    public bool IsOnGround() => Physics.CheckSphere(transform.position, 0.3f);
}