using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChasingState : EnemyBaseState
{
    private readonly int LocomotionHash = Animator.StringToHash("locomotions");
    private readonly int SpeedHash = Animator.StringToHash("speed");

    private const float CrossFadeDuration = 0.1f;
    private const float AnimatorDampTime = 0.1f;

    public EnemyChasingState(EnemyStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime(LocomotionHash, CrossFadeDuration);
       
    }

    public override void stay(float deltaTime)
    {
        

       
       
        if ( !IsInChaseRange())
        {
            stateMachine.switchstate(new EnemyIdleState(stateMachine));
            return;
        }
         if (!IsInChaseRange() && IssoliderInChaseRange())
          {
              stateMachine.switchstate(new Enemysoldierchasingstate(stateMachine));
          }

        else if (IsInAttackRange() )
         {
             stateMachine.switchstate(new EnemyAttackingState(stateMachine));
             return;
         }

       

       


        MoveToPlayer(deltaTime);

        FacePlayer();

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
            stateMachine.Agent.destination = stateMachine.Player.transform.position;

            Move(stateMachine.Agent.desiredVelocity.normalized * stateMachine.MovementSpeed, deltaTime);
        }

        stateMachine.Agent.velocity = stateMachine.Controller.velocity;
    }

  

    private bool IsInbossAttackRange()
    {
        if (stateMachine.Health.isdead) { return false; }

        float playerDistanceSqr = (stateMachine.Player.transform.position - stateMachine.transform.position).sqrMagnitude;

        return playerDistanceSqr <= stateMachine.AttackRange * stateMachine.AttackRange;
    }
}
