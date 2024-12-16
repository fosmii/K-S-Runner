using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    // ������ �� Canvas, ������� ����� ������������
    [SerializeField] private Canvas menuCanvas;

    // ������ �� ������, ������� ������ ���������
    [SerializeField] private Button initialButton;
    public GameObject player;
    private const string SavedSpeedKey = "SavedSpeed";
    private const string SavedScoreKey = "SavedScore";
    private const string BestScoreKey = "BestScore";
    private const string TotalCoinsKey = "TotalCoins";
    private const string ReviveKey = "Revive";

    private void Start()
    {
        
        // ��������, ��� Canvas ���������� ��������
        if (menuCanvas != null)
            menuCanvas.gameObject.SetActive(false);

        // ��������� ��������� ������� �� ��������� ������
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
        // ������ ��������� ������
        if (initialButton != null)
            initialButton.gameObject.SetActive(false);

        // �������� Canvas
        if (menuCanvas != null)
            menuCanvas.gameObject.SetActive(true);
    }

    // ������� ��� ������ "������ ������"
    public void RestartLevel()
    {
        Time.timeScale = 1f;
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    // ������� ��� ������ "��������� � ������� ����"
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu"); // ������� ��� ����� ����
    }

    // ������� ��� ������ "����������"
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