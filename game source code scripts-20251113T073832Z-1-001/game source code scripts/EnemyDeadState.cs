using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyDeadState : EnemyBaseState
{
    public EnemyDeadState(EnemyStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        stateMachine.Ragdoll.toggleragdoll(true);
        stateMachine.Weapon.gameObject.SetActive(false);
        stateMachine.Controller.enabled = false;

        if (stateMachine.ourhealth.healths == 0)
        {
            
           stateMachine.deathtext.text = stateMachine.enemymanager.enemyreduce().ToString();
            stateMachine.spawning();

        }

        GameObject.Destroy(stateMachine.Target);
    }

    public override void stay(float deltaTime) { }

    public override void Exit() { }
}
