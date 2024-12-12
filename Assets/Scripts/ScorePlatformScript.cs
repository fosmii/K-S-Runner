using System;
using TMPro;
using UnityEngine;

public class ScorePlatformScript : MonoBehaviour
{
    public LocalSaveSystem LocalSaveSystem;
    public float scoreDistance;
    public int intScoreDistance;
    public float score—oefficient = 0f;
    public float speedScale = 0.01f;
    public float fspeed;
    private double speedSqrt = 9;
    private double speed;

    private Vector2 StartPositionX;


    void Start()
    {
        StartPositionX = transform.position;
        LocalSaveSystem = GameObject.FindGameObjectWithTag("Manager").GetComponent<LocalSaveSystem>();
    }

    void Update()
    {
        speed = Math.Sqrt(speedSqrt);
        fspeed = Convert.ToSingle(speed) + score—oefficient;
        transform.Translate(Vector2.left * fspeed * Time.deltaTime);
        scoreDistance = Vector2.Distance(StartPositionX, transform.position);
        scoreDistance -= scoreDistance % 1;
        intScoreDistance = Convert.ToInt32(scoreDistance);
        Debug.Log(intScoreDistance);

        LocalSaveSystem.AddScore(intScoreDistance);
    }
    private void FixedUpdate()
    {
        speedSqrt += speedScale;
    }
}
