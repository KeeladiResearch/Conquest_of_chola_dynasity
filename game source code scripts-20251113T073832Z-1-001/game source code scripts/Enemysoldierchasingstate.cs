using UnityEngine;

public class Enemysoldierchasingstate : EnemyBaseState
{
    public Enemysoldierchasingstate(EnemyStateMachine stateMachine) : base(stateMachine)
    {
    }

    private readonly int LocomotionHash = Animator.StringToHash("locomotions");
    private readonly int SpeedHash = Animator.StringToHash("speed");

    private const float CrossFadeDuration = 0.1f;
    private const float AnimatorDampTime = 0.1f;


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

        if (IsInplayerAttackRange())
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


            stateMachine.Agent.destination = stateMachine.enmyrargeter.CurrentTarget.transform.position;

            Move(stateMachine.Agent.desiredVelocity.normalized * stateMachine.MovementSpeed, deltaTime);


            stateMachine.Agent.velocity = stateMachine.Controller.velocity;
        }


    }
}
