using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class playerstatemeachine : realstatemeachine
{


    [field: SerializeField] public inputmanager inputmanager { get; private set; }
    [field: SerializeField] public CharacterController characterController { get; private set; }
    [field: SerializeField] public targeter targeter { get; private set; }
    [field: SerializeField] public health health { get; private set; }
    [field: SerializeField] public forcereciver forcereciver { get; private set; }
    [field: SerializeField] public Animator animator { get; private set; }
    [field: SerializeField] public float playerspeed { get; private set; }
    [field: SerializeField] public float bowplayerspeed { get; private set; }
    [field: SerializeField] public float rotationspeed { get; private set; }
    [field: SerializeField] public float targettingspeed { get; private set; }
    [field: SerializeField] public Attack[] Attacks { get; private set; }

    [field: SerializeField] public float dodgeduration { get; private set; }
    [field: SerializeField] public float archerduration { get; private set; }
    [field: SerializeField] public float dodgelenth { get; private set; }
    [field: SerializeField] public Transform camerapos { get; private set; }
    [field: SerializeField] public Transform player { get; private set; }
    private const string PLAYER_SOUND_EFFECT = "SoundeffectVolume";




    [field: SerializeField] public float jumpforce { get; private set; }

    [field: SerializeField] public playerweapondamage weapon { get; private set; }
    [field: SerializeField] public ragadol ragadol { get; private set; }
    [field: SerializeField] public float aircontrol { get; private set; }
    [field: SerializeField] public bool switck { get; set; }

    [Header("gameobjects")]
    [field: SerializeField] public GameObject sword { get; set; }
    [field: SerializeField] public GameObject backsword { get; set; }
    [field: SerializeField] public GameObject shield { get; set; }
    [field: SerializeField] public GameObject backshield { get; set; }
    [field: SerializeField] public GameObject bow { get; set; }
    [field: SerializeField] public GameObject backbow { get; set; }
    [field: SerializeField] public GameObject cameras { get; set; }
    [field: SerializeField] public Transform righhand { get; set; }
    [field: SerializeField] public GameObject bowtranform { get; set; }
    [field: SerializeField] public bow bowscript { get; set; }
    [field: SerializeField] public Camera m_camera { get; set; }
    [field: SerializeField] public cameracontroller cameracontroller { get; set; }

    [field: SerializeField] public AudioSource playeraudiosource { get; set; }

    [field: SerializeField] public AudioClip[] sandrunaudio {  get; set; }
    [field: SerializeField] public bool sand {  get; set; }
    [field: SerializeField] public float footstepstimer{ get; set; }
    [field: SerializeField] public float foottimermax = 1f;

  


   







    public Transform cameratransform { get; private set; }
    public float verticalvelocity; // Stores jump & gravity velocity
    private float volume = 1f;
    public float gravity = -9.81f;  // Gravity value
    public float previousdodgetime { get; private set; } = Mathf.NegativeInfinity;



    private void Start()
    {
        cameratransform = Camera.main.transform;
        switchstate(new playerlookstate(this));
        bowscript.Removecrosshair();
       

    }


    private void Awake()
    {
        volume = PlayerPrefs.GetFloat(PLAYER_SOUND_EFFECT, 1f);
    }
    private void OnEnable()
    {
        health.ontakedamage += handletakedamage;
 

      
        health.ondie += handledie;
    }

    private void OnDisable()
    {
        health.ontakedamage -= handletakedamage;
        health.ondie -= handledie;
    }
    void handletakedamage()
    {
        switchstate(new playerimapactstate(this));
    }
    void handledie()
    {
        switchstate(new playerdeathstate(this));
    }

    public void pull()
    {
        bowscript.pullstring();
    }

    public void enablearrows()
    {
        bowscript.pickarrow();
    }

    public void disablearows()
    {
        bowscript.disablearrow();
    }

    public void release()
    {
        bowscript.releasestring();
    }

    private void playsound(AudioClip[] audioCliparray, Vector3 position, float volume = 1f)
    {
        playsound(audioCliparray[Random.Range(0, audioCliparray.Length)], position, volume);
    }
    private void playsound(AudioClip audioClip, Vector3 position, float volume = 1f)
    {
        AudioSource.PlayClipAtPoint(audioClip, position, volume);
    }

    public void footsound(Vector3 position, float volumemultyplayer)
    {
        playsound(sandrunaudio, position, volumemultyplayer * volume);
    }

    public void changevolume()
    {

        volume += .1f;
        if (volume > 1f)
        {
            volume = 0f;
        }

        PlayerPrefs.SetFloat(PLAYER_SOUND_EFFECT, volume);
        PlayerPrefs.Save();
    }
    public float getvolume()
    {
        return volume;
    }
}
