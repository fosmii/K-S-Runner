using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class DeathScreen : MonoBehaviour
{
    [Header("Настройки монет")]
    [SerializeField] private int totalCoins = 0; // Текущее количество монет у игрока
    [SerializeField] private int reviveCost = 200; // Стоимость возрождения

    [Header("Ссылки на UI элементы")]
    [SerializeField] private GameObject DeathCanvas;
    [SerializeField] private Button restartButton; // Кнопка рестарта
    [SerializeField] private Button reviveButton; // Кнопка возрождения
    [SerializeField] private Button menuButton; // Кнопка меню

    // Для сохранения текущей скорости
    private static float savedSpeed = 0f;
    private int savedScore = 0;

    [Header("Игровой объект (например, игрок)")]
    [SerializeField] public GameObject player;
    [SerializeField] private ScorePlatformScript speedController; // Скрипт управления скоростью
    public GameObject Manager;
    public TMP_Text ReviveText;
    public GameObject coin;
    public TMP_Text coinText;
    private const string SavedSpeedKey = "SavedSpeed";
    private const string SavedScoreKey = "SavedScore";
    private const string BestScoreKey = "BestScore";
    private const string TotalCoinsKey = "TotalCoins";
    private const string ReviveKey = "Revive";

    private LocalSaveSystem LocalSaveSystem;

    private void Start()
    {
        // Загружаем сохраненную скорость, если она есть
        if (speedController != null)
        {
            speedController.SetSpeed(savedSpeed > 0f ? savedSpeed : speedController.GetInitialSpeed());
        }
        LocalSaveSystem = Manager.GetComponent<LocalSaveSystem>();
        totalCoins = PlayerPrefs.GetInt(TotalCoinsKey);

        // Проверяем доступность кнопки возрождения
        UpdateReviveButton();

        // Назначаем слушатели на кнопки

        restartButton.onClick.AddListener(RestartLevel);
        reviveButton.onClick.AddListener(Revive);
        menuButton.onClick.AddListener(ReturnToMainMenu);
    }

    private void Update()
    {
        if (player == null)
        {
            DeathCanvas.SetActive(true);
            Time.timeScale = 0.1f;
        }
    }

    private void UpdateReviveButton()
    {
        if (reviveButton != null)
        {
            reviveButton.interactable = totalCoins >= reviveCost; // Кнопка активна, если достаточно монет
        }
    }

    public void RestartLevel()
    {
        // Сбрасываем сохраненную скорость при полном рестарте
        savedSpeed = 0f;
        PlayerPrefs.SetFloat(SavedSpeedKey, savedSpeed);
        PlayerPrefs.SetInt(SavedScoreKey, 0);
        PlayerPrefs.SetInt(ReviveKey, 1);
        PlayerPrefs.Save();
        // Перезапускаем текущую сцену
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Revive()
    {
        // Деактивируем кнопку возрождения, чтобы предотвратить повторный клик
        reviveButton.interactable = false;

        if (totalCoins >= reviveCost && (PlayerPrefs.GetInt(ReviveKey) == 1))
        {
            // Снимаем монеты за возрождение
            totalCoins -= reviveCost;
            Debug.Log("-babki");

            // Сохраняем текущую скорость
            if (speedController != null)
            {
                savedSpeed = speedController.GetCurrentSpeed();
            }
            savedScore = LocalSaveSystem.currentScore;

            

            // Восстанавливаем время перед перезагрузкой

            // Перезагружаем сцену сразу, без задержки
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

            Debug.Log("Игрок возрожден! Скорость сохранена: " + savedSpeed);
            // Сохраняем данные в PlayerPrefs
            
            PlayerPrefs.SetInt(ReviveKey, 0);
            PlayerPrefs.SetFloat(SavedSpeedKey, savedSpeed);
            PlayerPrefs.SetInt(SavedScoreKey, savedScore);
            PlayerPrefs.SetInt(TotalCoinsKey, totalCoins);
            PlayerPrefs.Save();
        }
        else
        {
            Destroy(coin);
            coinText.text = "";
            ReviveText.color = Color.red;
            ReviveText.text = "ONE REVIVE AT TIME";
        }
    }
    public void ReturnToMainMenu()
    {
        // Сбрасываем сохраненную скорость при выходе в меню
        savedSpeed = 0f;
        PlayerPrefs.SetFloat(SavedSpeedKey, savedSpeed);
        PlayerPrefs.SetInt(SavedScoreKey, 0);
        PlayerPrefs.SetInt(ReviveKey, 1);
        PlayerPrefs.Save();
        // Загружаем сцену главного меню
        SceneManager.LoadScene("MainMenu"); // Укажите точное имя вашей сцены меню
    }

    // Метод для установки количества монет (например, из другого скрипта)
    public void SetTotalCoins(int coins)
    {
        totalCoins = coins;
        UpdateReviveButton();
    }
}
