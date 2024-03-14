using System.Collections.Generic;
using UnityEngine;

public class Brick : BrickParent
{
    public Transform explosion;
    public Transform content;

    public override void TakeDamage(int damageAmount)
    {
        brickHP -= damageAmount;
        if (brickHP <= 0)
        {
            ApplyBrickEffect();
            DestroyBrick();
        }
        else DamageBrick();
        base.TakeDamage(damageAmount);
    }
    private void ApplyBrickEffect()
    {
        if (Random.Range(0f, 1f) > .2f)
        {
            print("working");
            Instantiate(content, transform.position, Quaternion.identity);
        }
    }
    private void DestroyBrick()
    {
        GameManager.i.UpdateNumBricks();
        GameManager.i.UpdateScore(1);
        var go = Instantiate(explosion, transform.position, transform.rotation);
        Destroy(go.gameObject, 1.5f);
        Destroy(gameObject);
    }
}