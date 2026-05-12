using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class statemeachine
{

    public abstract void Enter();

    public abstract void stay(float deltatime); 
    public abstract void Exit();


    protected float GetNormalized(Animator animator)
    {
        AnimatorStateInfo currentinfo = animator.GetCurrentAnimatorStateInfo(0);
        AnimatorStateInfo nextinfo = animator.GetNextAnimatorStateInfo(0);

        if (animator.IsInTransition(0) && nextinfo.IsTag("Attack"))
        {
            return nextinfo.normalizedTime;
        }

        else if (!animator.IsInTransition(0) && currentinfo.IsTag("Attack"))
        {
            return currentinfo.normalizedTime;
        }
        else
        {
            return 0f;
        }
    }

}
  

