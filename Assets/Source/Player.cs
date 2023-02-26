using UnityEngine;

public class Player : IHuman
{
    GameObject gameObject;
    IState currentState;
    IAnimationPlayer animationPlayer;
    public Player(GameObject gameObject, Event updateEvent,Event fixedUpdateEvent)
    {
        this.gameObject = gameObject;
        updateEvent.Subscribe(Update);
        fixedUpdateEvent.Subscribe(FixedUpdate);
        this.animationPlayer = new HumanAnimationPlayer(gameObject);
        currentState = new WalkState(animationPlayer);
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
}