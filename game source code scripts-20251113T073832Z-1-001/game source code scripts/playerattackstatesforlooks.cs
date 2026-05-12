using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class playerattackstatesforlooks : playerbasestate
{
    private Attack attack;
    private float previousframetime;
    private bool Alreadyappliedforce;
    public playerattackstatesforlooks(playerstatemeachine playerstatemeachine,int attackindex) : base(playerstatemeachine)
    {
        attack = playerstatemeachine.Attacks[attackindex];
    }

    public override void Enter()
    {
        playerstatemeachine.weapon.SetAttack(attack.damage,attack.knockback);

        playerstatemeachine.animator.CrossFadeInFixedTime(attack.Animatioanname,attack.transistionduration);
    }

    public override void stay(float deltatime)
    {

        move(deltatime);
        facetarget();
        float normalizetime = GetNormalized(playerstatemeachine.animator);
        previousframetime = normalizetime;

        if (normalizetime >=previousframetime && normalizetime < 1f)
        {
            if (normalizetime >= attack.forcetime) {

                tryapplyforce();
            }
            if (playerstatemeachine.inputmanager.Isattacking)
            {

                Trycomboattack(normalizetime);

            }
        }
        else
        {
            
             if(playerstatemeachine.targeter.CurrentTarget == null)
            {
                playerstatemeachine.switchstate(new playerlookstate(playerstatemeachine));
            }

            if (playerstatemeachine.targeter.CurrentTarget != null)
            {
                playerstatemeachine.switchstate(new playertargetingstate(playerstatemeachine));
            }

        }
        
    }

   
    public override void Exit()
    {
        
    }

    private void Trycomboattack(float normalizetime)
    {
        if (attack.combostateindex == -1) {
            return;
        }
        if (normalizetime < attack.comboattacktime) { 
          return ;
        }
        playerstatemeachine.switchstate(new playerattackstate(playerstatemeachine,attack.combostateindex));
    }


  

    private void tryapplyforce()
    {
        if (Alreadyappliedforce) { return; }
        playerstatemeachine.forcereciver.Addforce(playerstatemeachine.transform.forward*attack.force);

        Alreadyappliedforce = true;
    }


}
