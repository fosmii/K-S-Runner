using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    // Ссылка на Canvas, который нужно активировать
    [SerializeField] public Canvas menuCanvas;

    // Ссылка на кнопку, которая должна исчезнуть
    [SerializeField] public Button initialButton;

    private void Start()
    {
        menuCanvas.gameObject.SetActive(false);
        initialButton.onClick.AddListener(OnInitialButtonClick);
    }

    private void OnInitialButtonClick()
    {
        // Скрыть начальную кнопку
        Time.timeScale = 0f;
        initialButton.gameObject.SetActive(false);

        // Включить Canvas
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
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu"); // Укажите имя сцены меню
    }

    // Функция для кнопки "Продолжить"
    public void ContinueGame()
    {
        Time.timeScale = 1f;
        menuCanvas.gameObject.SetActive(false);
        initialButton.gameObject.SetActive(true);
    }
}