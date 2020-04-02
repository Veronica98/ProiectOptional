using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestScript : MonoBehaviour
{
    public string tagName;
    public GameObject[] objects;
    public Transform spawnPoint;
    private bool chestOpened = false;

    void OnTriggerEnter2D(Collider2D c)
    {
        
        if (c.gameObject.tag == tagName && !chestOpened) 
        {
            
            OpenChest();
        }
    }

    void OpenChest()
    {
        chestOpened = true;
        GameObject item = Instantiate(objects[Random.Range(0, objects.Length)], spawnPoint.position, spawnPoint.rotation) as GameObject;
        Destroy(gameObject, 3f);

    }
}
