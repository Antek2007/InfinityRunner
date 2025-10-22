using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Na Starcie

    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Co klatke
    void Update()
    {
        // czy klinal spacje
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up*400f);
        }
    }
}
