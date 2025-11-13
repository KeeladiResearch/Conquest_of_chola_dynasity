using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemysolidersttackstate : EnemyBaseState
{

    private readonly int AttackHash = Animator.StringToHash("attack");

    private const float TransitionDuration = 0.1f;
    public enemysolidersttackstate(EnemyStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.Weapon.SetAttack(stateMachine.AttackDamage, stateMachine.AttackKnockback);

        stateMachine.Animator.CrossFadeInFixedTime(AttackHash, TransitionDuration);
    }

    public override void stay(float deltaTime)
    {
        if (GetNormalized(stateMachine.Animator) >= 1)
        {
            stateMachine.switchstate(new Enemysoldierchasingstate(stateMachine));
        }

       FacesoliderPlayer();
    }

    public override void Exit() { }
}



