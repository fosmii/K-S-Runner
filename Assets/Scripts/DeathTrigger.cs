using UnityEngine.SceneManagement;
using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
    public LocalSaveSystem LocalSaveSystem;
    private void Start()
    {
        LocalSaveSystem = GameObject.FindGameObjectWithTag("Manager").GetComponent<LocalSaveSystem>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        Death(collision);
    }

    void Death(Collider2D collision)
    {
        if (collision.tag == "Respawn")
        {
            Debug.Log("death");
            LocalSaveSystem.SaveData();
            Destroy(collision.gameObject);
        }
    }

}
