using UnityEngine;

public class PlayerEconomy : MonoBehaviour
{
    public int valorPoints;
    public int sagePoints;

    public void AddValor(int amount)
    {
        valorPoints += amount;
        Debug.Log($"Valor Added: {amount} | Total: {valorPoints}");
    }

    public void AddSage(int amount)
    {
        sagePoints += amount;
        Debug.Log($"Sage Added: {amount} | Total: {sagePoints}");
    }
}
