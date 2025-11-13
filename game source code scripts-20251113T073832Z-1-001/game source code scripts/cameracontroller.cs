using Cinemachine;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;


public class cameracontroller : MonoBehaviour
{
    [System.Serializable]
    public class camerasetting
    {
        [Header("CAMERA MOVE SETTINGS")]
        public float zoomspeeed = 5;
        public float movespeed = 10;
        public float rotationspeed = 10;

        public float originalfieldofview = 70;
        public float zoomfieldofview = 20;
        public float mousex_sesirivity = 5;
        public float mousey_sesirivity = 5;
        public float MaxClampAngle = 90;
        public float MinClampAngle = 30;
    }
    [SerializeField]
    public camerasetting setting;

    [System.Serializable]
    public class camerainputstatus
    {
        public inputmanager manager;
    }
    [SerializeField]
    public camerainputstatus inputsetting;

   [field: SerializeField] public float lookdistance {  get; private set ; }
    [field: SerializeField] public float lookspeed {  get; private set ; }
   
  [SerializeField]  Transform center;
    public Transform target { get; private set; }
   [field: SerializeField] public Transform player { get; private set; }

    float cameraXrotation = 0;
    float cameraYrotation = 0;

 [SerializeField] public float cameroffset;

    [field:SerializeField] public Camera maincamera {  get; private set; }

   public Transform cameracenterposition {  get; private set; }

    void Start()
    {
        center.transform.GetChild(0);
        cameracenterposition = maincamera.transform;
        findplayer();
    }

    // Update is called once per frame
    void Update()
    {
        if(!target) { return; } 
        correctccking();

        
    }

    private void LateUpdate()
    {
        if (target)
        {
            followplayer();
        }
        else
        {

            findplayer();
        }

    }

    public void followplayer()
    {

        Vector3 movevector = Vector3.Lerp(transform.position, target.transform.position, setting.movespeed * Time.deltaTime);

        transform.position = movevector;


    }

    public void findplayer()
    {
        target = GameObject.FindGameObjectWithTag("d").transform;

     

        
    }

    public void rotationcamera()
    {
        // 1. Read mouse input
        cameraXrotation += -inputsetting.manager.rotating().y * setting.mousey_sesirivity;
        cameraYrotation += inputsetting.manager.rotating().x * setting.mousex_sesirivity;

        // 2. Clamp vertical rotation to prevent flipping
        cameraXrotation = Mathf.Clamp(cameraXrotation, setting.MinClampAngle, setting.MaxClampAngle);
        cameraYrotation = Mathf.Repeat(cameraYrotation, 360);

        // 3. Create rotation and apply to the camera only
        Vector3 rotationAngles = new Vector3(cameraXrotation, cameraYrotation, 0f);
        Quaternion targetRotation = Quaternion.Euler(rotationAngles);

        // 4. Smoothly rotate the camera
        maincamera.transform.localRotation = Quaternion.Slerp(maincamera.transform.localRotation, targetRotation, setting.rotationspeed * Time.deltaTime);
    }



    public void zoomcamera()
    {
        maincamera.fieldOfView = Mathf.Lerp(maincamera.fieldOfView, setting.zoomfieldofview, setting.zoomspeeed * Time.deltaTime);
    }
    public void Notzoomcamera()
    {
        maincamera.fieldOfView = Mathf.Lerp(maincamera.fieldOfView, setting.originalfieldofview, setting.zoomspeeed * Time.deltaTime);
    }

    public void correctccking()
    {
        if (Application.isPlaying)
        {

            return;
        }
    }

  
}
    