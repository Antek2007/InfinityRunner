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
    [SerializeField] float crouchScaleY = 0.5f;//!!!

    private int jumpCount = 1;

    [SerializeField] float jumpForce = 12;

    private Vector3 startScale;
    Vector3 crouchScale;//!!!

    bool isCrouching = false;

    private Rigidbody2D rb;
    void Start()
    {
        startScale = transform.localScale; //skala startowa gracza
        rb = GetComponent<Rigidbody2D>();
        crouchScale = new Vector3(startScale.x, startScale.y * crouchScaleY, startScale.z);//skala crouch gracza
    }

    void Update()
    {


        if (Input.GetKey(KeyCode.LeftControl) && !isCrouching)
        {
            Debug.Log("Kucniecie!");
            StartCrouching();
        }

        if(Input.GetKeyUp(KeyCode.LeftControl) && isCrouching)
        {
            Debug.Log("Nie kuca");
            StopCrouching();
        }

        if (Input.GetKeyDown(KeyCode.Space) && jumpCount<maxJumps) {
            Debug.Log("Skok!");
            Jump();
        }

        if (IsGrounded()) jumpCount = 1;
    }

    void StartCrouching()
    {
        isCrouching = true;
        transform.localScale = crouchScale;
        transform.localPosition -= new Vector3(0, startScale.y * crouchScaleY, 0);
    }

    void StopCrouching()
    {
        isCrouching = false;
        transform.localScale = startScale;
        transform.localPosition += new Vector3(0, startScale.y * crouchScaleY, 0);
    }

    bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down,length, groundMask);
        return hit.collider != null;
    }

    void Jump()
    {
        jumpCount++;
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * length);
    }
}
