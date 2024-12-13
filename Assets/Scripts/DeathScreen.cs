using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class DeathScreen : MonoBehaviour
{
    [Header("��������� �����")]
    [SerializeField] private int totalCoins = 0; // ������� ���������� ����� � ������
    [SerializeField] private int reviveCost = 200; // ��������� �����������

    [Header("������ �� UI ��������")]
    [SerializeField] private GameObject DeathCanvas;
    [SerializeField] private Button restartButton; // ������ ��������
    [SerializeField] private Button reviveButton; // ������ �����������
    [SerializeField] private Button menuButton; // ������ ����

    // ��� ���������� ������� ��������
    private static float savedSpeed = 0f;
    private int savedScore = 0;

    [Header("������� ������ (��������, �����)")]
    [SerializeField] public GameObject player;
    [SerializeField] private ScorePlatformScript speedController; // ������ ���������� ���������
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
        // ��������� ����������� ��������, ���� ��� ����
        if (speedController != null)
        {
            speedController.SetSpeed(savedSpeed > 0f ? savedSpeed : speedController.GetInitialSpeed());
        }
        LocalSaveSystem = Manager.GetComponent<LocalSaveSystem>();
        totalCoins = PlayerPrefs.GetInt(TotalCoinsKey);

        // ��������� ����������� ������ �����������
        UpdateReviveButton();

        // ��������� ��������� �� ������

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
            reviveButton.interactable = totalCoins >= reviveCost; // ������ �������, ���� ���������� �����
        }
    }

    public void RestartLevel()
    {
        // ���������� ����������� �������� ��� ������ ��������
        savedSpeed = 0f;
        PlayerPrefs.SetFloat(SavedSpeedKey, savedSpeed);
        PlayerPrefs.SetInt(SavedScoreKey, 0);
        PlayerPrefs.SetInt(ReviveKey, 1);
        PlayerPrefs.Save();
        // ������������� ������� �����
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Revive()
    {
        // ������������ ������ �����������, ����� ������������� ��������� ����
        reviveButton.interactable = false;

        if (totalCoins >= reviveCost && (PlayerPrefs.GetInt(ReviveKey) == 1))
        {
            // ������� ������ �� �����������
            totalCoins -= reviveCost;
            Debug.Log("-babki");

            // ��������� ������� ��������
            if (speedController != null)
            {
                savedSpeed = speedController.GetCurrentSpeed();
            }
            savedScore = LocalSaveSystem.currentScore;

            

            // ��������������� ����� ����� �������������

            // ������������� ����� �����, ��� ��������
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

            Debug.Log("����� ���������! �������� ���������: " + savedSpeed);
            // ��������� ������ � PlayerPrefs
            
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
        // ���������� ����������� �������� ��� ������ � ����
        savedSpeed = 0f;
        PlayerPrefs.SetFloat(SavedSpeedKey, savedSpeed);
        PlayerPrefs.SetInt(SavedScoreKey, 0);
        PlayerPrefs.SetInt(ReviveKey, 1);
        PlayerPrefs.Save();
        // ��������� ����� �������� ����
        SceneManager.LoadScene("MainMenu"); // ������� ������ ��� ����� ����� ����
    }

    // ����� ��� ��������� ���������� ����� (��������, �� ������� �������)
    public void SetTotalCoins(int coins)
    {
        totalCoins = coins;
        UpdateReviveButton();
    }
}
