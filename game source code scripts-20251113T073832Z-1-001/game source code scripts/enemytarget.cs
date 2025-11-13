using System;
using UnityEngine;

public class enemytarget : MonoBehaviour
{
   public health health {  get; private set; }
    public event Action<enemytarget> ondestroy;


    private void OnDestroy()
    {
        ondestroy?.Invoke(this);
    }
}
