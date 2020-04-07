using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsDone : MonoBehaviour
{
    private int LevelsDoneCounter;

    //Singleton
    public static LevelsDone Instance { get; private set; }


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }

    }

    private void Start()
    {
        LevelsDoneCounter = 0;
    }

    public int getLevelsDone()
    {
        return LevelsDoneCounter;
    }

    public void setLevelsDone()
    {
        LevelsDoneCounter++;
    }
}
