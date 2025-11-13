using UnityEngine;

public class PlayerRewardTracker : MonoBehaviour
{
    public int totalTemplePoints;
    public int totalValorEarned;
    public int totalSageEarned;

    public void AddRewards(int valor, int sage)
    {
        totalValorEarned += valor;
        totalSageEarned += sage;
        totalTemplePoints += (valor + sage) / 10;
        TempleSystem.Instance.AddTemplePoints(totalTemplePoints);
    }
}
