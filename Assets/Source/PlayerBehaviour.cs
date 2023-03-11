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
    [SerializeField] JoystickController moveController;
    void Start()
    {
        updateEvent = new Event();
        fixedUpdateEvent = new Event();

        animator = new UnityAnimator(gameObject.GetComponent<Animator>());
        isOnGround = new HumanIsOnGround(gameObject.transform);
        moveSystem = new RigidBodyMoveSystem(fixedUpdateEvent, gameObject, moveController);
        stateHandler = new UnityStateHandler(updateEvent,fixedUpdateEvent, new StateWalk(animator, isOnGround, moveSystem));
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
