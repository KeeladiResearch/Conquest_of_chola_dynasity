using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class inputmanager : MonoBehaviour,Inputaction.IPlayerActions
{

    Inputaction inputActions;

   
   
   public bool Isattacking {  get; private set; }
   public bool Isblocking {  get; private set; }
   public bool IsAimng {  get; private set; }
   public bool Isattackings {  get; private set; }

    [field: SerializeField] public InputActionReference attack11 { get; set; }
   
    public Vector2 movementvalue {  get; private set; }
    public Vector2 rotationvalue {  get; private set; }
    public event Action jumpevent;
    public event Action dodgeevent;
    public event Action targetevent;
    public event Action cancelevent;
    public event Action targeton;
    public event Action attacksol;
    public event Action followntattack;
    public event Action followedattack;
    public event Action switchwp;
   
    public static inputmanager instance { get; private set; } 

   

    void Start()
    {
       inputActions = new Inputaction();
       inputActions.player.SetCallbacks(this);
        inputActions.player.Enable();
       

    }


    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
       
    }
    private void OnDestroy()
    {
        inputActions.player.Disable();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed) { return; }
        jumpevent?.Invoke();
    }

    public void OnDodge(InputAction.CallbackContext context)
    {
        if(context.performed) { return; }
        dodgeevent?.Invoke();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
       movementvalue  = context.ReadValue<Vector2>();
    }

    public void OnMouserotation(InputAction.CallbackContext context)
    {
     rotationvalue = context.ReadValue<Vector2>();
    }

    public void OnTarget(InputAction.CallbackContext context)
    {
      targetevent?.Invoke();
    }

    public void OnCancel(InputAction.CallbackContext context)
    {
        cancelevent?.Invoke();
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Isattacking = true;
        }
        else if (context.canceled) { 

            Isattacking= false;
        }
      
    }

    public void OnBlock(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Isblocking = true;
        }
        else if (context.canceled)
        { 
            Isblocking= false;
        }
    }

    public void OnFollow(InputAction.CallbackContext context)
    {
       targeton?.Invoke();
    }

    public void OnAttacksol(InputAction.CallbackContext context)
    {
       attacksol?.Invoke();
    }

    public void OnFollownotattack(InputAction.CallbackContext context)
    {
        followntattack?.Invoke();
    }

    public void OnFollowattack(InputAction.CallbackContext context)
    {
        followedattack?.Invoke();
    }

    public void OnSwitchwp(InputAction.CallbackContext context)
    {
        switchwp?.Invoke();
    }

    public void OnAim(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            IsAimng = true;
        }
        else if (context.canceled)
        {
            IsAimng = false;
        }
    }

    public Vector2 rotating()
    {
        return inputActions.player.mouserotation.ReadValue<Vector2>();
    }

    private void OnEnable()
    {
        attack11.action.Enable();
    }

    private void OnDisable()
    {
        attack11.action.Disable();
    }
}
