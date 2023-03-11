using System.Collections.Generic;

public class Event : IEvent
{
    List<EventDelegate> subscribers = new List<EventDelegate>();
    public void Subscribe(EventDelegate subscriber) => subscribers.Add(subscriber);
    public void Call()
    {
        foreach(var subscriber in subscribers)
        {
            subscriber();
        }
    }
}