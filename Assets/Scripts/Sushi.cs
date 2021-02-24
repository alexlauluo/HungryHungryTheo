using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sushi : MonoBehaviour
{
    public int maxHealth;
    private int currHealth;

    public int points;

    public Sprite[] images;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        currHealth = maxHealth;
    }

    public void TakeDamage()
    {
        currHealth--;
        UpdateSprite();
        if (currHealth <= 0)
        {
            Eaten();
        }
    }

    private void Eaten()
    {
        this.tag = "Plate";
        this.GetComponent<CircleCollider2D>().isTrigger = true; //removes the physical hitbox for the plate by turning it into a trigger
        //FindObjectOfType<GachaponManager>().Enable();
        LevelManager.instance.UpdateScore(points);
    }

    private void UpdateSprite()
    {
        int spriteHealth = (int)((float)currHealth / maxHealth * 3);
        if (currHealth != 0 && spriteHealth == 0)
        {
            spriteRenderer.sprite = images[1];
        } else
        {
            spriteRenderer.sprite = images[(int)((float)currHealth / maxHealth * 3)];
        }
    }

    private void OnDestroy()
    {
        LevelManager.instance.DecrementCounter();
    }
}
