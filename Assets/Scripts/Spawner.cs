using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public List<GameObject> prefabs;
    public float spawnTime;
    private float spawnTimer;

    public bool buffet;
    public Sushi[] sushiList;
    private int sushiCounter;

    private void Awake()
    {
        spawnTimer = spawnTime;
    }

    private void Update()
    {
        if (spawnTimer <= 0)
        {
            if (buffet)
            {
                SpawnRandom();
            } else
            {
                SpawnInOrder();
            }
            spawnTimer = spawnTime;
            LevelManager.instance.DecrementCounter();
        } else
        {
            spawnTimer -= Time.deltaTime;
        }

    }

    private void SpawnInOrder()
    {
        if (sushiCounter < sushiList.Length)
        {
            Sushi sushi = Instantiate(sushiList[sushiCounter], this.transform.position, Quaternion.identity);
            sushiCounter++;
        }
    }

    private void SpawnRandom()
    {
        Instantiate(prefabs[Random.Range(0, prefabs.Count)], this.transform.position, Quaternion.identity);
    }
}
