using UnityEngine;

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
    public Animator animator;

    void Start()
    {
        Time.timeScale = 1f;
        rb = GetComponent<Rigidbody2D>();
        Application.targetFrameRate = 120;
    }

    void Update()
    {
        if (gameObject != null)
        {
            isPlatformed = Physics2D.OverlapCircle(checkSmthng.position, platformCheckRadius, platformLayer);
            if (isPlatformed && Mathf.Abs(rb.linearVelocity.y) < 0.1f)
            {
                jumpCount = maxJumpCount;
                animator.SetBool("Jumping", false);
            }
            else
            {
                animator.SetBool("Jumping", true);
            }


            if ((Input.GetMouseButtonDown(0)) && jumpCount >= 1)
            {
                jumpCount--;
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, (minJumpForce) * 1);

            }
            animator.SetFloat("rbvelocityY", rb.linearVelocity.y);
            if (rb.linearVelocity.y < 0)
            {
                rb.AddForce(Vector2.down * fallForce);
                Debug.Log($"rb.velocity.y " +  rb.linearVelocity.y);
            }
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
    