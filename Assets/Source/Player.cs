using UnityEngine;

public class Player : IHuman
{
    GameObject gameObject;
    Transform transform;
    Rigidbody rigidbody;
    IState currentState;
    IAnimator animator;
    IMoveSystem moveSystem;
    IMovableCollider collider;
    IBoolProducer isOnGround;
    public Player(GameObject gameObject, Event updateEvent,Event fixedUpdateEvent)
    {
        this.gameObject = gameObject;
        this.transform = gameObject.transform;

        this.rigidbody = gameObject.AddComponent<Rigidbody>();
        rigidbody.freezeRotation = true;
        rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
        rigidbody.interpolation = RigidbodyInterpolation.Interpolate;

        collider = new HumanCapsuleCollider(gameObject.AddComponent<CapsuleCollider>());

        updateEvent.Subscribe(Update);
        fixedUpdateEvent.Subscribe(FixedUpdate);

        this.animator = new UnityAnimator(gameObject.GetComponent<Animator>());
        this.currentState = new WalkState(isOnGround, animator, moveSystem,collider);
        this.moveSystem = new RigidbodyMoveSystem(rigidbody);
        this.isOnGround = new HumanIsOnGround(transform,collider);
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