using UnityEngine.SceneManagement;
using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
    public LocalSaveSystem LocalSaveSystem;
    private void Start()
    {
        LocalSaveSystem = GameObject.FindGameObjectWithTag("Manager").GetComponent<LocalSaveSystem>();
        if (LocalSaveSystem == null)
        {
            Debug.Log("pizdaaa");
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        Death(collision);
    }

    void Death(Collider2D collision)
    {
        if (collision.tag == "Respawn")
        {
            LocalSaveSystem.SaveData();
            SceneManager.LoadScene(0);
        }
    }

}
