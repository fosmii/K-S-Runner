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
    private GameObject prefab; 


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
                PlatformInstantiate(platforms[0], null);
            }
            else if (randomPlatform < 0.8f)                //50% Spawn Platform with coins
            {
                int coins = Random.Range(1, 3);
                Debug.Log(platforms[coins] + " " + coin);
                PlatformInstantiate(platforms[coins], "Coin");
            }
            else if (randomPlatform <= 1f)                 //20% Spawn Platform with spikes
            {
                int spikes = Random.Range(3,6);
                Debug.Log(platforms[spikes] + " "+ spikes);
                PlatformInstantiate(platforms[spikes], "Spike");
                
            }
            
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(camera.position, disapperRadius);
    }

    void PlatformInstantiate(GameObject platformPrefab, string tag)
    {
        Vector2 newPlatformPosition = new Vector2(disapperRadius + Random.Range(minRandomRange, maxRandomRange), Random.Range(minRandomRange, maxRandomRange));
        GameObject newPlatform = Instantiate(platformPrefab, new Vector2(disapperRadius + Random.Range(minRandomRange, maxRandomRange), Random.Range(minRandomRange, maxRandomRange)), Quaternion.identity);
        newPlatform.GetComponent<PlatformMove>().enabled = true;
        newPlatform.GetComponent<PlatformMove>().ScoreText = ScoreText;
        newPlatform.GetComponent<BoxCollider2D>().enabled = true;
        prefab = null;
        if (tag != null)
        {
            prefab = GameObject.FindGameObjectWithTag(tag);
            if (tag == "Coin" && prefab != null)
            {
                prefab.GetComponent<CircleCollider2D>().enabled = true;
                prefab.GetComponent<CoinTrigger>().enabled = true;
            }
            else if (tag == "Spike" && prefab != null)
            {
                prefab.GetComponent<PolygonCollider2D>().enabled = true;
            }
        }
        
    }
}