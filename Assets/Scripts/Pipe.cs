using UnityEngine;

public class Pipe : MonoBehaviour
{
    Rigidbody2D rb;

    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.velocity = Vector2.left * 2f;
    }
}
