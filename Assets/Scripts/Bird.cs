using TMPro;
using UnityEngine;

public class Bird : MonoBehaviour
{
    Rigidbody2D rb;
    int score;

    [SerializeField] Manager manager;
    [SerializeField] TextMeshProUGUI scoreText;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezePositionY;
        score = 0;
    }

    void Update()
    {
        if (manager.state == Manager.State.Playing)
            Movement();

        scoreText.text = score.ToString();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            manager.state = Manager.State.GameOver;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Scorer"))
        {
            score++;
        }
    }

    void Movement()
    {
        rb.constraints = RigidbodyConstraints2D.None;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * 9;
        }
        transform.eulerAngles = new Vector3(0, 0, rb.velocity.y * 2);
    }

    public void Restart()
    {
        transform.position = new Vector3(0, 7, 0);
    }
}
