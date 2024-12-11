using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class CoinTrigger : MonoBehaviour
{
    public LocalSaveSystem LocalSaveSystem;
    public TMP_Text coinCountText;
    public int coinCount = 0;
    private void Start()
    {
        LocalSaveSystem = GameObject.FindGameObjectWithTag("Manager").GetComponent<LocalSaveSystem>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Respawn")
        {
            LocalSaveSystem.AddCoins(1);
        }
        Destroy(gameObject);
    }
    
}
