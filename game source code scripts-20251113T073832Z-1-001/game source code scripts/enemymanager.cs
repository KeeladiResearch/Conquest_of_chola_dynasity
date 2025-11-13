using UnityEngine;
using UnityEngine.UI;

public class enemymanager : MonoBehaviour
{
    public float Totalenemy = 18;
    public float intialenemy;
    public Image enemybar;

    private void Start()
    {
        Totalenemy = intialenemy;
        enemybar.fillAmount = intialenemy / 10;
    }

    private void Update()
    {
        enemybar.fillAmount = Totalenemy / 100;
    }
    public float enemyreduce()
    {
       
        return Totalenemy -= 1;
    }

}
