using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playersoliderdeadstate : playersoliderbasestate
{
    public playersoliderdeadstate(playersoliderstatemeachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        //stateMachine.Ragdoll.toggleragdoll(true);
        stateMachine.Weapon.gameObject.SetActive(false);
        GameObject.Destroy(stateMachine.Target);
        stateMachine.Animator.CrossFadeInFixedTime("death", 0.1f);
        if (stateMachine.ourhealth.healths == 0)
        {

            stateMachine.deathtext.text = stateMachine.solidermanger.solider_reduce().ToString();
           

        }
    }

    public override void stay(float deltaTime) { }

    public override void Exit() { }
}
