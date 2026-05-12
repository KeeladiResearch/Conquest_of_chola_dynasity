using UnityEngine;

public class playerdodgestate : playerbasestate
{
    private readonly int dodgeblendtree = Animator.StringToHash("dodgeblendtree");
    private readonly int dodgeright = Animator.StringToHash("dodgeright");
    private readonly int dodgeforward = Animator.StringToHash("dodgeforward");

    private Vector3 dodgingdirectioninput;
    private float remainingdodgetime;
    private const float crossfadeduration = 0.1f;

    public playerdodgestate(playerstatemeachine playerstatemeachine, Vector3 dodgingdirectioninput) : base(playerstatemeachine)
    {
        this.dodgingdirectioninput = dodgingdirectioninput;
    }

    public override void Enter()
    {
        remainingdodgetime = playerstatemeachine.dodgeduration;

      
        playerstatemeachine.animator.SetFloat(dodgeforward, dodgingdirectioninput.y);
        playerstatemeachine.animator.SetFloat(dodgeright, dodgingdirectioninput.x);

     
        playerstatemeachine.animator.CrossFadeInFixedTime(dodgeblendtree, crossfadeduration);

      
        playerstatemeachine.health.isinvenurable(true);
    }

    public override void stay(float deltatime)
    {
        // Get camera-relative movement direction
        Vector3 cameraForward = playerstatemeachine.cameratransform.forward;
        Vector3 cameraRight = playerstatemeachine.cameratransform.right;

        cameraForward.y = 0f; // Ignore vertical movement
        cameraRight.y = 0f;

        cameraForward.Normalize();
        cameraRight.Normalize();

        // Calculate dodge movement based on camera direction
        Vector3 movement =
            (cameraRight * dodgingdirectioninput.x + cameraForward * dodgingdirectioninput.y)
            * (playerstatemeachine.dodgelenth / playerstatemeachine.dodgeduration);

        // Apply movement
        move(movement, deltatime);
    

        // Decrease remaining dodge time
        remainingdodgetime -= deltatime;

        // Exit dodge state when time is up
        if (remainingdodgetime <= 0f)
        {
            playerstatemeachine.switchstate(new playerlookstate(playerstatemeachine));
        }
    }

    public override void Exit()
    {
        // Restore player vulnerability
        playerstatemeachine.health.isinvenurable(false);
    }
}
