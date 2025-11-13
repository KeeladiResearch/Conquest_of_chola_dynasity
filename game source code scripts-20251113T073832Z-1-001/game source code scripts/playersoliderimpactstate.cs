using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playersoliderimpactstate : playersoliderbasestate
{
    private readonly int ImpactHash = Animator.StringToHash("impact");

    private const float CrossFadeDuration = 0.1f;

    private float duration = 1f;

    public playersoliderimpactstate(playersoliderstatemeachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime(ImpactHash, CrossFadeDuration);
    }

    public override void stay(float deltaTime)
    {
        Move(deltaTime);

        duration -= deltaTime;

        if(duration <= 0f)
        {
            stateMachine.switchstate(new playersoliderchasingstate(stateMachine));
        }
        Debug.Log(duration);
    }

    public override void Exit() { 
    
    }
}
