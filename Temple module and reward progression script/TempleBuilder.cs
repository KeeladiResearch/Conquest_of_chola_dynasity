using UnityEngine;

public class TempleBuilder : MonoBehaviour
{
    public GameObject[] templeStages; // prefabs per level
    private int currentStage = 0;

    public void UpgradeTemple(int newLevel)
    {
        if (newLevel - 1 >= templeStages.Length) return;
        templeStages[currentStage].SetActive(false);
        templeStages[newLevel - 1].SetActive(true);
        currentStage = newLevel - 1;
    }
}
