using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playerlookstate : playerbasestate
{
    private readonly int playerspeed = Animator.StringToHash("playerspeed");
    private readonly int free_look_Blend_Tree = Animator.StringToHash("free_look_Blend_Tree");
    private const float animationdmptime = 0.1f;
    private const float constfadeduration = 0.1f;
    public playerlookstate(playerstatemeachine playerstatemeachine) : base(playerstatemeachine)
    {

    }

    public override void Enter()
    {
        playerstatemeachine.inputmanager.dodgeevent += ondodge;

        playerstatemeachine.inputmanager.jumpevent += onjump;

        playerstatemeachine.inputmanager.switchwp += onswitch;
        playerstatemeachine.inputmanager.targetevent += ontarget;
       
        playerstatemeachine.animator.CrossFadeInFixedTime(free_look_Blend_Tree, constfadeduration);
    }

    public override void stay(float deltatime)
    {
        Vector3 movement = calculation();

        move(movement * playerstatemeachine.playerspeed, deltatime);

        if (playerstatemeachine.inputmanager.Isattacking)
        {
            playerstatemeachine.switchstate(new playerattackstatesforlooks(playerstatemeachine, 0));
            return;
        }
        if (playerstatemeachine.inputmanager.Isblocking)
        {
            playerstatemeachine.switchstate(new playerblockingfreelookstate(playerstatemeachine));
            return;
        }


        if (playerstatemeachine.inputmanager.movementvalue == Vector2.zero) {
            playerstatemeachine.animator.SetFloat(playerspeed, 0, animationdmptime, deltatime);
            playerstatemeachine.playeraudiosource.Stop();
            playerstatemeachine.sand = false;
            return; }


        Debug.Log(playerstatemeachine.inputmanager.movementvalue.x);
        Debug.Log(playerstatemeachine.inputmanager.movementvalue.y);

            float volume = 1f;
            playerstatemeachine.footstepstimer -= Time.deltaTime;

        
        if (playerstatemeachine.footstepstimer < 0f)
            {
                playerstatemeachine.footstepstimer = playerstatemeachine.foottimermax;

            if (playerspeed >=0)
            {
                playerstatemeachine.footsound(playerstatemeachine.transform.position, volume);
            }




        }



        playerstatemeachine.animator.SetFloat(playerspeed, 1, animationdmptime, deltatime);


      

          

              
             
            

        
        
            freerotation(movement, deltatime);







       




    }
    public override void Exit()
    {
        playerstatemeachine.inputmanager.dodgeevent -= ondodge;
        playerstatemeachine.inputmanager.switchwp -= onswitch;
        playerstatemeachine.inputmanager.jumpevent -= onjump;
        playerstatemeachine.inputmanager.targetevent-=ontarget;
      
    }
    private void freerotation(Vector3 movement, float deltatime)
    {
        playerstatemeachine.transform.rotation = Quaternion.Lerp(playerstatemeachine.
            transform.rotation, Quaternion.LookRotation(movement), deltatime * playerstatemeachine.rotationspeed);
    }

    Vector3 calculation()
    {
        Vector3 forward = playerstatemeachine.cameratransform.forward;
        Vector3 right = playerstatemeachine.cameratransform.right;

        forward.y = 0f;
        right.y = 0f;
     
     
        forward.Normalize();
        right.Normalize();

        return forward * playerstatemeachine.inputmanager.movementvalue.y
            + right * playerstatemeachine.inputmanager.movementvalue.x;



    }
    private void ondodge()
    {
        if (playerstatemeachine.inputmanager.movementvalue == Vector2.zero) { 
        return;
        }
        playerstatemeachine.switchstate(new playerdodgestate(playerstatemeachine,playerstatemeachine.inputmanager.movementvalue));
       
    }

    private void onswitch()
    {
        if (playerstatemeachine.inputmanager.movementvalue == Vector2.zero)
        {
            playerstatemeachine.switchstate(new playerbowlookstate(playerstatemeachine));
            playerstatemeachine.switck = false;

            playerstatemeachine.bow.SetActive(true);
            playerstatemeachine.backshield.SetActive(true);
            playerstatemeachine.backsword.SetActive(true);
            playerstatemeachine.backbow.SetActive(false);
            playerstatemeachine.sword.SetActive(false);
            playerstatemeachine.shield.SetActive(false);
        }
    }
    private void onjump()
    {
        playerstatemeachine.switchstate(new playerjumpingstate(playerstatemeachine));

    }

   

    private void ontarget()
    {
        playerstatemeachine.targeter.SelectTarget();
        playerstatemeachine.switchstate(new playertargetingstate(playerstatemeachine));
    }


   
}