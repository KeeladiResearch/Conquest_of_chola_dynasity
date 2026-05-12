using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [Header("HUD Elements")]
    public Text valorText;
    public Text sageText;
    public Slider healthBar;

    [Header("Panels")]
    public GameObject pauseMenu;
    public GameObject gameOverScreen;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void UpdateValor(int amount)
    {
        valorText.text = $"Valor: {amount}";
    }

    public void UpdateSage(int amount)
    {
        sageText.text = $"Sage: {amount}";
    }

    public void UpdateHealth(float value)
    {
        healthBar.value = value;
    }

    public void ShowPauseMenu(bool state)
    {
        pauseMenu.SetActive(state);
        Time.timeScale = state ? 0 : 1;
    }

    public void ShowGameOver()
    {
        gameOverScreen.SetActive(true);
        Time.timeScale = 0;
    }
}
