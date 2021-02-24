using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SushiHealthText : MonoBehaviour
{
    public float DestroyTime;

    private void Awake()
    {
        Destroy(this.gameObject, DestroyTime);
    }
}
