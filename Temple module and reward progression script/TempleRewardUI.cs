using UnityEngine;
using UnityEngine.UI;

public class TempleRewardUI : MonoBehaviour
{
    public Slider progressBar;
    public Text levelText;

    void Start() => UpdateUI();

    public void UpdateUI()
    {
        progressBar.value = (float)TempleSystem.Instance.templePoints / (100 * TempleSystem.Instance.templeLevel);
        levelText.text = $"Temple Lv {TempleSystem.Instance.templeLevel}";
    }
}
