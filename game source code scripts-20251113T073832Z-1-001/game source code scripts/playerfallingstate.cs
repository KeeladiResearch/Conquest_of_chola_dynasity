using UnityEngine;

public class playerfallingstate : playerbasestate
{
    private readonly int Landhash = Animator.StringToHash("Land");
    private const float crossfadeduration = 0.1f;
    private Vector3 momentum;
    public playerfallingstate(playerstatemeachine playerstatemeachine) : base(playerstatemeachine)
    {
    }

    public override void Enter()
    {
        momentum = playerstatemeachine.characterController.velocity;
        momentum.y = 0f;
        playerstatemeachine.animator.CrossFadeInFixedTime(Landhash, crossfadeduration);
    }



    public override void stay(float deltatime)
    {
        move(momentum, deltatime);

        if (playerstatemeachine.characterController.isGrounded && playerstatemeachine.switck == true) {
            playerstatemeachine.switchstate(new playerlookstate(playerstatemeachine));
        }

        if (playerstatemeachine.characterController.isGrounded && playerstatemeachine.switck == false)
        {
            playerstatemeachine.switchstate(new playerbowlookstate(playerstatemeachine));
        }
    }

    public override void Exit()
    {

    }
}
