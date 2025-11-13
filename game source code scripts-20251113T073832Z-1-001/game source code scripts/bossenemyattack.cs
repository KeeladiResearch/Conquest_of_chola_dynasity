using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class bossenemyattack : enemybossbasestate
{
    private float previousFrameTime;
    private bool alreadyAppliedForce;

    private bossattack attack;

   

  

    private const float TransitionDuration = 0.1f;
    public bossenemyattack(enemybossstatemeachine stateMachine , int attackIndex) : base(stateMachine) {
        attack = stateMachine.bossattack[attackIndex];

    }

    

    public override void Enter()
    {
        stateMachine.Weapon.SetAttack(attack.Damage,attack.Knockback);

        stateMachine.Animator.CrossFadeInFixedTime(attack.AnimationName, attack.TransitionDuration);
    }

    public override void stay(float deltaTime)
    {
        Move(deltaTime);

        float normalizetime = GetNormalized(stateMachine.Animator);
        previousFrameTime = normalizetime;

        if (normalizetime >= previousFrameTime && normalizetime < 1f)
        {
            if (normalizetime >= attack.ForceTime)
            {

                tryapplyforce();
            }
           
               TryComboAttack(normalizetime);

            

           
            FacePlayer();
        }
        if (GetNormalized(stateMachine.Animator) >= 1)
        {
            stateMachine.switchstate(new enmybosschasingstate(stateMachine));
        }

        if (stateMachine.Health.isdead)
        {
            stateMachine.switchstate(new enemybossidlestatemeachine(stateMachine));
        }

    }



    private void tryapplyforce()
    {
        if (alreadyAppliedForce) { return; }
        stateMachine.ForceReceiver.Addforce(stateMachine.transform.forward * attack.Force);

        alreadyAppliedForce = true;
    }





    public override void Exit()
    {

    }

    private void TryComboAttack(float normalizedTime)
    {
        if (attack.ComboStateIndex == -1) { return; }

        if (normalizedTime < attack.ComboAttackTime) { return; }

       

        stateMachine.switchstate
        (
            new bossenemyattack
            (
                stateMachine,
                attack.ComboStateIndex
            )
        );
    }
private bool isdead()
    {
        if (stateMachine.Health.isdead)
        {
            return false;
        }
        else { 
        return true;
        }
    }
    
}
