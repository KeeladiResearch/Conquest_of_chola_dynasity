using UnityEngine;

public class GameEconomy : MonoBehaviour
{
    public static GameEconomy Instance;
    public float valorPerKill = 5f;
    public float valorPerDamage = 0.1f;
    public int sageRewardPerQuiz = 10;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public int CalculateValor(float damage)
    {
        return Mathf.FloorToInt(damage * valorPerDamage);
    }

    public int CalculateSage(bool correctAnswer)
    {
        return correctAnswer ? sageRewardPerQuiz : 0;
    }
}
