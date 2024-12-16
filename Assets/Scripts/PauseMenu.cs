using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public Canvas menuCanvas;
    public Button initialButton;

    private const string SavedSpeedKey = "SavedSpeed";
    private const string SavedScoreKey = "SavedScore";
    private const string BestScoreKey = "BestScore";
    private const string TotalCoinsKey = "TotalCoins";
    private const string ReviveKey = "Revive";

    private void Start()
    {
        menuCanvas.gameObject.SetActive(false);
        initialButton.onClick.AddListener(OnInitialButtonClick);
    }

    private void OnInitialButtonClick()
    {
        Time.timeScale = 0f;
        initialButton.gameObject.SetActive(false);
        menuCanvas.gameObject.SetActive(true);
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
        PlayerPrefs.SetFloat(SavedSpeedKey, 0f);
        PlayerPrefs.SetInt(SavedScoreKey, 0);
        PlayerPrefs.SetInt(ReviveKey, 1);
        PlayerPrefs.Save();
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void ContinueGame()
    {
        Time.timeScale = 1f;
        menuCanvas.gameObject.SetActive(false);
        initialButton.gameObject.SetActive(true);
    }
}