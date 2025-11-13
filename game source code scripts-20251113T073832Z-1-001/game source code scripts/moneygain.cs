using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class moneygain : MonoBehaviour
{
    [SerializeField] private GameObject coinbag;
    [SerializeField] private float timerspeed;
    
    
   
   [SerializeField] public  float[] score;
    [SerializeField] private static float Myscore;
    public  float randomvaluel;
    private void Start()
    {
       Destroy(gameObject,timerspeed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
           randomvaluel = Random.Range(0, score.Length);
            Myscore += score[(int)randomvaluel];
           slashparticle_handler.instance.cointext.text = Myscore.ToString();  
            Destroy(coinbag.gameObject);
        }
    }
}
