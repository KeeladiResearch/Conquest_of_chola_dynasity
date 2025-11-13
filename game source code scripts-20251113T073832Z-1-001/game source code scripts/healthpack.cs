using System.ComponentModel;
using UnityEngine;

public class healthpack : MonoBehaviour
{
    [Header("Element")]
  [SerializeField]  GameObject health;
  [SerializeField] public GameObject Hero;
  [SerializeField] public health HeroHealth;

    [Header("settings")]
  [SerializeField] bool ison = false;
  [SerializeField] public float timerspeed;
  [SerializeField] public int[] HealthValues;

    private void Start()
    {
        Hero = GameObject.Find("hero");
        HeroHealth = Hero.GetComponent<health>();
        Destroy(gameObject,timerspeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            int randomvalues = UnityEngine.Random.Range(0, HealthValues.Length);
            HeroHealth.healths += HealthValues[randomvalues] ;
          
            Destroy(health.gameObject);
            ison = true;

            if (HeroHealth.healths > 100)
            {

                HeroHealth.healths = 100;
               

            }

        }
    }
    private void Update()
    {
        float currenthealth = HeroHealth.healths;
     
        Debug.Log(currenthealth);
       
        if (ison == true) {
            Debug.Log("h");
            
           
        }
        if (HeroHealth.healths >= 100)
        {

          
            gameObject.GetComponent<Collider>().enabled = false;

        }

        else if (HeroHealth.healths >= 0)
        {
            gameObject.GetComponent<Collider>().enabled = true;
        }
    }

}
