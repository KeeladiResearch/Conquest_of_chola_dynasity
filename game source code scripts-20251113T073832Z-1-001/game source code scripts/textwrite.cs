using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class textwrite : MonoBehaviour
{
    [SerializeField] textwrter textwrter;
    [SerializeField] TextMeshProUGUI year;
    [SerializeField] TextMeshProUGUI names;


    private void Start()
    {
        textwrter.Addwriter(year, " Rise of Raja Raja Cholan ", 0.1f, true);

    }

}
