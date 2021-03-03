using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    [SerializeField] private LevelManager levelManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Sushi"))
        {
            levelManager.DecrementCounter();
            Destroy(collision.gameObject);
        }

    }
}
