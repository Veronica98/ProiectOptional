using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    private float randX;
    private Vector2 whereToSpawn;
    [SerializeField] private float spawnRate = 2f;
    private float nextSpawn;



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



}
