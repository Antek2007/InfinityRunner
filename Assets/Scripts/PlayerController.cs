using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public LayerMask groundMask;
    public float length = 0.6f;

    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded()) {
            Debug.Log("Skok!");
            Jump();
        }
    }

    bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down,length, groundMask);
        return hit.collider != null;
    }

    void Jump()
    {
        rb.AddForce(Vector2.up * 400f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * length);
    }
}
