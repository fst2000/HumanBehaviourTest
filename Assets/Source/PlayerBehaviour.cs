using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    Event updateEvent;
    Event fixedUpdateEvent;
    IAnimator animator;
    HumanIsOnGround isOnGround;
    IMoveSystem moveSystem;
    IHumanState stateMachine;
    new UnityCollider collider;
    [SerializeField] JoystickController moveController;
    void Start()
    {
        updateEvent = new Event();
        fixedUpdateEvent = new Event();

        animator = new UnityAnimator(gameObject.GetComponent<Animator>(), updateEvent);
        isOnGround = new HumanIsOnGround(gameObject.transform);
        stateMachine = new HumanStateMachine(new HumanWalkState(animator, isOnGround, moveController, moveSystem));  
        moveSystem = new RigidBodyMoveSystem(fixedUpdateEvent, gameObject,stateMachine.Human().MoveInfo());
        collider = new UnityCollider(fixedUpdateEvent, gameObject,stateMachine.Human().HumanSize());
    }
    void Update()
    {
        updateEvent.Call();
        stateMachine.NextState();
    }
    void FixedUpdate()
    {
        fixedUpdateEvent.Call();
    }
}
