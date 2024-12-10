using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePlatformScript : MonoBehaviour
{
    public float ScoreDistance;
    private float speed;
    private Vector2 StartPositionX;
    public PlatformMove PlatformMove;

    void Start()
    {
        StartPositionX = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        GameObject platform = GameObject.FindGameObjectWithTag("Platform");
        PlatformMove compPlatform = platform.GetComponent<PlatformMove>();
        speed = compPlatform.speed;
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        ScoreDistance = Vector2.Distance(StartPositionX, transform.position);

    }
}
