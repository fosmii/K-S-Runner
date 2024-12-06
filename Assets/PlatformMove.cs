using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    public float speed = 5f;
    public float disapperRadius = 25f;
    public float minRandomRange = -2f;
    public float maxRandomRange = 2f;
    public GameObject platform;
    public Transform camera;

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (transform.position.x < -disapperRadius)
        {
            Destroy(gameObject);

            var go = Instantiate(platform, new Vector2(disapperRadius + Random.Range(minRandomRange, maxRandomRange), Random.Range(minRandomRange, maxRandomRange)), Quaternion.identity);
            go.GetComponent<PlatformMove>().enabled = true;
            go.GetComponent<BoxCollider2D>().enabled = true;
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