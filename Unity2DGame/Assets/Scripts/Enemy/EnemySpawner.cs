using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    private float randX;
    private Vector2 whereToSpawn;
    private float spawnRate = 5f;
    private int enemyCount = 0;
    public int maxEnemyCount = 2;
    private float nextSpawn;
    private int difficulty;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Invoke("getDifficulty", 0.5f);
        Invoke("setSpawnStats", 0.51f);
        InvokeRepeating("Spawn", 0, spawnRate);
    }

   /* private void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            randX = transform.position.x + Random.Range(-2f, 2f);
            whereToSpawn = new Vector2(randX, transform.position.y);
            Instantiate(enemies[Random.Range(0, enemies.Length)], whereToSpawn, Quaternion.identity);
        }
    }
    */


    private void getDifficulty()
    {
        difficulty = GameObject.FindGameObjectWithTag("Difficulty").GetComponent<DifficultyController>().getDifficulty();
    }

    private void setSpawnStats()
    {

        if(difficulty != 0)
        {
            spawnRate = spawnRate / difficulty;
            maxEnemyCount = maxEnemyCount + difficulty / 2;
        }

    }



    void Spawn()
    {

        if ((Vector3.Distance(transform.position, player.transform.position) < 40))
        {
            randX = transform.position.x + Random.Range(-2f, 2f);
            whereToSpawn = new Vector2(randX, transform.position.y);
            Instantiate(enemies[Random.Range(0, enemies.Length)], whereToSpawn, Quaternion.identity);

            enemyCount++;
            if (enemyCount >= maxEnemyCount)
            {
                CancelInvoke("Spawn");
            }
        }



    }

   
}


