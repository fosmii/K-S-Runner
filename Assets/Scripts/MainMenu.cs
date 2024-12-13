using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject menuCanvas; // Ссылка на Canvas меню
    public Button playButton; // Ссылка на кнопку "Играть"
    public Button exitButton; // Ссылка на кнопку "Выйти"

    void Start()
    {
        Time.timeScale = 1f;
        // Назначение действий кнопкам
        playButton.onClick.AddListener(PlayGame);
        exitButton.onClick.AddListener(ExitGame);
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
