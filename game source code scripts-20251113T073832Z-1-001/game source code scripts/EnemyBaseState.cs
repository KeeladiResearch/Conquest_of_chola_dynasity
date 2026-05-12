using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBaseState : statemeachine
{
    protected EnemyStateMachine stateMachine;

    public EnemyBaseState(EnemyStateMachine stateMachine)
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
        if (stateMachine.Player == null) { return; }

        Vector3 lookPos = stateMachine.Player.transform.position - stateMachine.transform.position;
        lookPos.y = 0f;

        stateMachine.transform.rotation = Quaternion.LookRotation(lookPos);
    }
    protected void FacesoliderPlayer()
    {


        if (stateMachine.enmyrargeter.CurrentTarget == null) return;

        Vector3 lookPos = stateMachine.enmyrargeter.CurrentTarget.transform.position - stateMachine.transform.position;
        lookPos.y = 0f;

        stateMachine.transform.rotation = Quaternion.LookRotation(lookPos);



    }

    protected bool IsInChaseRange()
    {
        if (stateMachine.Health.isdead) {
          
            return false; }



        float playerDistanceSqr = (stateMachine.Player.transform.position - stateMachine.transform.position).sqrMagnitude;

        return playerDistanceSqr <= stateMachine.PlayerChasingRange * stateMachine.PlayerChasingRange;
    }
    protected bool IssoliderInChaseRange()
    {


        if (stateMachine.enmyrargeter.CurrentTarget == null)
        {
            return false;
        }


        if (stateMachine.enmyrargeter.currenthealth == null)
        {
            return false;
        }

        if (stateMachine.enmyrargeter.currenthealth.isdead)
        {
            stateMachine.enmyrargeter.cancelcurrenthealth();
            return false;
        }

        float soliderdistanceDistanceSqr = (stateMachine.enmyrargeter.CurrentTarget.transform.position - stateMachine.transform.position).sqrMagnitude;
        return soliderdistanceDistanceSqr <= stateMachine.soliderChasingRange * stateMachine.soliderChasingRange;

    }
    protected bool IsInAttackRange()
    {
        if (stateMachine.Health.isdead) { return false; }

        float playerDistanceSqr = (stateMachine.Player.transform.position - stateMachine.transform.position).sqrMagnitude;

        return playerDistanceSqr <= stateMachine.AttackRange * stateMachine.AttackRange;
    }
    protected bool IsInplayerAttackRange()
    {
        if (stateMachine.enmyrargeter.currenthealth.isdead)
        {
            stateMachine.enmyrargeter.cancelcurrenthealth();
            return false;
        }

        float soliderDistanceSqr = (stateMachine.enmyrargeter.CurrentTarget.transform.position - stateMachine.transform.position).sqrMagnitude;

        return soliderDistanceSqr <= stateMachine.soliderAttackRange * stateMachine.soliderAttackRange;

    }
}
