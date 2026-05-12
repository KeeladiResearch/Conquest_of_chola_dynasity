using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class playersoliderbasestate : statemeachine
{
    protected playersoliderstatemeachine stateMachine;

    public playersoliderbasestate(playersoliderstatemeachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    protected void Move(float deltaTime)
    {
        Move(Vector3.zero, deltaTime);
    }

    protected void Move(Vector3 motion, float deltaTime)
    {
        stateMachine.Controller.Move((motion + stateMachine.ForceReceiver.movement) * deltaTime);
    }

    protected void FacePlayer()
    {
        {

            if (stateMachine.solidertargeting.currentenmytarget == null) { return; }


            Vector3 lookPos = stateMachine.solidertargeting.currentenmytarget.transform.position - stateMachine.transform.position;

            lookPos.y = 0f;

            stateMachine.transform.rotation = Quaternion.LookRotation(lookPos);

        }
    }
    protected void heroFacePlayer()
    {
        {

            if (stateMachine.player == null) { return; }


            Vector3 lookPos = stateMachine.player.transform.position - stateMachine.transform.position;

            lookPos.y = 0f;

            stateMachine.transform.rotation = Quaternion.LookRotation(lookPos);
        }
    }


    protected bool IsInChaseRange()
    {


        if (stateMachine.solidertargeting.currentenmytarget == null)
        {
            return false;
        }


        if (stateMachine.solidertargeting.currenthealth == null)
        {
            return false;
        }

        if (stateMachine.solidertargeting.currenthealth.isdead)
        {
            stateMachine.solidertargeting.cancelcurrenthealth();
            return false;
        }



        float playerDistanceSqr = (stateMachine.solidertargeting.currentenmytarget.transform.position - stateMachine.transform.position).sqrMagnitude;

        return playerDistanceSqr <= stateMachine.PlayerChasingRange * stateMachine.PlayerChasingRange;


    }
    protected bool isInfollowingrange()
    {






        float playerDistanceSqr = (stateMachine.player.transform.position - stateMachine.transform.position).sqrMagnitude;

        return playerDistanceSqr <= stateMachine.PlayerfollowingRange * stateMachine.PlayerfollowingRange;

    }

    protected bool IsInAttackRange()
    {

        if (stateMachine.solidertargeting.currenthealth.isdead)
        {
            stateMachine.solidertargeting.cancelcurrenthealth();
            return false;
        }


        float playerDistanceSqr = (stateMachine.solidertargeting.currentenmytarget.transform.position - stateMachine.transform.position).sqrMagnitude;

        return playerDistanceSqr <= stateMachine.AttackRange * stateMachine.AttackRange;


    }
    protected bool Isinclosesetrange()
    {




        float playerDistanceSqr = (stateMachine.player.transform.position - stateMachine.transform.position).sqrMagnitude;

        return playerDistanceSqr <= stateMachine.closestrange * stateMachine.closestrange;

        // stateMachine.transform.position = Vector2.MoveTowards(stateMachine.transform.position, stateMachine.player.transform.position, stateMachine.MovementSpeed * Time.deltaTime);
        // stateMachine.transform.right = stateMachine.transform.position - stateMachine.player.transform.position;
    }
}
