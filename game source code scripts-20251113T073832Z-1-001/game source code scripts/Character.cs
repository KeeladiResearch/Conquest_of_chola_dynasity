using UnityEngine;
using UnityEngine.InputSystem;

public class Character : MonoBehaviour
{
    [Header("Controls")]
    public float playerSpeed = 5.0f;
    public float crouchSpeed = 2.0f;
    public float sprintSpeed = 7.0f;
    public float jumpHeight = 0.8f;
    public float gravityMultiplier = 2;
    public float rotationSpeed = 5f;
    public float crouchColliderHeight = 1.35f;

    [Header("Animation Smoothing")]
    [Range(0, 1)]
    public float speedDampTime = 0.1f;
    [Range(0, 1)]
    public float velocityDampTime = 0.9f;
    [Range(0, 1)]
    public float rotationDampTime = 0.2f;
    [Range(0, 1)]
    public float airControl = 0.5f;

    public StateMachine movementSM;
    public StandingState standing;
    public JumpingState jumping;
    public CrouchingState crouching;
    public LandingState landing;
    public SprintState sprinting;
    public SprintJumpState sprintjumping;

    
    public float gravityValue = -9.81f;
    
    public float normalColliderHeight;
    
    public CharacterController controller;
    
    public PlayerInput playerInput;
    
    public Transform cameraTransform;
    
    public Animator animator;
    
    public Vector3 playerVelocity;


    // Start is called before the first frame update
    private void Start()
    {

        Debug.Log("✅ Start() is running...");

        movementSM = new StateMachine();
        if (movementSM == null)
        {
            Debug.LogError("❌ movementSM FAILED to initialize!");
            return;
        }

        standing = new StandingState(this, movementSM);
        if (standing == null)
        {
            Debug.LogError("❌ StandingState FAILED to initialize!");
            return;
        }

        movementSM.Initialize(standing);
        Debug.Log("✅ movementSM initialized with state: " + (movementSM.currentState != null ? movementSM.currentState.GetType().Name : "NULL"));
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        playerInput = GetComponent<PlayerInput>();
        cameraTransform = Camera.main.transform;
        playerInput = new PlayerInput();

        if (standing == null) Debug.LogError("StandingState is NULL!");
        if (jumping == null) Debug.LogError("JumpingState is NULL!");
        if (crouching == null) Debug.LogError("CrouchingState is NULL!");
        if (sprinting == null) Debug.LogError("SprintingState is NULL!");
        if (landing == null) Debug.LogError("LandingState is NULL!");
        if (sprintjumping == null) Debug.LogError("SprintJumpState is NULL!");

        if (controller == null) Debug.LogError("CharacterController is NULL!");
    if (animator == null) Debug.LogError("Animator is NULL!");
    if (playerInput == null) Debug.LogError("PlayerInput is NULL!");
    if (cameraTransform == null) Debug.LogError("Camera Transform is NULL!");


        if (controller == null)
            Debug.LogError("❌ CharacterController is missing!");
        if (animator == null)
            Debug.LogError("❌ Animator is missing!");
        if (playerInput == null)
            Debug.LogError("❌ PlayerInput is missing!");
        if (cameraTransform == null)
            Debug.LogError("❌ Camera.main is NULL!");


        if (standing == null)
        {
            Debug.LogError("❌ StandingState is NULL!");
        }

        movementSM.Initialize(standing);

        if (movementSM.currentState == null)
        {
            Debug.LogError("❌ movementSM.currentState is NULL after Initialize()!");
        }

        movementSM = new StateMachine();
        standing = new StandingState(this, movementSM);
        jumping = new JumpingState(this, movementSM);
        crouching = new CrouchingState(this, movementSM);
        landing = new LandingState(this, movementSM);
        sprinting = new SprintState(this, movementSM);
        sprintjumping = new SprintJumpState(this, movementSM);

        movementSM.Initialize(standing);

        normalColliderHeight = controller.height;
        gravityValue *= gravityMultiplier;
    }

    private void Update()
    {
        if (movementSM == null || movementSM.currentState == null)
        {
            Debug.LogError("❌ movementSM or currentState is NULL in Update()!");
            return;
        }

        movementSM.currentState.HandleInput();  // Process player inputs safely
        movementSM.currentState.LogicUpdate();  // Run logic safely
    }


    private void FixedUpdate()
    {
        if (movementSM == null)
        {
            Debug.LogError("❌ movementSM is NULL in FixedUpdate()!");
            return;
        }
        if (movementSM.currentState == null)
        {
            Debug.LogError("❌ movementSM.currentState is NULL in FixedUpdate()!");
            return;
        }

        movementSM.currentState.PhysicsUpdate();
    }

}
