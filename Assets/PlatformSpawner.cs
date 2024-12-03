using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platform; 
    public float spawnRate = 2f;
    public float maxHeightSpawn = 5f;
    public float minHeightSpawn = -5f;

    private float timer = 0;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnRate)
        {
            SpawnPlatform();
            timer = 0;
        }
    }

    void SpawnPlatform()
    {

        float randomY = Random.Range(minHeightSpawn, maxHeightSpawn);
        Instantiate(platform, new Vector2(20, randomY), Quaternion.identity);
    }
}