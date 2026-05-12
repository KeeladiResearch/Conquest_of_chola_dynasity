using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemybossimpactstate : enemybossbasestate
{
    private readonly int ImpactHash = Animator.StringToHash("impact");

    private const float CrossFadeDuration = 0.1f;

    private float duration = 1f;

    public enemybossimpactstate(enemybossstatemeachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime(ImpactHash, CrossFadeDuration);
    }

    public override void stay(float deltaTime)
    {
        Move(deltaTime);

        duration -= deltaTime;

        if (duration <= 0f)
        {
            stateMachine.switchstate(new enemybossidlestatemeachine(stateMachine));
        }
    }

    public override void Exit() { }
}

