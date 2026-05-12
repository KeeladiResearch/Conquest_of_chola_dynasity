
using UnityEngine;

public class playersoliderattackingstate : playersoliderbasestate
{
    private readonly int AttackHash = Animator.StringToHash("attack");

    private const float TransitionDuration = 0.1f;

    private float lastAttackTime = 0f;

    public playersoliderattackingstate(playersoliderstatemeachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        if (Time.time >= lastAttackTime + stateMachine.attackCooldown)
        {
            stateMachine.Weapon.SetAttack(stateMachine.AttackDamage, stateMachine.AttackKnockback);
            stateMachine.Animator.CrossFadeInFixedTime(AttackHash, TransitionDuration);
            lastAttackTime = Time.time;
        }
        stateMachine.inputmanager.attacksol += ontarget;

    }


    public void ontarget()
    {
        stateMachine.AttackRange = 0;
    }

    public override void stay(float deltaTime)
    {
        if (GetNormalized(stateMachine.Animator) >= 1)
        {
            stateMachine.switchstate(new playersoliderchasingstate(stateMachine));
        }

        FacePlayer();



    }

    public override void Exit()
    {

        stateMachine.inputmanager.attacksol -= ontarget;
    }


}
