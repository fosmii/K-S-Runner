using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class DeathScreen : MonoBehaviour
{
    [SerializeField] private int reviveCost = 200; // ��������� �����������


    [SerializeField] private GameObject DeathCanvas;
    [SerializeField] private Button restartButton; // ������ ��������
    [SerializeField] private Button reviveButton; // ������ �����������
    [SerializeField] private Button menuButton; // ������ ����

    // ��� ���������� ������� ��������
    private static float savedSpeed = 0f;
    private int savedScore = 0;


    [SerializeField] public GameObject player;
    [SerializeField] private ScorePlatformScript speedController; // ������ ���������� ���������
    public GameObject Manager;
    public TMP_Text ReviveText;
    public GameObject coin;
    public TMP_Text coinText;
    private int totalCoins;
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

        // ��������� ��������� �� ������

        restartButton.onClick.AddListener(RestartLevel);
        reviveButton.onClick.AddListener(Revive);
        menuButton.onClick.AddListener(ReturnToMainMenu);
        coinText.text = $"{reviveCost} .";


    }

    private void Update()
    {
        if (player == null)
        {
            DeathCanvas.SetActive(true);
            if (totalCoins < reviveCost || (PlayerPrefs.GetInt(ReviveKey) == 0))
            {
                reviveButton.image.color = new Color32(255, 255, 255, 125);
            }
            Time.timeScale = 0.1f;
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
        if (totalCoins >= reviveCost && (PlayerPrefs.GetInt(ReviveKey) == 1))
        {
            // ������� ������ �� �����������
            Debug.Log("revive 1");
            totalCoins -= reviveCost;

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
        else if (totalCoins >= reviveCost && PlayerPrefs.GetInt(ReviveKey) == 0)
        {
            CannotRevive("ONE REVIVE at ONcE");
        }
        else if (totalCoins < reviveCost)
        {
            CannotRevive("NOt enOGHT cOINS");
        }
    }
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void SetTotalCoins(int coins)
    {
        totalCoins = coins;
    }
    private void CannotRevive(string text)
    {
        Debug.Log("cannotrevive");
        Destroy(coin);
        coinText.text = "";
        ReviveText.color = Color.white;
        ReviveText.text = $"{text}";
    }
}
