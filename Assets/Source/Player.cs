using UnityEngine;

public class Player : IHuman
{
    GameObject gameObject;
    IState currentState;
    public IAnimationPlayer AnimationPlayer {get;}
    public Player(GameObject gameObject, Event updateEvent,Event fixedUpdateEvent)
    {
        this.gameObject = gameObject;
        updateEvent.Subscribe(Update);
        fixedUpdateEvent.Subscribe(FixedUpdate);
        this.AnimationPlayer = new HumanAnimationPlayer(gameObject.GetComponent<Animator>());
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
}