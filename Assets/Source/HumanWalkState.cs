using UnityEngine;

public class HumanWalkState : IState,  IHumanSize,  IMoveInfo
{
    IEvent update;
    IEvent fixedUpdate;
    IAnimator animator;
    IBoolProducer isOnGround;
    public HumanWalkState(IEvent update, IEvent fixedUpdate, IAnimator animator, IBoolProducer isOnGround)
    {
        update.Subscribe(OnUpdate);
        fixedUpdate.Subscribe(OnFixedUpdate);

        this.animator = animator;
        this.isOnGround = isOnGround;
        animator.StartAnimation("WalkBlend");
    }
    public float Height()=> 1.8f;
    public float Radius()=> 0.25f;
    public float MoveSpeed()=> 3f;
    public void OnUpdate()
    {
        Debug.Log("WalkUpdate");
    }
    public void OnFixedUpdate()
    {
        Debug.Log("WalkFixedUpdate"); 
    }
    public IState NextState()
    {
        if(isOnGround.Get())
        {
            return this;
        }
        else return new HumanWalkState(update, fixedUpdate, animator, isOnGround);
    }
}