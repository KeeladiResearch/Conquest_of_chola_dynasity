using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playersolideridlestate : playersoliderbasestate
{
    private readonly int LocomotionHash = Animator.StringToHash("locomotions");
    private readonly int SpeedHash = Animator.StringToHash("speed");

    private const float CrossFadeDuration = 0.1f;
    private const float AnimatorDampTime = 0.1f;

    public playersolideridlestate(playersoliderstatemeachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime(LocomotionHash, CrossFadeDuration);
        stateMachine.inputmanager.targeton += Inputmanager_targeton;
        stateMachine.inputmanager.followntattack += Inputmanager_followntattack;
    }

    private void Inputmanager_followntattack()
    {
        if (isInfollowingrange())
        {
            stateMachine.switchstate(new playersoliderfollowstate(stateMachine));
            return;
        }
    }

    private void Inputmanager_targeton()
    {
        stateMachine.PlayerChasingRange = 20;
        stateMachine.AttackRange = 2;
    }

    public override void stay(float deltaTime)
    {
        Move(deltaTime);

        if(IsInChaseRange())
        {
            stateMachine.switchstate(new playersoliderchasingstate(stateMachine));
            return;
        }

        FacePlayer();

       

        stateMachine.Animator.SetFloat(SpeedHash, 0f, AnimatorDampTime, deltaTime);

       
    }

    public override void Exit() {
        stateMachine.inputmanager.targeton -= Inputmanager_targeton;
        stateMachine.inputmanager.followntattack -= Inputmanager_followntattack;
    }
}
