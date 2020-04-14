using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestSpawner2 : MonoBehaviour
{
    public GameObject ChestToSpawn;
    private Vector2 spawnPoint;
    public int maxChests = 3;
    private int difficulty;
    private float randX;
    private int chestCount = 0;

    void Start()
    {
        Invoke("getDifficulty", 0.5f);
        Invoke("setMaxChests", 0.51f);
        InvokeRepeating("Spawn",0.52f,0.5f);
    }
    private void getDifficulty()
    {
        difficulty = GameObject.FindGameObjectWithTag("Difficulty").GetComponent<DifficultyController>().getDifficulty();
    }

    private void setMaxChests()
    {
        maxChests = difficulty;
    }

    void Spawn()
    {
            randX = transform.position.x + Random.Range(-10f, 10f);
            spawnPoint = new Vector2(randX, transform.position.y);
            GameObject x = Instantiate(ChestToSpawn, spawnPoint, Quaternion.identity);
            chestCount++;        

            if (chestCount >= maxChests)
            {
                CancelInvoke("Spawn");
            }
        }



}

