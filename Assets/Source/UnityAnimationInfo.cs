using UnityEngine;
public class UnityAnimationInfo : IAnimationInfo
{
    Animator animator;
    string name;
    float start;
    public UnityAnimationInfo(Animator animator, string name)
    {
        this.animator = animator;
        start = Time.time;
    }
    public bool isPlaying()
    {
        var stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        return stateInfo.length > (Time.time - start);
    }
}