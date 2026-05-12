using UnityEngine;

public class playerbowlookstate : playerbasestate
{

    private readonly int playerspeed = Animator.StringToHash("playerspeed");
    private readonly int free_look_Blend_Tree = Animator.StringToHash("bowblendtree");
    private const float animationdmptime = 0.1f;
    private const float constfadeduration = 0.1f;
    public playerbowlookstate(playerstatemeachine playerstatemeachine) : base(playerstatemeachine)
    {

    }

    public override void Enter()
    {
        playerstatemeachine.inputmanager.dodgeevent += ondodge;

        playerstatemeachine.inputmanager.jumpevent += onjump;

        playerstatemeachine.inputmanager.switchwp += onswitch;

       

        playerstatemeachine.animator.CrossFadeInFixedTime(free_look_Blend_Tree, constfadeduration);
    }

    public override void stay(float deltatime)
    {
        Vector3 movement = calculation();

        move(movement * playerstatemeachine.playerspeed, deltatime);

        if (playerstatemeachine.inputmanager.Isattacking)
        {
            
            return;
        }
        if (playerstatemeachine.inputmanager.IsAimng)
        {
            playerstatemeachine.switchstate(new playerbowaimstate(playerstatemeachine ,playerstatemeachine.inputmanager.movementvalue));
            playerstatemeachine.cameras.SetActive(true);
            playerstatemeachine.bowscript.aim();
            return;
        }


        if (playerstatemeachine.inputmanager.movementvalue == Vector2.zero)
        {
            playerstatemeachine.animator.SetFloat(playerspeed, 0, animationdmptime, deltatime);

            return;
        }

        playerstatemeachine.animator.SetFloat(playerspeed, 1, animationdmptime, deltatime);
        freerotation(movement, deltatime);


    }
    public override void Exit()
    {
        playerstatemeachine.inputmanager.dodgeevent -= ondodge;
        playerstatemeachine.inputmanager.switchwp -= onswitch;
        playerstatemeachine.inputmanager.jumpevent -= onjump;
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
        if (playerstatemeachine.inputmanager.movementvalue == Vector2.zero)
        {
            return;
        }
        playerstatemeachine.switchstate(new Playerbowdodgingstate(playerstatemeachine, playerstatemeachine.inputmanager.movementvalue));

    }

    private void onswitch()
    {
        if (playerstatemeachine.inputmanager.movementvalue == Vector2.zero)
        {
            playerstatemeachine.switchstate(new playerlookstate(playerstatemeachine));
            playerstatemeachine.switck = true;
           

            playerstatemeachine.bow.SetActive(false);
            playerstatemeachine.backshield.SetActive(false);
            playerstatemeachine.backsword.SetActive(false);
            playerstatemeachine.backbow.SetActive(true);
            playerstatemeachine.sword.SetActive(true);
            playerstatemeachine.shield.SetActive(true);
        }
       
    }
    private void onjump()
    {
        playerstatemeachine.switchstate(new playerjumpingstate(playerstatemeachine));

    }
}
