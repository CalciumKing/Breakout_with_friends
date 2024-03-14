using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] int paddleSpeed = 15;

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        int barrier = 7;

        transform.Translate(Vector2.right * horizontal * paddleSpeed * Time.deltaTime);
        if (transform.position.x > barrier)
        {
            transform.position = new Vector2(barrier, transform.position.y);
        }
        if (transform.position.x < -barrier)
        {
            transform.position = new Vector2(-barrier, transform.position.y);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PowerUp"))
        {
            other.GetComponent<ExtraLife>().ApplyPowerUp();
            Destroy(other.gameObject);
        }
    }
}