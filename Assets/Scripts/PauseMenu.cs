using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI; // ������ �� ���� �����

    private bool isPaused = false; // ����, �����������, ������� �� �����

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
        Time.timeScale = 0f; // ������������� ������� �����
        isPaused = true; // ������ ���� �����
    }

    private void Resume()
    {
        Time.timeScale = 1f; // ���������� ���������� �����
        isPaused = false; // ������� ���� �����
    }
}