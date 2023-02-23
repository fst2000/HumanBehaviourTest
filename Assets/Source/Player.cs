using UnityEngine;

public class Player : IHuman
{
    GameObject gameObject;
    IState currentState;
    public Player(GameObject gameObject, Event updateEvent,Event fixedUpdateEvent)
    {
        this.gameObject = gameObject;
        updateEvent.Subscribe(Update);
        fixedUpdateEvent.Subscribe(FixedUpdate);
        currentState = new WalkState();
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