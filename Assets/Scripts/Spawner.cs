using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> prefabs;
    public float spawnTime;
    private float spawnTimer;

    private void Awake()
    {
        spawnTimer = spawnTime;
    }

    private void Update()
    {
        if (spawnTimer <= 0)
        {
            Instantiate(prefabs[Random.Range(0, prefabs.Count)], this.transform.position, Quaternion.identity);
            spawnTimer = spawnTime;
        } else
        {
            spawnTimer -= Time.deltaTime;
        }
    }


}
