using UnityEngine;

public class HumanAnimationPlayer : IAnimationPlayer
{
    Animator animator;
    public HumanAnimationPlayer(Animator animator)
    {
        this.animator = animator;
    }
    
    public void StartAnimation(string name)
    {
        animator.Play(name);
    }
}