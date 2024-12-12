using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject menuCanvas; // Ссылка на Canvas меню
    public Text gameTitle; // Ссылка на объект текста для названия игры
    public Button playButton; // Ссылка на кнопку "Играть"
    public Button exitButton; // Ссылка на кнопку "Выйти"

    public GameObject pauseCanvas; // Ссылка на Canvas паузы
    public Button pauseButton; // Ссылка на кнопку "Пауза"
    public Button resumeButton; // Ссылка на кнопку "Продолжить"

    public GameObject deathCanvas; // Ссылка на Canvas смерти
    public Button retryButton; // Кнопка "Начать заново"
    public Button mainMenuButton; // Кнопка "Вернуться в меню"
    public Button reviveButton; // Кнопка "Вернуться за 200 монет"

    private bool isPaused = false;
    private int playerCoins = 0; // Текущее количество монет у игрока
    private float playerSpeed = 0f; // Текущая скорость игрока

    void Start()
    {
        // Установка текста для заголовка
        gameTitle.text = "2D Runner Game";

        // Назначение действий кнопкам
        playButton.onClick.AddListener(PlayGame);
        exitButton.onClick.AddListener(ExitGame);
        pauseButton.onClick.AddListener(TogglePause);
        resumeButton.onClick.AddListener(TogglePause);
        retryButton.onClick.AddListener(RestartGame);
        mainMenuButton.onClick.AddListener(ReturnToMainMenu);
        reviveButton.onClick.AddListener(RevivePlayer);

        pauseCanvas.SetActive(false); // Пауза изначально выключена
        deathCanvas.SetActive(false); // Canvas смерти изначально выключен
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
        Debug.Log("Игра завершена"); // Для проверки в редакторе Unity
    }

    void TogglePause()
    {
        isPaused = !isPaused;
        pauseCanvas.SetActive(isPaused);

        if (isPaused)
        {
            Time.timeScale = 0f; // Остановка времени
        }
        else
        {
            Time.timeScale = 1f; // Возобновление времени
        }
    }

    public void ShowDeathScreen()
    {
        Time.timeScale = 0f; // Остановка времени при смерти
        deathCanvas.SetActive(true);
    }

    void RestartGame()
    {
        // Перезагрузка текущей сцены
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f; // Возобновление времени
    }

    void ReturnToMainMenu()
    {
        // Возврат в главное меню
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f; // Возобновление времени
    }

    void RevivePlayer()
    {
        if (playerCoins >= 200)
        {
            playerCoins -= 200; // Списываем монеты
            deathCanvas.SetActive(false);
            Time.timeScale = 1f; // Возобновление времени
            Debug.Log("Игрок возродился!");

            // Восстановление скорости игрока
            /*PlayerController player = FindObjectOfType<PlayerController>();
            if (player != null)
            {
                player.SetSpeed(playerSpeed);
            }*/

            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);
        }
        else
        {
            Debug.Log("Недостаточно монет для возрождения!");
        }
    }

    public void SetPlayerSpeed(float speed)
    {
        playerSpeed = speed; // Сохранение текущей скорости игрока
    }
}
