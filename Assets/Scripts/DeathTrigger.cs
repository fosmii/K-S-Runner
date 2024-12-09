using UnityEngine.SceneManagement;
using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        Death(collision);
    }

    void Death(Collider2D collision)
    {
        if (collision.tag == "Respawn")
        {
            SceneManager.LoadScene(0);
        }
    }

}
