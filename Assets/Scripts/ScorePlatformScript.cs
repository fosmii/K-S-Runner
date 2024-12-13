using System;
using TMPro;
using UnityEngine;

public class ScorePlatformScript : MonoBehaviour
{
    public LocalSaveSystem LocalSaveSystem;
    public float scoreDistance;
    public int intScoreDistance;
    public float fspeed;
    public float startSpeed = 3f;
    public float speedScale = 0.1f;
    public float maxSpeed = 20f;
    public GameObject player;

    private Vector2 StartPositionX;
    private const string SavedScoreKey = "SavedScore";
    private const string SavedSpeedKey = "SavedSpeed";


    void Start()
    {
        if (PlayerPrefs.GetFloat(SavedSpeedKey) != 0f)
        {
            startSpeed = PlayerPrefs.GetFloat(SavedSpeedKey);
        }
        else Debug.Log("blablalblabl");
        StartPositionX = transform.position;
        LocalSaveSystem = GameObject.FindGameObjectWithTag("Manager").GetComponent<LocalSaveSystem>();
        fspeed = startSpeed;
    }

    void Update()
    {
        Debug.Log(PlayerPrefs.GetFloat(SavedSpeedKey));
        fspeed += speedScale * Time.deltaTime;
        fspeed = Math.Clamp(fspeed, startSpeed, maxSpeed);
        Debug.Log(fspeed);

        if (player != null)
        {
            transform.Translate(Vector2.left * fspeed * Time.deltaTime);
        }
        
        scoreDistance = Vector2.Distance(StartPositionX, transform.position);
        scoreDistance -= scoreDistance % 1;
        intScoreDistance = Convert.ToInt32(scoreDistance);
        LocalSaveSystem.AddScore(intScoreDistance + PlayerPrefs.GetInt(SavedScoreKey));
    }
    public float GetInitialSpeed()
    {
        return startSpeed;
    }

    public void SetSpeed(float speed)
    {
        fspeed = Mathf.Clamp(speed, startSpeed, maxSpeed);
    }
    public float GetCurrentSpeed()
    {
        return fspeed;
    }

}
