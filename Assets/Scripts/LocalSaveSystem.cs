using UnityEngine;
using TMPro;

public class LocalSaveSystem : MonoBehaviour
{
    public TMP_Text currentCoinText; // Текущие монеты (за сессию)
    public TMP_Text totalCoinText;   // Общие монеты (сохраненные)
    public TMP_Text currentScoreText;
    public TMP_Text bestScoreText;

    private int currentScore;   // Текущий счет
    private int currentCoins;   // Текущие монеты (за сессию)
    private int totalCoins;     // Общие монеты (сохраненные)

    private const string BestScoreKey = "BestScore"; // Ключ для сохранения Best Score
    private const string TotalCoinsKey = "TotalCoins"; // Ключ для сохранения общих монет

    void Start()
    {
        // Загружаем сохраненные данные
        LoadData();

        // Обнуляем текущие монеты при запуске
        currentCoins = 0;
        currentCoinText.text = $"{currentCoins}";
    }

    public void AddScore(int amount)
    {
        currentScore = amount; // Увеличиваем текущий счет
        currentScoreText.text = $"{currentScore}";
        UpdateBestScore();
    }

    public void AddCoins(int amount)
    {
        currentCoins += amount; // Увеличиваем монеты за текущую сессию
        currentCoinText.text = $"{currentCoins}";
    }

    public void SaveData()
    {
        // В конце игры объединяем текущие и общие монеты
        totalCoins += currentCoins;

        // Сохраняем общие монеты
        PlayerPrefs.SetInt(TotalCoinsKey, totalCoins);

        // Сохраняем Best Score
        PlayerPrefs.SetInt(BestScoreKey, GetBestScore());

        // Применяем изменения
        PlayerPrefs.Save();

        // Обнуляем текущие монеты
        currentCoins = 0;
        currentCoinText.text = $"{currentCoins}";
    }

    private void LoadData()
    {
        // Загружаем Best Score, если он существует, иначе 0
        if (PlayerPrefs.HasKey(BestScoreKey))
        {
            bestScoreText.text = $"{PlayerPrefs.GetInt(BestScoreKey)}";
        }
        else
        {
            bestScoreText.text = "0";
        }

        // Загружаем общие монеты
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
            PlayerPrefs.SetInt(BestScoreKey, currentScore); // Обновляем Best Score
            PlayerPrefs.Save();
            bestScoreText.text = $"{currentScore}";
        }
    }

    public int GetBestScore()
    {
        return PlayerPrefs.GetInt(BestScoreKey, 0); // Возвращаем сохраненный Best Score или 0
    }

    public int GetTotalCoins()
    {
        return PlayerPrefs.GetInt(TotalCoinsKey, 0); // Возвращаем сохраненные монеты или 0
    }

    void OnApplicationQuit()
    {
        SaveData(); // Сохраняем данные при выходе из игры
    }
}
/*
### Скрипт для локального сохранения Best Score и монет

Для реализации сохранения Best Score и количества собранных монет можно использовать PlayerPrefs — это встроенный инструмент Unity для хранения данных. Вот готовый скрипт:

---

### Скрипт LocalSaveSystem.cs

using UnityEngine;

public class LocalSaveSystem : MonoBehaviour
{
    private int currentScore;  // Текущий счет
    private int currentCoins;  // Текущее количество монет

    private const string BestScoreKey = "BestScore"; // Ключ для сохранения Best Score
    private const string TotalCoinsKey = "TotalCoins"; // Ключ для сохранения монет

    void Start()
    {
        // Загружаем сохраненные данные
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
        // Сохраняем Best Score (он уже обновляется автоматически)
        PlayerPrefs.SetInt(BestScoreKey, GetBestScore());

        // Сохраняем общее количество монет
        PlayerPrefs.SetInt(TotalCoinsKey, GetTotalCoins());

        // Применяем изменения
        PlayerPrefs.Save();
    }

    private void LoadData()
    {
        // Загружаем Best Score, если он существует, иначе 0
        if (PlayerPrefs.HasKey(BestScoreKey))
        {
            Debug.Log("Best Score Loaded: " + PlayerPrefs.GetInt(BestScoreKey));
        }
        else
        {
            Debug.Log("No Best Score Found. Setting to 0.");
        }

        // Загружаем общее количество монет
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

Извините за прерывание. Вот правильный продолженный код:

---

### Продолжение LocalSaveSystem.cs

csharp
        int bestScore = GetBestScore();
        if (currentScore > bestScore)
        {
            PlayerPrefs.SetInt(BestScoreKey, currentScore); // Обновляем Best Score
        }
    }

    public int GetBestScore()
    {
        return PlayerPrefs.GetInt(BestScoreKey, 0); // Возвращаем сохраненный Best Score или 0
    }

    public int GetTotalCoins()
    {
        return PlayerPrefs.GetInt(TotalCoinsKey, 0); // Возвращаем сохраненные монеты или 0
    }

    void OnApplicationQuit()
    {
        SaveData(); // Сохраняем данные при выходе из игры
    }
}

---

### Как использовать скрипт:
1. **Добавьте скрипт на пустой объект**:  
   Создайте пустой объект (например, `GameManager`) и прикрепите к нему скрипт `LocalSaveSystem`.

2. **Добавьте счет и монеты в процессе игры**:  
   В ваших игровых механиках вызывайте методы `AddScore` и `AddCoins`, чтобы увеличивать текущий счет и количество монет.

   Пример:
   
csharp
   FindObjectOfType<LocalSaveSystem>().AddScore(10); // Добавляем 10 очков
   FindObjectOfType<LocalSaveSystem>().AddCoins(5); // Добавляем 5 монет
  

3. **Сохранение данных**:  
   Скрипт автоматически сохраняет данные при выходе из игры (`OnApplicationQuit`). Вы также можете вызвать метод `SaveData()` вручную в других ситуациях, например, при завершении уровня:
   
csharp
   FindObjectOfType<LocalSaveSystem>().SaveData();
  

4. **Получение сохраненных данных**:  
   Вы можете получить Best Score и общее количество монет с помощью:
   
csharp
   int bestScore = FindObjectOfType<LocalSaveSystem>().GetBestScore();
   int totalCoins = FindObjectOfType<LocalSaveSystem>().GetTotalCoins();
   `

---

> Артём:
### Важные моменты:
- Сброс данных: Если вам нужно сбросить данные (например, во время тестирования), используйте:
 
  PlayerPrefs.DeleteAll(); // Удаляет все сохраненные данные
  
  Или удалите конкретный ключ:
 
  PlayerPrefs.DeleteKey("BestScore");
  
- Тестирование в редакторе Unity:  
  Убедитесь, что данные действительно сохраняются, перезапустив сцену или игру.

Теперь вы можете реализовать локальное сохранение Best Score и монет! */
