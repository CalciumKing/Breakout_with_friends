using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickParent : MonoBehaviour
{
    [SerializeField] protected List<Sprite> damageSprites;

    [SerializeField] protected int brickHP;
    [SerializeField] protected int pointValue;
    [SerializeField] int currentIndex;

    public virtual void TakeDamage(int damageAmount)
    {
        print("taking damage in parent");
    }
    protected void DamageBrick()
    {
        currentIndex++;
        currentIndex %= damageSprites.Count;
        GetComponent<SpriteRenderer>().sprite = damageSprites[currentIndex];
    }
}