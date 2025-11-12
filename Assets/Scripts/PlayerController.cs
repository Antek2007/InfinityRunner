using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Debug.Log("Skok!");
            Jump();
        }
    }

    void Jump()
    {
        rb.AddForce(Vector2.up * 400f);
    }
}
