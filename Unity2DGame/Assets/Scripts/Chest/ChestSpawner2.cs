using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestSpawner2 : MonoBehaviour
{
    public GameObject ChestToSpawn;
    public Transform spawnPoint;
    public int maxChests = 3;
    private int difficulty;
    
    void Start()
    {
        Invoke("getDifficulty", 0.5f);
        Vector3 v = new Vector3(-20, 0, 0);
        int spawned = 0;
        
        while(spawned < difficulty && spawned < maxChests)
        {
            
            GameObject x = Instantiate(ChestToSpawn) as GameObject;
            x.transform.position = spawnPoint.position + spawned * v;
            spawned = spawned + 1;
        }
    }
    private void getDifficulty()
    {
        difficulty = GameObject.FindGameObjectWithTag("Difficulty").GetComponent<DifficultyController>().getDifficulty();
    }
}
