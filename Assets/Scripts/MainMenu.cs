using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject menuCanvas; // ������ �� Canvas ����
    public Text gameTitle; // ������ �� ������ ������ ��� �������� ����
    public Button playButton; // ������ �� ������ "������"
    public Button exitButton; // ������ �� ������ "�����"

    public GameObject pauseCanvas; // ������ �� Canvas �����
    public Button pauseButton; // ������ �� ������ "�����"
    public Button resumeButton; // ������ �� ������ "����������"

    public GameObject deathCanvas; // ������ �� Canvas ������
    public Button retryButton; // ������ "������ ������"
    public Button mainMenuButton; // ������ "��������� � ����"
    public Button reviveButton; // ������ "��������� �� 200 �����"

    private bool isPaused = false;
    private int playerCoins = 0; // ������� ���������� ����� � ������
    private float playerSpeed = 0f; // ������� �������� ������

    void Start()
    {
        // ��������� ������ ��� ���������
        gameTitle.text = "2D Runner Game";

        // ���������� �������� �������
        playButton.onClick.AddListener(PlayGame);
        exitButton.onClick.AddListener(ExitGame);
        pauseButton.onClick.AddListener(TogglePause);
        resumeButton.onClick.AddListener(TogglePause);
        retryButton.onClick.AddListener(RestartGame);
        mainMenuButton.onClick.AddListener(ReturnToMainMenu);
        reviveButton.onClick.AddListener(RevivePlayer);

        pauseCanvas.SetActive(false); // ����� ���������� ���������
        deathCanvas.SetActive(false); // Canvas ������ ���������� ��������
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
        Debug.Log("���� ���������"); // ��� �������� � ��������� Unity
    }

    void TogglePause()
    {
        isPaused = !isPaused;
        pauseCanvas.SetActive(isPaused);

        if (isPaused)
        {
            Time.timeScale = 0f; // ��������� �������
        }
        else
        {
            Time.timeScale = 1f; // ������������� �������
        }
    }

    public void ShowDeathScreen()
    {
        Time.timeScale = 0f; // ��������� ������� ��� ������
        deathCanvas.SetActive(true);
    }

    void RestartGame()
    {
        // ������������ ������� �����
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f; // ������������� �������
    }

    void ReturnToMainMenu()
    {
        // ������� � ������� ����
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f; // ������������� �������
    }

    void RevivePlayer()
    {
        if (playerCoins >= 200)
        {
            playerCoins -= 200; // ��������� ������
            deathCanvas.SetActive(false);
            Time.timeScale = 1f; // ������������� �������
            Debug.Log("����� ����������!");

            // �������������� �������� ������
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
            Debug.Log("������������ ����� ��� �����������!");
        }
    }

    public void SetPlayerSpeed(float speed)
    {
        playerSpeed = speed; // ���������� ������� �������� ������
    }
}
