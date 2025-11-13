using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadingcallback : MonoBehaviour
{
    private bool firstupdate = true;
    float timemax = 3f;
    float timeed;
    



    void Update()
    {
        timemax -= 0.01f;
        Debug.Log(timemax);
        if (firstupdate && timemax <= 0.0f)
        {
           
            loader.Loadercallback();
            firstupdate = false;
        }
    }
}
