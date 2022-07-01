using UnityEngine;

public class Background : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private Rigidbody2D rb;

    private float width;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        width = boxCollider.size.x;
        rb.velocity=new Vector2 (-2, 0);
    }

    void Update()
    {
        if (transform.position.x < -width * 2)
        {
            RePos();
        }
    }

    private void RePos()
    {
        Vector2 vector = new Vector2(width * 4f, 0);
        transform.position = (Vector2)transform.position + vector;
    }

}
