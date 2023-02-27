using UnityEngine;

public class HumanPhysicalStatus : IPhysicalStatus
{
    public HumanPhysicalStatus()
    {
        
    }
    bool IsOnGround()
    {
        return Physics.CheckSphere();
    }
}