using UnityEngine;


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
    public GameObject[] platforms;
    public Transform camera;
    public PlayerMove playerMove;
    public ScoreText ScoreText;
    private float randomPlatform;


    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);


        if (transform.position.x < -disapperRadius)
        {
            Destroy(gameObject);
            ScoreText.ScoreUpdate(1);

            speed *= 1.01f;
            randomPlatform = Random.RandomRange(0f, 1f);

            if (randomPlatform < 0.3f)                     //30% Spawn Default Platform
            {
                PlatformInstantiate(platforms[0]);
            }
            else if (randomPlatform < 0.8f)                //50% Spawn Platform with coins
            {
                float coins = Random.Range(0f, 1f);
                if (coins <= 0.5f)
                {
                    PlatformInstantiate(platforms[1]);
                }
                else
                {
                    PlatformInstantiate(platforms[2]);
                }
            }
            else if (randomPlatform <= 1f)                 //20% Spawn Platform with spikes
            {
                float spikes = Random.Range(0f, 1f);
                if (spikes < 0.3f)
                {
                    PlatformInstantiate(platforms[3]);
                }
                else if (spikes < 0.6f)                
                {
                    PlatformInstantiate(platforms[4]);
                }
                else
                {
                    PlatformInstantiate(platforms[5]);
                }
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(camera.position, disapperRadius);
    }

    void PlatformInstantiate(GameObject platformPrefab)
    {
        Vector2 newPlatformPosition = new Vector2(disapperRadius + Random.Range(minRandomRange, maxRandomRange), Random.Range(minRandomRange, maxRandomRange));
        GameObject newPlatform = Instantiate(platformPrefab, new Vector2(disapperRadius + Random.Range(minRandomRange, maxRandomRange), Random.Range(minRandomRange, maxRandomRange)), Quaternion.identity);
        newPlatform.GetComponent<PlatformMove>().enabled = true;
        newPlatform.GetComponent<PlatformMove>().ScoreText = ScoreText;
        newPlatform.GetComponent<BoxCollider2D>().enabled = true;
    }

    public void Dash(float dashLength)
    {
        transform.Translate(Vector2.left * dashLength * speed * Time.deltaTime);
    }
}