using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemybossidlestatemeachine : enemybossbasestate
{

    private readonly int LocomotionHash = Animator.StringToHash("locomotions");
    private readonly int SpeedHash = Animator.StringToHash("speed");

    private const float CrossFadeDuration = 0.1f;
    private const float AnimatorDampTime = 0.1f;

    public enemybossidlestatemeachine(enemybossstatemeachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime(LocomotionHash, CrossFadeDuration);
    }

    public override void stay(float deltaTime)
    {
        Move(deltaTime);

        if (IsInChaseRange())
        {
            stateMachine.switchstate(new enmybosschasingstate(stateMachine));
            return;
        }

        FacePlayer();

        stateMachine.Animator.SetFloat(SpeedHash, 0f, AnimatorDampTime, deltaTime);
    }

    public override void Exit() { }
}

