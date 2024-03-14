using UnityEngine;

public class Ball : MonoBehaviour
{
    public Transform startPosition;

    Rigidbody2D rb;

    bool inPlay = false;

    [SerializeField] int speed = 500;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        ResetBall();
    }
    public void ResetBall()
    {
        inPlay = false;
        rb.velocity = Vector2.zero;
    }
    private void Update()
    {
        if (!inPlay) transform.position = startPosition.position;
        if (Input.GetButtonDown("Jump") && !inPlay)
        {
            inPlay = true;
            rb.AddForce(Vector2.up * speed);
        }
    }
    private void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.gameObject.CompareTag("Bottom"))
        {
            ResetBall();
            if (!GameManager.i.LevelPassed()) GameManager.i.UpdateNumLives();
        }
    }
    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.CompareTag("Brick")) collider.gameObject.GetComponent<BrickParent>().TakeDamage(1);
    }
}