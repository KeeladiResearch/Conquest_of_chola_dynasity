using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerimapactstate : playerbasestate
{
    private readonly int impact = Animator.StringToHash("impact");

    private const float fixedduration = 0.1f;
    private float duration =0.5f;
    public playerimapactstate(playerstatemeachine playerstatemeachine) : base(playerstatemeachine)
    {
    }

    public override void Enter()
    {
        playerstatemeachine.animator.CrossFadeInFixedTime(impact, fixedduration);
    }


    public override void stay(float deltatime)
    {
        move(deltatime);
        duration -= deltatime;

        if (duration <= 0f && playerstatemeachine.switck == true  && playerstatemeachine.targeter.CurrentTarget == null) {

            playerstatemeachine.switchstate(new playerlookstate(playerstatemeachine));
        }

        if(duration<=0f && playerstatemeachine.targeter.CurrentTarget != null)
        {
            playerstatemeachine.switchstate(new playertargetingstate(playerstatemeachine));
        }
        if (duration <= 0f && playerstatemeachine.switck == false )
        {

            playerstatemeachine.switchstate(new playerbowlookstate(playerstatemeachine));
        }
        Debug.Log(duration);
    }


    public override void Exit()
    {
      
    }

   
}
