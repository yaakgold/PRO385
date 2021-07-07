using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> spawnables;

    public float timeBetweenSpawns;
    public float minTime, maxTime;

    float timeSinceLastSpawn = 0;

    private void Start()
    {
        Spawn();
        timeBetweenSpawns = Random.Range(minTime, maxTime);
    }

    private void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if(timeSinceLastSpawn >= timeBetweenSpawns)
        {
            timeSinceLastSpawn = 0;
            timeBetweenSpawns = Random.Range(minTime, maxTime);
            Spawn();
        }
    }

    public void Spawn()
    {
        Instantiate(spawnables[Random.Range(0, spawnables.Count)], transform.position, Quaternion.identity);
    }
}
