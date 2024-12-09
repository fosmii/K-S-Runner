using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    public TMP_Text textScore;
    private int scoreCount = 0;

    public void ScoreUpdate(int score)
    {
        scoreCount += score;
        Debug.Log(scoreCount);
        textScore.text = $"{scoreCount}";
    }
}
