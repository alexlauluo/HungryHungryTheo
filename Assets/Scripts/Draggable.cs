using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    private Rigidbody2D rb;
    public float dragSpeed;
    private Camera main;
    private float originalGravity;
    private Collider2D sushiCollider;

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody2D>();
        main = Camera.main;
        originalGravity = rb.gravityScale;
        sushiCollider = this.GetComponent<CircleCollider2D>();
    }

    private void OnMouseDrag()
    {
        rb.gravityScale = 0f;
        Vector2 mousePos = (Vector2)main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D[] hits = Physics2D.RaycastAll(mousePos, Vector2.zero, 1f);
        Vector2 direction = (mousePos - (Vector2)this.transform.position);
        rb.velocity = direction.normalized * dragSpeed * direction.magnitude;

    }

    private void OnMouseDown()
    {
        AudioManager.instance.Play("pickup");
        
    }
    private void OnMouseUp()
    {
        rb.gravityScale = originalGravity;
        
    }
}
