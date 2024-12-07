using UnityEngine.SceneManagement;
using UnityEngine;

public class DeathTrigger : MonoBehaviour
{

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Respawn") 
        {
            SceneManager.LoadScene(0);
        }
    }


}
