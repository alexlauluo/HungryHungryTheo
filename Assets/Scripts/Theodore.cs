using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Theodore : MonoBehaviour
{
    public float chewTime;
    private float chewTimer;

    private Animator animator;
    [HideInInspector]
    public bool isEating = false;

    [HideInInspector]
    public bool hasHat, hasGlasses, hasScarf;

    private void Awake()
    {
        chewTimer = chewTime;
        animator = this.GetComponent<Animator>();
        UpdateAccessories();
    }
    private void Update()
    {
        chewTimer -= Time.deltaTime;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (chewTimer <= 0 && !isEating && collision.CompareTag("Sushi"))
        {
            StartCoroutine(Eat(collision.transform.GetComponent<Sushi>()));
            chewTimer = chewTime;       
        }
    }

    IEnumerator Eat(Sushi victim)
    {
        isEating = true;
        animator.SetBool("Eating", true);
        victim.TakeDamage();
        yield return new WaitForSeconds(chewTime);
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
