using UnityEngine;

public class TempleSaveSystem : MonoBehaviour
{
    public void SaveTemple()
    {
        PlayerPrefs.SetInt("TempleLevel", TempleSystem.Instance.templeLevel);
        PlayerPrefs.SetInt("TemplePoints", TempleSystem.Instance.templePoints);
    }

    public void LoadTemple()
    {
        TempleSystem.Instance.templeLevel = PlayerPrefs.GetInt("TempleLevel", 1);
        TempleSystem.Instance.templePoints = PlayerPrefs.GetInt("TemplePoints", 0);
    }
}
