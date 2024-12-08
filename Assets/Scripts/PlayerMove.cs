using UnityEngine;
using System.Threading.Tasks;

public class PlayerMove : MonoBehaviour
{
    public float minJumpForce = 5f;
    public float fallForce = 5f;
    public Transform checkSmthng;
    public LayerMask platformLayer;
    public float platformCheckRadius = 0.2f;

    public int maxJumpCount = 2;
    public float dashLenght = 2f;


    public int jumpCount;
    private Rigidbody2D rb;
    private bool isPlatformed;
    public ScoreText ScoreTextScript;
    public PlatformMove PlatformMove;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        PlatformMove = GameObject.FindGameObjectWithTag("Platform").GetComponent<PlatformMove>();
        Application.targetFrameRate = 120;
    }

    void Update()
    {

        isPlatformed = Physics2D.OverlapCircle(checkSmthng.position, platformCheckRadius, platformLayer);
        if (isPlatformed)
        {
            jumpCount = maxJumpCount;
        }


        if ((Input.GetMouseButtonDown(0)) && jumpCount > 1)
        {
            jumpCount--;
            rb.velocity = new Vector2(rb.velocity.x, (minJumpForce) * 1);
        }

        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log(dashLenght);
            PlatformMove.Dash(dashLenght);
        }

        if (rb.velocity.y < 0)
        {
            rb.AddForce(Vector2.down * fallForce);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (checkSmthng != null)
        {
            Gizmos.color = Color.white;
            Gizmos.DrawWireSphere(checkSmthng.position, platformCheckRadius);
        }
    }
}