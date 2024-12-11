using UnityEngine;


public class PlatformMove : MonoBehaviour 
{
    public float platformSpeed = 5f;
    public float disapperRadius = 25f;
    public float minRandomRange = -2f;
    public float maxRandomRange = 2f;


    public GameObject[] platforms;
    public Transform camera;
    public PlayerMove playerMove;
    public GameObject ScorePlatform;

    public ScorePlatformScript ScorePlatformScript;
    private float randomPlatform;
    private GameObject prefabCoin;
    private GameObject prefabSpike;

    private void Start()
    {
        ComponentActivater();
    }

    void ComponentActivater()
    {
        gameObject.GetComponent<PlatformMove>().enabled = true;
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        ScorePlatform = GameObject.FindGameObjectWithTag("ScorePlatform");
        ScorePlatformScript = ScorePlatform.GetComponent<ScorePlatformScript>();

        prefabCoin = GameObject.FindGameObjectWithTag("Coin");
        if (prefabCoin != null)
        {
            prefabCoin.SetActive(true);
            prefabCoin.GetComponent<CircleCollider2D>().enabled = true;
            prefabCoin.GetComponent<CoinTrigger>().enabled = true;
            prefabCoin.GetComponent<Animator>().enabled = true;
        }
        prefabSpike = GameObject.FindGameObjectWithTag("Spike");
        if (prefabSpike != null)
        {
            prefabSpike.SetActive(true);
            prefabSpike.GetComponent<PolygonCollider2D>().enabled = true;
        }
        
    }

    void Update()
    {
        platformSpeed = ScorePlatformScript.fspeed;
        transform.Translate(Vector2.left * platformSpeed * Time.deltaTime);


        if (transform.position.x < -disapperRadius)
        {
            randomPlatform = Random.RandomRange(0f, 1f);

            if (randomPlatform < 0.3f)                     //30% Spawn Default Platform
            {
                PlatformInstantiate(platforms[0], null);
            }
            else if (randomPlatform < 0.8f)                //50% Spawn Platform with coins
            {
                int coins = Random.Range(1, 3);
                PlatformInstantiate(platforms[coins], "Coin");
            }
            else if (randomPlatform <= 1f)                 //20% Spawn Platform with spikes
            {
                int spikes = Random.Range(3,5);
                PlatformInstantiate(platforms[spikes], "Spike");
            }
            Destroy(gameObject);
        }
    }

    void PlatformInstantiate(GameObject platformPrefab, string tag)
    {
        Vector2 newPlatformPosition = new Vector2(disapperRadius + Random.Range(minRandomRange, maxRandomRange), Random.Range(minRandomRange, maxRandomRange));
        GameObject newPlatform = Instantiate(platformPrefab, new Vector2(disapperRadius + Random.Range(minRandomRange, maxRandomRange), Random.Range(minRandomRange, maxRandomRange)), Quaternion.identity);

    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(camera.position, disapperRadius);
    }

}