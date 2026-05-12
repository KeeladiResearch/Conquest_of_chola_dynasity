using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class bow : MonoBehaviour
{
    [System.Serializable]
    public class bowsettings
    {
        [Header("Arrow setting")]

        public float arrowcount;
        public GameObject arrowprefab;
        public Transform arrowpos;
        public Transform arrowequiparent;


        [Header("equip and unequip setting")]

        public Transform equippos;
        public Transform unequipos;

        [Header("bow string setting")]

        public Transform bowstring;
        public Transform stringInitalpos;
        public Transform stringhandpullpos;
        public Transform stringinitalparent;

        [Header("spinesetting")]
        public Transform spine;
        public Vector3 spineoffset;

        [Header("head rotation setting")]
        public float lookatposition = 2.8f;
    }
    [SerializeField]
    public bowsettings bowsetting;

   private bool hitdetect;

    [Header("crosshair setting")]

    public GameObject crosshairprfab;
   [SerializeField]  GameObject currentcrosshairprefab;


    [SerializeField] public Transform reaycastorgin;
   

    Vector2 rotation;
    [SerializeField] float mousesensitivity = 4f;

    private float xRotation = 0f;
   [SerializeField] float addforce = 3f;
    RaycastHit hit;
    public LayerMask aimlayer;
    Ray ray;
    [SerializeField] private Camera m_Camera;
    [SerializeField] Transform playerBody;

    [SerializeField] GameObject currentarrow;

    [SerializeField] Transform arrowposss;
 
  [SerializeField] private Rigidbody atrrowpre;
    Rigidbody currentarrows;
    public bool testaim;

    private void Start()
    {
           crosshairprfab.SetActive(false);
    }
    void equipbow()
    {
        this.transform.position = bowsetting.equippos.position;
        this.transform.rotation = bowsetting.equippos.rotation;
        this.transform.parent = bowsetting.equippos.parent;
    }

    void uneqipbow()
    {
        this.transform.position = bowsetting.unequipos.position;
        this.transform.rotation = bowsetting.unequipos.rotation;
        this.transform.parent = bowsetting.unequipos.parent;
    }

    public void showcrosshair()
    {
        crosshairprfab.SetActive(true);

       
    }

    public void Removecrosshair()
    {
        crosshairprfab.SetActive(false);

    }

    private Vector3 RotateView()
    {

        rotation = inputmanager.instance.rotating();


        float mouseX = rotation.x * mousesensitivity * Time.deltaTime;
        float mouseY = rotation.y * mousesensitivity * Time.deltaTime;


        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);




        m_Camera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);


        float currentYRotation = playerBody.transform.eulerAngles.y;
        float currentXRotation = playerBody.transform.eulerAngles.x;


        float newYRotation = currentYRotation + mouseX;
        float newXRotation = currentXRotation - mouseY;


       

        newXRotation = Mathf.Clamp(newXRotation, 0, 20f);
        Vector3 forward = m_Camera.transform.forward;
        Vector3 right = m_Camera.transform.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

      

        playerBody.transform.rotation = Quaternion.Euler(newXRotation, newYRotation, 0);

      return   forward * inputmanager.instance.movementvalue.y
           + right * inputmanager.instance.movementvalue.x;
    }

    private void Update()
    {
       // RotateView();

       
        
       
    }
    public void pickarrow()
    {
        bowsetting.arrowpos.gameObject.SetActive(true); 
    }

    public void disablearrow()
    {
        bowsetting.arrowpos.gameObject.SetActive(false);
    }

    public void pullstring()
    {
        bowsetting.bowstring.transform.position = bowsetting.stringhandpullpos.position;
        bowsetting.bowstring.transform.parent = bowsetting.stringhandpullpos;
    }

    public void releasestring()
    {
        bowsetting.bowstring.transform.position = bowsetting.stringInitalpos.position;
        bowsetting.bowstring.transform.parent = bowsetting.stringInitalpos;
    }

  
    public void pickarrows()
    {
      currentarrow =   Instantiate(bowsetting.arrowprefab, bowsetting.arrowpos.position, bowsetting.arrowpos.rotation) as GameObject;
    }
   public void aim()
    {

       
            showcrosshair();
          
        if (!inputmanager.instance.IsAimng)
        {
            Removecrosshair();
        }
        
    }
   void roatatechspine()
    {
        bowsetting.spine.LookAt(ray.GetPoint(50));
        bowsetting.spine.LookAt(bowsetting.spineoffset);
    }

    public void fire()
    {
       
        

            currentarrows = Instantiate(atrrowpre, arrowposss.position, arrowposss.rotation) as Rigidbody;

        
            currentarrows.AddForce(m_Camera.transform.forward * addforce, ForceMode.Force);
           

        
       

    }

    public void conformfire()
    {
      
        fire();
    }
}
