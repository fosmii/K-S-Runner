using UnityEngine;
using System.Threading.Tasks;

public class PlayerMove : MonoBehaviour
{
    public float minJumpForce = 5f;
    public float fallForce = 5f;
    public Transform platformCheck;
    public LayerMask platformLayer;
    public float platformCheckRadius = 0.2f;
    public int maxJumpCount = 2;


    private int jumpCount;
    private Rigidbody2D rb;
    private bool isPlatformed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        isPlatformed = Physics2D.OverlapCircle(platformCheck.position, platformCheckRadius, platformLayer);
        if (isPlatformed)
        {
            jumpCount = maxJumpCount;
        }


        if ((Input.GetKeyDown(KeyCode.Space) || Input.touchCount > 0) && jumpCount > 1)
        {
            jumpCount--;
            rb.velocity = new Vector2(rb.velocity.x, (minJumpForce) * 1);
        }

        if (rb.velocity.y < 0)
        {
            rb.AddForce(Vector2.down * fallForce);

        }
    }



    void OnDrawGizmosSelected()
    {
        if (platformCheck != null)
        {
            Gizmos.color = Color.white;
            Gizmos.DrawWireSphere(platformCheck.position, platformCheckRadius);
        }
    }
}