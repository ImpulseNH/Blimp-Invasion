using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [Header("Objects")]
    public GameObject[] enemyPrefabs;
    public Transform spawnArea;
    public Transform parent;

    [Header("Wave Spawner")]
    public float repeatRate;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemies", 1f, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemies()
    {
        var spawnPosition = new Vector2(spawnArea.position.x, Random.Range(-2, 5));
        int enemyProbability =  Random.Range(1,10);
        if(enemyProbability == 1)
            Instantiate(enemyPrefabs[0], spawnPosition, Quaternion.identity, parent);
        else
            Instantiate(enemyPrefabs[1], spawnPosition, Quaternion.identity, parent);
    }
}
