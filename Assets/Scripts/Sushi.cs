using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sushi : MonoBehaviour
{
    public int health; //temporarily keep constant at 3

    public Sprite[] images;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    public void TakeDamage()
    {
        health--;
        UpdateSprite();
        if (health <= 0)
        {
            Eaten();
        }
    }

    private void Eaten()
    {
        this.tag = "Plate";
        this.GetComponent<CircleCollider2D>().isTrigger = true; //removes the physical hitbox for the plate by turning it into a trigger
        FindObjectOfType<GachaponManager>().Enable();
    }

    private void UpdateSprite()
    {
        spriteRenderer.sprite = images[health];
    }
}
