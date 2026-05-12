using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class playerbasestate : statemeachine
{


    protected playerstatemeachine playerstatemeachine;


    public playerbasestate(playerstatemeachine playerstatemeachine)
    {
        this.playerstatemeachine = playerstatemeachine;

    }

    protected void move(float deltatime)
    {
        move(Vector3.zero, deltatime);
    }

    protected void move(Vector3 move, float deltatime)
    {
        playerstatemeachine.characterController.Move((move + playerstatemeachine.forcereciver.movement) * deltatime);
    }
    public void facetarget()
    {
        if (playerstatemeachine.targeter.CurrentTarget == null) { return; }
        Vector3 lookpos = playerstatemeachine.targeter.CurrentTarget.transform.position - playerstatemeachine.transform.position;
        lookpos.y = 0f;

        playerstatemeachine.transform.rotation = Quaternion.LookRotation(lookpos);

    }

    protected void returnlocomotion()
    {
       
     if(playerstatemeachine.targeter == null)
        {
            playerstatemeachine.switchstate(new playerlookstate(playerstatemeachine));
        }
    }

 
}
