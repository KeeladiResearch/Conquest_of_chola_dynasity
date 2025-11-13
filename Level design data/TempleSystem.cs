using UnityEngine;

public class TempleSystem : MonoBehaviour
{
    public int templeLevel;
    public int templePoints;

    public void AddTemplePoints(int points)
    {
        templePoints += points;
        CheckLevelUp();
    }

    void CheckLevelUp()
    {
        if (templePoints >= 100)
        {
            templePoints -= 100;
            templeLevel++;
            Debug.Log($"Temple Upgraded! New Level: {templeLevel}");
        }
    }
}
