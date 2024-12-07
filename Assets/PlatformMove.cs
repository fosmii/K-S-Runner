using UnityEngine;
using TMPro;

public class PlatformMove : MonoBehaviour
{
    public float speed = 5f;
    public float disapperRadius = 25f;
    public float minRandomRange = -2f;
    public float maxRandomRange = 2f;

    public GameObject spike;
    public float spikeHeight = 1f;
    public GameObject coin;
    public float coinHeight = 1.5f;
    public GameObject platform;
    public Transform camera;
    public TMP_Text textScore;
    public int scoreCount = 0;
    public PlayerMove playerMove;
    private float delay = 0f;

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);


        if (transform.position.x < -disapperRadius)
        {
            Destroy(gameObject);
            scoreCount++;

            speed *= 1.02f;
            Vector2 newPlatformPosition = new Vector2(disapperRadius + Random.Range(minRandomRange, maxRandomRange), Random.Range(minRandomRange, maxRandomRange));
            GameObject newPlatform = Instantiate(platform, new Vector2(disapperRadius + Random.Range(minRandomRange, maxRandomRange), Random.Range(minRandomRange, maxRandomRange)), Quaternion.identity);
            newPlatform.GetComponent<PlatformMove>().enabled = true;
            newPlatform.GetComponent<BoxCollider2D>().enabled = true;

            if (Random.RandomRange(0f,1f) > 0.5f)
            {
                Vector2 coinPosition = new Vector2(newPlatformPosition.x, newPlatformPosition.y + coinHeight);
                GameObject newCoin = Instantiate(coin, coinPosition, Quaternion.identity);
                newCoin.transform.SetParent(newPlatform.transform, false);
            }

            else if (Random.RandomRange(0f, 1f) > 0.7f)
            {
                Vector2 spikePosition = new Vector2(newPlatformPosition.x, newPlatformPosition.y + spikeHeight);
                GameObject newSpike = Instantiate(spike, spikePosition, Quaternion.identity);
                newSpike.transform.SetParent(newPlatform.transform, false);
            }
        }
    }
    
    private void FixedUpdate()
    {
        delay += 0.1f;
        if (delay > 1f)
        {
            delay = 0f;
            textScore.text = $"{scoreCount}, {playerMove.jumpCount - 1}";
        }
            
    }

    void OnDrawGizmosSelected()
    {
        if (platform != null)
        {
            Gizmos.color = Color.black;
            Gizmos.DrawWireSphere(camera.position, disapperRadius);
        }
    }

}