using UnityEngine;

public class playerjumpingstate : playerbasestate
{
    private readonly int jumphash = Animator.StringToHash("jump");
    private const float crossfadeduration = 0.1f;

    private Vector3 momentum;

    public playerjumpingstate(playerstatemeachine playerstatemeachine) : base(playerstatemeachine)
    {
    }

    public override void Enter()
    {
       
        Vector2 inputDirection = playerstatemeachine.inputmanager.movementvalue;
        Transform cameraTransform = playerstatemeachine.cameratransform;

      
        Vector3 camForward = cameraTransform.forward;
        Vector3 camRight = cameraTransform.right;
        camForward.y = 0f;
        camRight.y = 0f;
        camForward.Normalize();
        camRight.Normalize();

       
        momentum = (camForward * inputDirection.y + camRight * inputDirection.x) * playerstatemeachine.playerspeed;

     
        playerstatemeachine.verticalvelocity = playerstatemeachine.jumpforce;

        
        playerstatemeachine.animator.CrossFadeInFixedTime(jumphash, crossfadeduration);
    }

    public override void stay(float deltatime)
    {
        
        playerstatemeachine.verticalvelocity += playerstatemeachine.gravity * deltatime;

       
        Vector3 moveDirection = momentum;
        moveDirection.y = playerstatemeachine.verticalvelocity;
        playerstatemeachine.characterController.Move(moveDirection * deltatime);

      
        if (playerstatemeachine.verticalvelocity <= 0)
        {
            playerstatemeachine.switchstate(new playerfallingstate(playerstatemeachine));
        }
    }

    public override void Exit()
    {
       
    }
}
