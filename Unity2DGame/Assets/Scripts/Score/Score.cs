using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour
{
    private int score;

    Text text;



    void Start()
    {
        text = GetComponent<Text>();
    }

    
    void Update()
    {
        text.text = "Score: " + score;   
    }


    public int getScore()
    {
        return score;
    }

    public void setScore(int scoreChange)
    {
        score += scoreChange;
    }

    public void setStartingScore(int startingScore)
    {
        score = startingScore;
    }
}
