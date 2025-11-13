using UnityEngine;
using System;

public class playerhealth : MonoBehaviour
{
    [SerializeField] int maxhealth = 100;
    private int damage;
    public event Action ondie;
    public event Action ontakedamage;

    private bool ininvenurable;

    private int healths;

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
        if (healths == 0) { return; }

        if (ininvenurable) { return; }

        healths = Mathf.Max(healths - damage, 0);

        ontakedamage?.Invoke();
        if (healths == 0)
        {
            ondie?.Invoke();
        }

        Debug.Log(healths);
    }
}
