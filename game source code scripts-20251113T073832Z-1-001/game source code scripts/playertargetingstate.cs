using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class playertargetingstate : playerbasestate
{
    private readonly int targetingblendtree = Animator.StringToHash("targetingblendtree");

    private readonly int targettingforwordspeed = Animator.StringToHash("targettingforwordspeed");

    private readonly int targettingrightspeed = Animator.StringToHash("targettingrightspeed");
    private const float constfadeduration = 0.1f;

    private readonly int blockhas = Animator.StringToHash("block");
    private const float fadeduration = 0.1f;
    public playertargetingstate(playerstatemeachine playerstatemeachine) : base(playerstatemeachine)
    {
    }

    public override void Enter()
    {
        playerstatemeachine.inputmanager.targetevent += oncancel;
        playerstatemeachine.inputmanager.dodgeevent += ondodge;

        playerstatemeachine.animator.CrossFadeInFixedTime(targetingblendtree, constfadeduration);
    }

    public override void Exit()
    {
        playerstatemeachine.inputmanager.targetevent -= oncancel;
        playerstatemeachine.inputmanager.dodgeevent -= ondodge;
       

    }

    private void ondodge()
    {
        if (playerstatemeachine.inputmanager.movementvalue == Vector2.zero)
        {
            return;
        }
        playerstatemeachine.switchstate(new playerdodgestate(playerstatemeachine, playerstatemeachine.inputmanager.movementvalue));

    }

    public override void stay(float deltatime)
    {
        if (playerstatemeachine.inputmanager.Isattacking)
        {
            playerstatemeachine.switchstate(new playerattackstate(playerstatemeachine, 0));
            return;
        }
        if (playerstatemeachine.inputmanager.Isblocking)
        {
           playerstatemeachine.switchstate(new playerblockingstate(playerstatemeachine));
        }

      

        if (playerstatemeachine.targeter.CurrentTarget == null)
        {

            playerstatemeachine.switchstate(new playerlookstate(playerstatemeachine));
            return;
        }
        
        Vector3 movement = calculate(deltatime);
        move(movement * playerstatemeachine.targettingspeed, deltatime);
        updateanimator(deltatime);
        facetarget();
    }
    public void oncancel()
    {

        playerstatemeachine.targeter.Cancel();

        playerstatemeachine.switchstate(new playerlookstate(playerstatemeachine));

    }

    private Vector3 calculate(float deltatime)
    {
        Vector3 movement = new Vector3();

        movement += playerstatemeachine.transform.right * playerstatemeachine.inputmanager.movementvalue.x;
        movement += playerstatemeachine.transform.forward * playerstatemeachine.inputmanager.movementvalue.y;

        return movement;
    }

    void updateanimator(float deltatime)
    {
        if (playerstatemeachine.inputmanager.movementvalue.y == 0)
        {

            playerstatemeachine.animator.SetFloat(targettingforwordspeed, 0,0.1f,deltatime);
        }
        else
        {
            float value = playerstatemeachine.inputmanager.movementvalue.y > 0 ? 1f : -1f;
            playerstatemeachine.animator.SetFloat (targettingforwordspeed, value,0.1f, deltatime);
        }
        if (playerstatemeachine.inputmanager.movementvalue.x == 0)
        {

            playerstatemeachine.animator.SetFloat(targettingrightspeed, 0, 0.1f, deltatime);
        }
        else
        {
            float value = playerstatemeachine.inputmanager.movementvalue.x > 0 ? 1f : -1f;
            playerstatemeachine.animator.SetFloat(targettingrightspeed, value, 0.1f, deltatime);
        }
    }


}
