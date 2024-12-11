using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI; // Ссылка на меню паузы

    private bool isPaused = false; // Флаг, указывающий, активна ли пауза

    public void TogglePause()
    {
        if (isPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    private void Pause()
    {
        pauseMenuUI.SetActive(true); // Показываем меню паузы
        Time.timeScale = 0f; // Останавливаем игровое время
        isPaused = true; // Ставим флаг паузы
    }

    private void Resume()
    {
        pauseMenuUI.SetActive(false); // Скрываем меню паузы
        Time.timeScale = 1f; // Возвращаем нормальное время
        isPaused = false; // Снимаем флаг паузы
    }
}