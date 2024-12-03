using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (transform.position.x < -50)
        {
            Destroy(gameObject);
        }
    }
}