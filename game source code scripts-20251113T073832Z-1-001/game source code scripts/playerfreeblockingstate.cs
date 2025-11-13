using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerblockingfreelookstate : playerbasestate
{
    private readonly int blockhas = Animator.StringToHash("block");
    private const float fadeduration = 0.1f;
    public playerblockingfreelookstate(playerstatemeachine playerstatemeachine) : base(playerstatemeachine)
    {
    }

    public override void Enter()
    {
        playerstatemeachine.health.isinvenurable(true);
        playerstatemeachine.animator.CrossFadeInFixedTime(blockhas, fadeduration);
    }

    public override void stay(float deltatime)
    {
        move(deltatime);

        if ( !playerstatemeachine.inputmanager.Isblocking)
        {
            if (playerstatemeachine.targeter.CurrentTarget == null)
            {
                playerstatemeachine.switchstate(new playerlookstate(playerstatemeachine));
            }

            if (playerstatemeachine.targeter.CurrentTarget != null)
            {
                playerstatemeachine.switchstate(new playertargetingstate(playerstatemeachine));
            }
            return;
        }
      

      

    }

    public override void Exit()
    {
      playerstatemeachine.health.isinvenurable(false);
    }

    
}
