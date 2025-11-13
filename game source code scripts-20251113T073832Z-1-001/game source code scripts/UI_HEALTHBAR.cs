using UnityEngine;
using UnityEngine.UI;

public class UI_HEALTHBAR : MonoBehaviour
{
    [SerializeField] public Image healthbar;
    [SerializeField] health health;
    public float healths;

    public static UI_HEALTHBAR instance {  get; private set; }

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
         healths = health.maxhealth / 100;
        healthbar.fillAmount = healths;
        
    }

    private void Update()
    {
        healths = health.healths/100;
        healthbar.fillAmount = healths;

        if (healths <= 0.4) { 
        healthbar.color = Color.red;
        }
    }
}
