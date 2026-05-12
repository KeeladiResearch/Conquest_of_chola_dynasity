using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackingState : EnemyBaseState
{
    private readonly int AttackHash = Animator.StringToHash("attack");

    private const float TransitionDuration = 0.1f;

        private float lastAttackTime = 0f;

    public EnemyAttackingState(EnemyStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        if (Time.time >= lastAttackTime + stateMachine.attackCooldown)
        {
            stateMachine.Weapon.SetAttack(stateMachine.AttackDamage, stateMachine.AttackKnockback);

            stateMachine.Animator.CrossFadeInFixedTime(AttackHash, TransitionDuration);
            lastAttackTime = Time.time;
        }
    }
    public override void stay(float deltaTime)
    {
        if (GetNormalized(stateMachine.Animator) >=1 )
        {
            stateMachine.switchstate(new EnemyChasingState(stateMachine));
        }
        if (stateMachine.Health.isdead)
        {
            stateMachine.switchstate(new EnemyImpactState(stateMachine));
        }
        FacePlayer();
    }

    public override void Exit() { }
}
