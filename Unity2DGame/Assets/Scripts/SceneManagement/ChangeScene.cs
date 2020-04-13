using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    private Transform playerTransform;
    private int currentIndex;
    private int nextIndex;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        generateRandomIndex();
        Debug.Log("Next Index: " + nextIndex);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("LevelsDone").GetComponent<LevelsDone>().setLevelsDone();
            
            SceneManager.LoadScene(nextIndex);
            playerTransform.position = new Vector3(0f, 0f, 0f);

        }
    }

    private void generateRandomIndex()
    {
        currentIndex = SceneManager.GetActiveScene().buildIndex;
        nextIndex = Random.Range(1, 4);
        if(nextIndex == currentIndex)
        {
            nextIndex = ((nextIndex + 1) % 3)+1;
        }

    }



    
}
