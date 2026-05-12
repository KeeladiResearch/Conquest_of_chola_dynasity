using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerdeathstate : playerbasestate
{
    public playerdeathstate(playerstatemeachine playerstatemeachine) : base(playerstatemeachine)
    {
    }

    public override void Enter()
    {
        playerstatemeachine.ragadol.toggleragdoll(true); 
    playerstatemeachine.weapon.gameObject.SetActive(false);


            
    }

    public override void Exit()
    {
       
    }

    public override void stay(float deltatime)
    {
        
    }
}
