using UnityEngine;
using UnityEngine.UI;

public class LoreManager : MonoBehaviour
{
    public Text titleText, descText;

    public void ShowLore(HistoricalEvent ev)
    {
        titleText.text = ev.title;
        descText.text = ev.description;
    }
}
