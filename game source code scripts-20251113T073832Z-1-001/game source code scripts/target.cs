using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target : MonoBehaviour
{
    public event Action<target> ondestroy;

    private void OnDestroy()
    {
      
        ondestroy?.Invoke(this);
    }
}
