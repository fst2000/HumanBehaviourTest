using UnityEngine;

public class Player : IHuman
{
    GameObject gameObject;
    public Player(GameObject gameObject, Event updateEvent,Event fixedUpdateEvent)
    {
        this.gameObject = gameObject;
        updateEvent.Subscribe(Update);
        fixedUpdateEvent.Subscribe(FixedUpdate);
    }
    void Update()
    {
        Debug.Log("Player Update");
    }
    void FixedUpdate()
    {
        Debug.Log("Player Fixed Update");
    }
}