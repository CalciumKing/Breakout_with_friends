using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraLife : MonoBehaviour
{
    [SerializeField] int fallSpeed;
    [SerializeField] int addLives = 1;
    private void Update()
    {
        FallDown();
    }
    private void FallDown()
    {
        transform.Translate(Vector2.down * Time.deltaTime * fallSpeed);
    }
    public void ApplyPowerUp()
    {
        GameManager.i.UpdateNumLives(addLives);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bottom"))
        {
            Destroy(gameObject);
        }
    }
}