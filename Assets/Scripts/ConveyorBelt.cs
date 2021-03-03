using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    public float speed;
    private Vector2 direction = new Vector2(-1, 0); //hard code conveyor belt to move left

    void Start(){
        Animator animator = GetComponent<Animator>();
        animator.speed = (float) speed / 100;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {   
        if (collision.CompareTag("Sushi") || collision.CompareTag("Plate"))
        {
            collision.attachedRigidbody.velocity = Time.deltaTime * speed * direction;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Sushi") || collision.CompareTag("Plate"))
        {
            collision.attachedRigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Sushi") || collision.CompareTag("Plate"))
        {
            collision.attachedRigidbody.constraints = RigidbodyConstraints2D.None;
        }
    }
}
