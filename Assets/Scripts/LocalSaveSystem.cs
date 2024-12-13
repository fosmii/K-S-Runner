using UnityEngine;
using TMPro;

public class LocalSaveSystem : MonoBehaviour
{
    public TMP_Text currentCoinText; // ������� ������ (�� ������)
    public TMP_Text totalCoinText;   // ����� ������ (�����������)
    public TMP_Text currentScoreText;
    public TMP_Text bestScoreText;

    public int currentScore;   // ������� ����
    public int currentCoins;   // ������� ������ (�� ������)
    public int totalCoins;     // ����� ������ (�����������)

    private DeathScreen deathScreen;
    private const string SavedSpeedKey = "SavedSpeed";
    private const string SavedScoreKey = "SavedScore";
    private const string BestScoreKey = "BestScore";
    private const string TotalCoinsKey = "TotalCoins";

    void Start()
    {
        // ��������� ����������� ������
        LoadData();
        deathScreen = FindObjectOfType<DeathScreen>();
        deathScreen.SetTotalCoins(totalCoins);

        // �������� ������� ������ ��� �������
        currentCoins = 0;
        currentCoinText.text = $"{currentCoins}";
        if (PlayerPrefs.HasKey(SavedScoreKey))
        {
            if (PlayerPrefs.GetInt(SavedScoreKey) != 0)
            {
                currentScore += PlayerPrefs.GetInt(SavedScoreKey);
            }
            else Debug.Log(3);
        }
        else Debug.Log("nea");
    }

    public void AddScore(int amount)
    {
        currentScore = amount; // ����������� ������� ����
        currentScoreText.text = $"{currentScore}";
        UpdateBestScore();
    }

    public void AddCoins(int amount)
    {
        currentCoins += amount; // ����������� ������ �� ������� ������
        currentCoinText.text = $"{currentCoins}";
    }

    public void SaveData()
    {
        // � ����� ���� ���������� ������� � ����� ������
        Debug.Log("save");
        totalCoins += currentCoins;

        // ��������� ����� ������
        PlayerPrefs.SetInt(TotalCoinsKey, totalCoins);

        // ��������� Best Score
        PlayerPrefs.SetInt(BestScoreKey, GetBestScore());
        PlayerPrefs.SetInt(SavedScoreKey, 0);
        PlayerPrefs.SetFloat(SavedSpeedKey, 0f);

        // ��������� ���������
        PlayerPrefs.Save();

        // �������� ������� ������
        currentCoinText.text = $"{currentCoins}";
    }

    private void LoadData()
    {
        // ��������� Best Score, ���� �� ����������, ����� 0
        if (PlayerPrefs.HasKey(BestScoreKey))
        {
            bestScoreText.text = $"{PlayerPrefs.GetInt(BestScoreKey)}";
        }
        else
        {
            bestScoreText.text = "0";
        }

        // ��������� ����� ������
        if (PlayerPrefs.HasKey(TotalCoinsKey))
        {
            totalCoins = PlayerPrefs.GetInt(TotalCoinsKey);
            totalCoinText.text = $"{totalCoins}";
        }
        else
        {
            totalCoins = 0;
            totalCoinText.text = "0";
        }
    }

    private void UpdateBestScore()
    {
        int bestScore = GetBestScore();
        if (currentScore > bestScore)
        {
            PlayerPrefs.SetInt(BestScoreKey, currentScore); // ��������� Best Score
            PlayerPrefs.Save();
            bestScoreText.text = $"{currentScore}";
        }
    }

    public int GetBestScore()
    {
        return PlayerPrefs.GetInt(BestScoreKey, 0); // ���������� ����������� Best Score ��� 0
    }

    public int GetTotalCoins()
    {
        return PlayerPrefs.GetInt(TotalCoinsKey, 0); // ���������� ����������� ������ ��� 0
    }

