using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Attack 
{
    

    [field: SerializeField] public string Animatioanname {  get; private set; }
    [field: SerializeField] public float transistionduration {  get; private set; }
    [field: SerializeField] public int combostateindex { get; private set; } = -1;
    [field: SerializeField] public float comboattacktime { get; private set; } 
    [field: SerializeField] public float forcetime { get; private set; } 
    [field: SerializeField] public float force{ get; private set; } 
    [field: SerializeField] public int damage{ get; private set; } 
    [field: SerializeField] public float knockback{ get; private set; } 
}
