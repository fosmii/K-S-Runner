using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject menuCanvas; // Ссылка на Canvas меню
    public Button playButton; // Ссылка на кнопку "Играть"
    public Button exitButton; // Ссылка на кнопку "Выйти"
    public Button settingsButton;
    public float timeScale = 0.5f;

    public GameObject settingsCanvas;
    private const string SavedSpeedKey = "SavedSpeed";
    private const string SavedScoreKey = "SavedScore";
    private const string BestScoreKey = "BestScore";
    private const string TotalCoinsKey = "TotalCoins";
    private const string ReviveKey = "Revive";

    void Start()
    {
        PlayerPrefs.SetFloat(SavedSpeedKey, 0f);
        PlayerPrefs.SetInt(SavedScoreKey, 0);
        PlayerPrefs.SetInt(ReviveKey, 1);
        PlayerPrefs.Save();
        // Назначение действий кнопкам
        playButton.onClick.AddListener(PlayGame);
        exitButton.onClick.AddListener(ExitGame);
        settingsButton.onClick.AddListener(Settings);
    }
    private void Update()
    {
        timeScale = Math.Clamp(timeScale, 0f, 100f);
        Time.timeScale = timeScale;
    }
    void Settings()
    {
        menuCanvas.SetActive(false);
        settingsCanvas.SetActive(true);
    }
    void PlayGame()
    {
        // Загрузка игрового уровня (например, "GameScene")
        SceneManager.LoadScene("GameScene");
    }

    void ExitGame()
    {
        // Выход из приложения
        Application.Quit();
    }
}
