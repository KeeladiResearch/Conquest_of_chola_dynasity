using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playersolidercomandstate : playersoliderbasestate
{
    
    public playersolidercomandstate(playersoliderstatemeachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
      
           
       
    }

    public override void stay(float deltatime)
    {

        stateMachine.PlayerChasingRange = 0;
        stateMachine.switchstate(new playersolideridlestate(stateMachine));


    }

    public override void Exit()
    {
        
    }

   



}
