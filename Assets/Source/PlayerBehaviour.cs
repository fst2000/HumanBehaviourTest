using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour, IHuman
{
    Event updateEvent;
    Event fixedUpdateEvent;
    IAnimator animator;
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
        moveSystem = new RigidBodyMoveSystem(fixedUpdateEvent, gameObject, moveController);
        stateHandler = new UnityStateHandler(updateEvent,fixedUpdateEvent, new HumanWalkState(animator, isOnGround, moveSystem));
        collider = new UnityCollider(fixedUpdateEvent,gameObject,stateHandler.HumanSize());
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
