using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public List<GameObject> prefabs;
    public float spawnTime;
    private float spawnTimer;

    private Level level;
    private LevelManager levelManager;

    // Nonbuffet
    private int currentSushi = 0;

    private void Start()
    {
        spawnTimer = spawnTime;
        levelManager = GetComponent<LevelManager>();
        level = levelManager.level;
    }

    private void Update()
    {
        if (spawnTimer <= 0)
        {

            Spawn(level == null);
            spawnTimer = spawnTime;
        } else
        {
            spawnTimer -= Time.deltaTime;
        }

    }

    private void Spawn(bool buffet)
    {
        if (buffet || currentSushi < level.spawnString.Length)
        {
            int sushiIndex = buffet ? Random.Range(0, prefabs.Count) : level.spawnString[currentSushi++] - '0';
            Sushi sushi = Instantiate(prefabs[sushiIndex], this.transform.position, Quaternion.identity).GetComponent<Sushi>();
            sushi.Init(levelManager, sushiIndex);
        }
    }
}
