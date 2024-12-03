using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour
{
    public float jumpForce = 5f;
    public Transform platformCheck;
    public LayerMask platformLayer;
    public float platformCheckRadius = 0.2f;

    private Rigidbody2D rb;
    private bool isPlatformed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        isPlatformed = Physics2D.OverlapCircle(platformCheck.position, platformCheckRadius, platformLayer);

        if (Input.GetKeyDown(KeyCode.Space) && isPlatformed)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
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