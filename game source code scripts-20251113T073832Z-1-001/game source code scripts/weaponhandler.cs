using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponhandler : MonoBehaviour
{
    [SerializeField] GameObject weaponlogic;
    [SerializeField] GameObject slash1;

    public void enableslash1()
    {
        slash1.SetActive(true);
    }

    public void disableslash1()
    {
        slash1.SetActive(false); 
    }

    public void enabelweapon()
    {
        weaponlogic.SetActive(true);
    }

    public void disableweapon()
    {
        weaponlogic.SetActive(false);
    }


   
}
