using UnityEngine;

public class TempleSystem : MonoBehaviour
{
    public static TempleSystem Instance;
    public int templeLevel = 1;
    public int templePoints = 0;

    void Awake() { if (Instance == null) Instance = this; }

    public void AddTemplePoints(int pts)
    {
        templePoints += pts;
        if (templePoints >= 100 * templeLevel)
        {
            templePoints = 0;
            templeLevel++;
            OnTempleLevelUp();
        }
    }

    void OnTempleLevelUp()
    {
        Debug.Log($"Temple Upgraded to Level {templeLevel}");
        RewardManager.Instance.UnlockReward(templeLevel);
    }
}
