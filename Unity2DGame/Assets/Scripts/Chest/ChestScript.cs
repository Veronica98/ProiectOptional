using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestScript : MonoBehaviour
{
    public string tagName;
    public GameObject[] objects;
    public Transform spawnPoint;
    private bool chestOpened = false;
    [SerializeField] private Animator animator;
    private bool animationEnd = false;




    void OnTriggerEnter2D(Collider2D c)
    {
        
        if (c.gameObject.tag == tagName && !chestOpened) 
        {
            
            OpenChest();
        }
    }


    void animationStatusChange(string animationStatusChanged)
    {
        if (animationStatusChanged == "true")
        {
            animationEnd = true;
        }
    }



    void OpenChest()
    {
        

        chestOpened = true;
        animator.SetBool("Open", true);
        int random = Random.Range(0, 100);

        if(random == 0 )
        {
            GameObject item = Instantiate(objects[0], spawnPoint.position, spawnPoint.rotation) as GameObject;
        }

        else if (random > 0 && random <= 2)
        {
            GameObject item = Instantiate(objects[1], spawnPoint.position, spawnPoint.rotation) as GameObject;
        }

        else if (random > 2 && random <= 5)
        {
            GameObject item = Instantiate(objects[2], spawnPoint.position, spawnPoint.rotation) as GameObject;
        }

        else if (random > 5 && random <= 10)
        {
            GameObject item = Instantiate(objects[3], spawnPoint.position, spawnPoint.rotation) as GameObject;
        }

        else if (random > 10 && random <= 16)
        {
            GameObject item = Instantiate(objects[4], spawnPoint.position, spawnPoint.rotation) as GameObject;
        }

        else if (random > 16 && random <= 23)
        {
            GameObject item = Instantiate(objects[5], spawnPoint.position, spawnPoint.rotation) as GameObject;
        }

        else if (random > 23 && random <= 33)
        {
            GameObject item = Instantiate(objects[6], spawnPoint.position, spawnPoint.rotation) as GameObject;
        }

        else if (random > 33 && random <= 44)
        {
            GameObject item = Instantiate(objects[7], spawnPoint.position, spawnPoint.rotation) as GameObject;
        }

        else if (random > 44 && random <= 59)
        {
            GameObject item = Instantiate(objects[8], spawnPoint.position, spawnPoint.rotation) as GameObject;
        }

        else if (random > 59 && random <= 78)
        {
            GameObject item = Instantiate(objects[9], spawnPoint.position, spawnPoint.rotation) as GameObject;
        }

        else if (random > 78 && random <= 99)
        {
            GameObject item = Instantiate(objects[10], spawnPoint.position, spawnPoint.rotation) as GameObject;
        }

        Destroy(gameObject, 2f);

    }
}
