using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class health : MonoBehaviour
{
    [SerializeField] public int maxhealth = 100;
    public int damage;
    public event Action ondie;
    public event Action ontakedamage;

    private bool ininvenurable;

   public float healths;

    public bool isdead => healths == 0;

    public void isinvenurable(bool isinvenurable)
    {
        ininvenurable = isinvenurable;
    }
    void Start()
    {
        healths = maxhealth;    
    }

   
   public void dealdamage(int damage)
    {
        if(healths == 0) { return; }

        if(ininvenurable) {return; }

        healths = Mathf.Max(healths-damage, 0);

     


        ontakedamage?.Invoke();
        if(healths == 0)
        {
            ondie?.Invoke();
        }
        
        Debug.Log(healths);
    }

    private void Update()
    {
       
    }
}
