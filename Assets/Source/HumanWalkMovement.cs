using UnityEngine;
using System;
public class HumanWalkMovement : IMovement
{
    float moveSpeed;
    float torqueSpeed;
    IController controller;
    public HumanWalkMovement(IController controller)
    {
        moveSpeed = 3f;
        torqueSpeed = 3f;
        this.controller = controller;
    }
    public Vector3 Velocity()=> new Vector3(0, 0, controller.Input().y * moveSpeed);
    public Quaternion Torque()=> Quaternion.Euler(0,controller.Input().x * torqueSpeed,0);
}