    void OnApplicationQuit()
    {
       
        SaveData(); // ��������� ������ ��� ������ �� ����
    }
}
/*
### ������ ��� ���������� ���������� Best Score � �����

��� ���������� ���������� Best Score � ���������� ��������� ����� ����� ������������ PlayerPrefs � ��� ���������� ���������� Unity ��� �������� ������. ��� ������� ������:

---

### ������ LocalSaveSystem.cs

using UnityEngine;

public class LocalSaveSystem : MonoBehaviour
{
    private int currentScore;  // ������� ����
    private int currentCoins;  // ������� ���������� �����

    private const string BestScoreKey = "BestScore"; // ���� ��� ���������� Best Score
    private const string TotalCoinsKey = "TotalCoins"; // ���� ��� ���������� �����

    void Start()
    {
        // ��������� ����������� ������
        LoadData();
    }

    public void AddScore(int amount)
    {
        currentScore += amount;
        UpdateBestScore();
    }

    public void AddCoins(int amount)
    {
        currentCoins += amount;
    }

    public void SaveData()
    {
        // ��������� Best Score (�� ��� ����������� �������������)
        PlayerPrefs.SetInt(BestScoreKey, GetBestScore());

        // ��������� ����� ���������� �����
        PlayerPrefs.SetInt(TotalCoinsKey, GetTotalCoins());

        // ��������� ���������
        PlayerPrefs.Save();
    }

    private void LoadData()
    {
        // ��������� Best Score, ���� �� ����������, ����� 0
        if (PlayerPrefs.HasKey(BestScoreKey))
        {
            Debug.Log("Best Score Loaded: " + PlayerPrefs.GetInt(BestScoreKey));
        }
        else
        {
            Debug.Log("No Best Score Found. Setting to 0.");
        }

        // ��������� ����� ���������� �����
        if (PlayerPrefs.HasKey(TotalCoinsKey))
        {
            Debug.Log("Total Coins Loaded: " + PlayerPrefs.GetInt(TotalCoinsKey));
        }
        else
        {
            Debug.Log("No Coins Found. Setting to 0.");
        }
    }

    private void UpdateBestScore()
    {
        int bestScore = GetBestScore();
        if (currentScore > bestScore)
        {
            PlayerPrefs.SetInt(BestScoreKey); // Use Default Cases! for Counter Token Reset

�������� �� ����������. ��� ���������� ������������ ���:

---

### ����������� LocalSaveSystem.cs

csharp
        int bestScore = GetBestScore();
        if (currentScore > bestScore)
        {
            PlayerPrefs.SetInt(BestScoreKey, currentScore); // ��������� Best Score
        }
    }

    public int GetBestScore()
    {
        return PlayerPrefs.GetInt(BestScoreKey, 0); // ���������� ����������� Best Score ��� 0
    }

    public int GetTotalCoins()
    {
        return PlayerPrefs.GetInt(TotalCoinsKey, 0); // ���������� ����������� ������ ��� 0
    }

    void OnApplicationQuit()
    {
        SaveData(); // ��������� ������ ��� ������ �� ����
    }
}

---

### ��� ������������ ������:
1. **�������� ������ �� ������ ������**:  
   �������� ������ ������ (��������, `GameManager`) � ���������� � ���� ������ `LocalSaveSystem`.

2. **�������� ���� � ������ � �������� ����**:  
   � ����� ������� ��������� ��������� ������ `AddScore` � `AddCoins`, ����� ����������� ������� ���� � ���������� �����.

   ������:
   
csharp
   FindObjectOfType<LocalSaveSystem>().AddScore(10); // ��������� 10 �����
   FindObjectOfType<LocalSaveSystem>().AddCoins(5); // ��������� 5 �����
  

3. **���������� ������**:  
   ������ ������������� ��������� ������ ��� ������ �� ���� (`OnApplicationQuit`). �� ����� ������ ������� ����� `SaveData()` ������� � ������ ���������, ��������, ��� ���������� ������:
   
csharp
   FindObjectOfType<LocalSaveSystem>().SaveData();
  

4. **��������� ����������� ������**:  
   �� ������ �������� Best Score � ����� ���������� ����� � �������:
   
csharp
   int bestScore = FindObjectOfType<LocalSaveSystem>().GetBestScore();
   int totalCoins = FindObjectOfType<LocalSaveSystem>().GetTotalCoins();
   `

---

> ����:
### ������ �������:
- ����� ������: ���� ��� ����� �������� ������ (��������, �� ����� ������������), �����������:
 
  PlayerPrefs.DeleteAll(); // ������� ��� ����������� ������
  
  ��� ������� ���������� ����:
 
  PlayerPrefs.DeleteKey("BestScore");
  
- ������������ � ��������� Unity:  
  ���������, ��� ������ ������������� �����������, ������������ ����� ��� ����.

������ �� ������ ����������� ��������� ���������� Best Score � �����! */
