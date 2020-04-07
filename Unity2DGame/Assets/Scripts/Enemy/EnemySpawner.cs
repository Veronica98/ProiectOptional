using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    private float randX;
    private Vector2 whereToSpawn;
    private float spawnRate = 5f;
    private float nextSpawn;
    private int difficulty;

    private void Start()
    {
        Invoke("getDifficulty", 0.5f);
        Invoke("setSpawnRate", 0.51f);
    }

    private void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            randX = transform.position.x + Random.Range(-2f, 2f);
            whereToSpawn = new Vector2(randX, transform.position.y);
            Instantiate(enemies[Random.Range(0, enemies.Length)], whereToSpawn, Quaternion.identity);
        }
    }


    private void getDifficulty()
    {
        difficulty = GameObject.FindGameObjectWithTag("Difficulty").GetComponent<DifficultyController>().getDifficulty();
    }

    private void setSpawnRate()
    {
        Debug.Log("Difficulty is for spawner: " + difficulty);
        Debug.Log("Old spawn rate is" + spawnRate);
        if(difficulty != 0)
        {
            spawnRate = spawnRate / difficulty;
        }

        Debug.Log("new spawnRate = " + spawnRate);

    }

}
