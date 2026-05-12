using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  abstract   class realstatemeachine : MonoBehaviour
{
    private statemeachine currentstate;
    void Start()
    {
        
    }

  public  void switchstate(statemeachine state)
    {
        currentstate?.Exit(); 
        currentstate = state; 
        currentstate?.Enter(); 
    }
    void Update() 
    {
       currentstate?.stay(Time.deltaTime);

       
    }
}
