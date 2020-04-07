using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyController : MonoBehaviour
{
    private int difficulty;
    private int score;
    private int levelsDone;
    // Start is called before the first frame update
    void Start()
    {
        getScore();
        getLevelsDone();
        Invoke("setDifficulty", 0.000000000001f);
    }


    private void getLevelsDone()
    {
        levelsDone = GameObject.FindGameObjectWithTag("LevelsDone").GetComponent<LevelsDone>().getLevelsDone();

    }

    public void setScore(int newScore)
    {
        score = newScore;
    }
    
    public void getScore()
    {
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>().getScore();
    }

    private void setDifficulty()
    {
        if(levelsDone != 0)
        {
            difficulty = ((score / 10) + (levelsDone * 100)) / 100;
        }
        else
        {
            difficulty = score / 1000;
        }

    }


    public int getDifficulty()
    {
        return difficulty;
    }
}
