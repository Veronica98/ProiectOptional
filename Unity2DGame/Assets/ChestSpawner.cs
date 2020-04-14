using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestSpawner : MonoBehaviour
{
    public GameObject ChestToSpawn;
    public Transform  spawnPoint;
    //DIFFICULTY 1-HARD ; 2-MEDIUM; 3-EASY;
    public int Difficulty;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 v = new Vector3(-20, 0,0);
        bool spawn2 = true;
        bool spawn3 = true;
        GameObject x = Instantiate(ChestToSpawn) as GameObject;
        x.transform.position = spawnPoint.position;
        if (Difficulty >= 2 && spawn2)
        {
            spawn2 = false;
            GameObject y = Instantiate(ChestToSpawn) as GameObject;
            y.transform.position = spawnPoint.position + v;
            if(Difficulty >= 3 && spawn3)
            {
                spawn3 = false;
                GameObject z = Instantiate(ChestToSpawn) as GameObject;
                z.transform.position = spawnPoint.position - v;
            }
        }
        
        
    }

    
}
