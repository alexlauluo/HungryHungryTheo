using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Theodore : MonoBehaviour
{
    //public float chewTime;
    //private float chewTimer;

    private Animator animator;
    [HideInInspector]
    public bool isEating = false;

    [HideInInspector]
    public bool hasHat, hasGlasses, hasScarf;

    private List<Sushi> colliders;

    private void Awake()
    {
        //chewTimer = chewTime;
        animator = this.GetComponent<Animator>();
        colliders = new List<Sushi>();
        UpdateAccessories();
    }
    private void Update()
    {
        //chewTimer -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) && colliders.Count > 0)
        {
            for (int i=0; i < colliders.Count; i++)
            {
                if (colliders[0].CompareTag("Sushi"))
                {
                    colliders[0].TakeDamage();
                    StartCoroutine(StartEatAnimation());
                    break;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Sushi sushi = collision.GetComponent<Sushi>();
        if (!colliders.Contains(sushi))
        {
            colliders.Add(sushi);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Sushi sushi = collision.GetComponent<Sushi>();
        colliders.Remove(sushi);
    }

    /*
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.Space) && collision.CompareTag("Sushi"))
        {
            //StartCoroutine(Eat(collision.transform.GetComponent<Sushi>()));
            //chewTimer = chewTime; 
            Debug.Log("AAAAAAAAAAAAAA");
            animator.SetTrigger("Eating");
            collision.GetComponent<Sushi>().TakeDamage();
        }
    }
    */

    IEnumerator StartEatAnimation()
    {
        isEating = true;
        animator.SetBool("Eating", true);
        yield return new WaitForSeconds(1f);
        animator.SetBool("Eating", false);
        isEating = false;
    }

    public void UpdateAccessories()
    {
        animator.SetBool("hasHat", hasHat);
        animator.SetBool("hasGlasses", hasGlasses);
        animator.SetBool("hasScarf", hasScarf);
    }
}
