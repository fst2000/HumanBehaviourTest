using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour, IHuman
{
    Event updateEvent;
    Event fixedUpdateEvent;
    IAnimator animator;
    IMoveInfo moveInfo;
    IHumanSize humanSize;
    HumanIsOnGround isOnGround;
    IMoveSystem moveSystem;
    UnityStateHandler stateHandler;
    new UnityCollider collider;
    [SerializeField] JoystickController moveController;
    void Start()
    {
        updateEvent = new Event();
        fixedUpdateEvent = new Event();

        animator = new UnityAnimator(gameObject.GetComponent<Animator>());
        isOnGround = new HumanIsOnGround(gameObject.transform);
        IState currentState = new HumanWalkState(updateEvent, fixedUpdateEvent, animator, isOnGround);
        stateHandler = new UnityStateHandler(updateEvent, currentState);
        moveSystem = new RigidBodyMoveSystem(fixedUpdateEvent, gameObject, moveController, moveInfo);
        collider = new UnityCollider(fixedUpdateEvent,gameObject,humanSize);
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
