using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    // Ссылка на Canvas, который нужно активировать
    [SerializeField] private Canvas menuCanvas;

    // Ссылка на кнопку, которая должна исчезнуть
    [SerializeField] private Button initialButton;
    public GameObject player;
    private const string SavedSpeedKey = "SavedSpeed";
    private const string SavedScoreKey = "SavedScore";
    private const string BestScoreKey = "BestScore";
    private const string TotalCoinsKey = "TotalCoins";
    private const string ReviveKey = "Revive";

    private void Start()
    {
        
        // Убедимся, что Canvas изначально выключен
        if (menuCanvas != null)
            menuCanvas.gameObject.SetActive(false);

        // Добавляем слушатель нажатия на начальную кнопку
        if (initialButton != null)
            initialButton.onClick.AddListener(OnInitialButtonClick);
    }
    private void Update()
    {
        if (player == null)
        {
            initialButton.gameObject.SetActive(false);
        }
    }

    private void OnInitialButtonClick()
    {
        Time.timeScale = 0f;
        // Скрыть начальную кнопку
        if (initialButton != null)
            initialButton.gameObject.SetActive(false);

        // Включить Canvas
        if (menuCanvas != null)
            menuCanvas.gameObject.SetActive(true);
    }

    // Функция для кнопки "Начать заново"
    public void RestartLevel()
    {
        Time.timeScale = 1f;
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    // Функция для кнопки "Вернуться в главное меню"
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu"); // Укажите имя сцены меню
    }

    // Функция для кнопки "Продолжить"
    public void ContinueGame()
    {
        Time.timeScale = 1f;
        if (menuCanvas != null)
        {
            menuCanvas.gameObject.SetActive(false);
        }

        if (initialButton != null)
        {
            initialButton.gameObject.SetActive(true);
        }
    }
}