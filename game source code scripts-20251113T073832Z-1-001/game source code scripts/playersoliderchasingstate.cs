using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playersoliderchasingstate : playersoliderbasestate
{
    private readonly int LocomotionHash = Animator.StringToHash("locomotions");
    private readonly int SpeedHash = Animator.StringToHash("speed");

    private const float CrossFadeDuration = 0.1f;
    private const float AnimatorDampTime = 0.1f;


    public playersoliderchasingstate(playersoliderstatemeachine stateMachine) : base(stateMachine)
    {

    }

    public override void Enter()
    {

        stateMachine.Animator.CrossFadeInFixedTime(LocomotionHash, CrossFadeDuration);
        stateMachine.inputmanager.attacksol += ontarget;
    }

    public override void stay(float deltaTime)
    {

        if (!IsInChaseRange())
        {
            stateMachine.switchstate(new playersolideridlestate(stateMachine));
            return;
        }
        if (IsInAttackRange())
        {
            stateMachine.switchstate(new playersoliderattackingstate(stateMachine));
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
        stateMachine.inputmanager.attacksol -= ontarget;

    }

    private void MoveToPlayer(float deltaTime)
    {

        if (stateMachine.Agent.isOnNavMesh)
        {
            stateMachine.Agent.destination = stateMachine.solidertargeting.currentenmytarget.transform.position;

            Move(stateMachine.Agent.desiredVelocity.normalized * stateMachine.MovementSpeed, deltaTime);
        }

        stateMachine.Agent.velocity = stateMachine.Controller.velocity;
    }


    public void ontarget()
    {
        stateMachine.PlayerChasingRange = 0;
    }


}
