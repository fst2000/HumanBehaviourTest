public interface IAnimator
{
    IAnimationInfo StartAnimation(string name);
    void SetFloat(string name, float value);
}