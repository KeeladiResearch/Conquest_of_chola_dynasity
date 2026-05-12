using System;
using UnityEngine;

public class solidertarget : MonoBehaviour
{
    public bool isdead = false;
   public health health {  get; private set; }
    public event Action<solidertarget> ondestroy;


    private void Awake()
    {
        health = GetComponent<health>();
    }
    private void OnDestroy()
    {
        isdead = true;
        ondestroy?.Invoke(this);
    }
}
