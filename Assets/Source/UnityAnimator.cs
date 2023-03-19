using UnityEngine;

public class UnityAnimator : IAnimator
{
    Animator animator;
    public UnityAnimator(Animator animator)
    {
        this.animator = animator;
    }
    public IAnimationInfo StartAnimation(string name)
    {
        animator.CrossFade(name,0.25f);
        return new UnityAnimationInfo(animator,name);
        
    }
}