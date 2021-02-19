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
        if (!HasSushiCollider(hits))
        {
            rb.velocity = (mousePos - (Vector2)this.transform.position).normalized * dragSpeed;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void OnMouseUp()
    {
        rb.gravityScale = originalGravity;
    }

    private bool HasSushiCollider(RaycastHit2D[] hits)
    {
        for (int i = 0; i<hits.Length; i++)
        {
            if (hits[i].collider.Equals(sushiCollider))
            {
                return true;
            }
        }
        return false;
    }
}
