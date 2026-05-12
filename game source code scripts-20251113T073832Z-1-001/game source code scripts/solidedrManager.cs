using UnityEngine;
using UnityEngine.UI;

public class solidedrManager : MonoBehaviour
{
    public float TotalSolider = 18;
    public float InitialSolider;
    public Image soliderbar;

    private void Start()
    {
        TotalSolider = InitialSolider;
        soliderbar.fillAmount = InitialSolider / 10;
    }

    private void Update()
    {
        soliderbar.fillAmount = TotalSolider / 100;
    }
    public float solider_reduce()
    {

        return TotalSolider -= 1;
    }

}
