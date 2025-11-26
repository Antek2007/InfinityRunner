using UnityEngine;

/*
 ====================
 TO DO: 
force change to linear velocity
timeout for jump

 ====================
 */

public class PlayerController : MonoBehaviour
{
    public LayerMask groundMask;
    public float length = 0.6f;
    public int maxJumps = 2;

    private int jumpCount = 1;

    private Vector3 startScale;

    private Rigidbody2D rb;
    void Start()
    {
        startScale = transform.localScale; //skala startowa gracza
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Debug.Log("Kucniecie!");

            //transform.localScale 
        }

        if (Input.GetKeyDown(KeyCode.Space) && jumpCount<maxJumps) {
            Debug.Log("Skok!");
            Jump();
        }

        if (IsGrounded()) jumpCount = 1;
    }

    bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down,length, groundMask);
        return hit.collider != null;
    }

    void Jump()
    {
        jumpCount++; 
        rb.AddForce(Vector2.up * 400f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * length);
    }
}
