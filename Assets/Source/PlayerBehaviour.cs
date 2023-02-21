using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    Event updateEvent;
    Event fixedUpdateEvent;
    Player player;
    void Start()
    {
        updateEvent = new Event();
        fixedUpdateEvent = new Event();
        player = new Player(gameObject,updateEvent,fixedUpdateEvent);
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
