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
    IState state;
    new UnityCollider collider;
    [SerializeField] JoystickController moveController;
    void Start()
    {
        updateEvent = new Event();
        fixedUpdateEvent = new Event();

        animator = new UnityAnimator(gameObject.GetComponent<Animator>());
        isOnGround = new HumanIsOnGround(gameObject.transform);
        state = new HumanStateMachine(new HumanWalkState(animator, isOnGround));  
        moveSystem = new RigidBodyMoveSystem(fixedUpdateEvent, gameObject, moveController, state.Human().MoveInfo());
        collider = new UnityCollider(fixedUpdateEvent,gameObject,state.Human().HumanSize());
    }
    void Update()
    {
        updateEvent.Call();
    }
    void FixedUpdate()
    {
        fixedUpdateEvent.Call();
    }
}
