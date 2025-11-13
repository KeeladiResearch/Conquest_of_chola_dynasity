using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class textanimation : MonoBehaviour
{
    [SerializeField] textwrter textwrter;
    [SerializeField] TextMeshProUGUI year;
    [SerializeField] TextMeshProUGUI names;


    private void Start()
    {
        textwrter.Addwriter(year, " Chapter-1 ", 0.1f, true);
        
    }
    
}
