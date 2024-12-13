using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject menuCanvas; // ������ �� Canvas ����
    public Button playButton; // ������ �� ������ "������"
    public Button exitButton; // ������ �� ������ "�����"

    void Start()
    {
        Time.timeScale = 1f;
        // ���������� �������� �������
        playButton.onClick.AddListener(PlayGame);
        exitButton.onClick.AddListener(ExitGame);
    }

    void PlayGame()
    {
        // �������� �������� ������ (��������, "GameScene")
        SceneManager.LoadScene("GameScene");
    }

    void ExitGame()
    {
        // ����� �� ����������
        Application.Quit();
    }
}
