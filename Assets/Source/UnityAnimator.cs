using UnityEngine;

public class UnityAnimator : IAnimator
{
    Animator animator;
    string floatParamName;
    float floatParam;
    public UnityAnimator(Animator animator, IEvent update)
    {
        this.animator = animator;
        update.Subscribe(Update);
    }
    void Update()
    {
        animator.SetFloat(floatParamName,floatParam);
    }
    public IAnimationInfo StartAnimation(string name)
    {
        animator.CrossFade(name,0.25f);
        return new UnityAnimationInfo(animator,name);
        
    }
    public void SetFloat(string name, float value)
    {
        floatParamName = name;
        floatParam = value;

    }
}