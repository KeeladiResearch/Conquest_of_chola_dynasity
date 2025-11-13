using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemychasesolider : EnemyBaseState
{
    private readonly int LocomotionHash = Animator.StringToHash("locomotions");
    private readonly int SpeedHash = Animator.StringToHash("speed");

    private const float CrossFadeDuration = 0.1f;
    private const float AnimatorDampTime = 0.1f;
    public enemychasesolider(EnemyStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime(LocomotionHash, CrossFadeDuration);
    }

    public override void stay(float deltaTime)
    {
        if (!IssoliderInChaseRange())
        {
            stateMachine.switchstate(new EnemyIdleState(stateMachine));
            return;
        }

        else if (IsInplayerAttackRange())
        {
            stateMachine.switchstate(new enemysolidersttackstate(stateMachine));
            return;
        }


        MoveToPlayer(deltaTime);

        FacesoliderPlayer();

        stateMachine.Animator.SetFloat(SpeedHash, 1f, AnimatorDampTime, deltaTime);
    }

    public override void Exit()
    {
        stateMachine.Agent.ResetPath();
        stateMachine.Agent.velocity = Vector3.zero;
    }

    private void MoveToPlayer(float deltaTime)
    {
        if (stateMachine.Agent.isOnNavMesh)
        {
           
            
                stateMachine.Agent.destination =stateMachine.enmyrargeter.CurrentTarget.transform.position;

                Move(stateMachine.Agent.desiredVelocity.normalized * stateMachine.MovementSpeed, deltaTime);
            

            stateMachine.Agent.velocity = stateMachine.Controller.velocity;
        }


    }
}
