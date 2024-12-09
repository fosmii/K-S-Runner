using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CoinTrigger : MonoBehaviour
{
    public ScoreText ScoreTextScript;

    private void Start()
    {
        ScoreTextScript = GameObject.FindGameObjectWithTag("ScoreTag").GetComponent<ScoreText>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Respawn")
        {
            ScoreTextScript.ScoreUpdate(5);
        }
        Destroy(gameObject);
    }
}
