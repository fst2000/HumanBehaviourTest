using UnityEngine;

public class HumanAnimationPlayer : IAnimationPlayer
{
    Animator animator;
    public HumanAnimationPlayer(GameObject gameObject)
    {
        animator = gameObject.GetComponent<Animator>();
    }
    
    public void StartAnimation(string name)
    {
        animator.CrossFade(name, 0.1f);
    }
    public bool CheckAnimation(string name)
    {
        return animator.GetCurrentAnimatorStateInfo(0).IsName(name);
    }
}