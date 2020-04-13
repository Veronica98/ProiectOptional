using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSkillTree : MonoBehaviour
{
    private int score;

    Text text;

    [SerializeField] private Text maxHealth;
    [SerializeField] private Text meleeDamage;
    [SerializeField] private Text rangeDamage;
    [SerializeField] private Text critChance;
    [SerializeField] private Text movementSpeed;
    [SerializeField] private Text critDamage;
    [SerializeField] private Text extraJumps;
    [SerializeField] private Text fireRate;



    void Start()
    {
        text = GetComponent<Text>();
        LoadGame();
    }


    void Update()
    {
        text.text = "Score: " + score;
    }


    public void setStartingScore(int startingScore)
    {
        score = startingScore;
    }

    public void LoadGame()
    {

        string saveString = SaveSystem.Load();

        if (saveString != null)
        {
            SaveObject saveObject = JsonUtility.FromJson<SaveObject>(saveString);
            score = saveObject.score;
            maxHealth.text += saveObject.maxHealth.ToString();
            meleeDamage.text += saveObject.meleeDamage.ToString();
            rangeDamage.text += saveObject.rangeDamage.ToString();
            critChance.text += saveObject.critChance.ToString();
            movementSpeed.text += saveObject.movementSpeed.ToString();
            critDamage.text += saveObject.critDamage.ToString();
            extraJumps.text += saveObject.extraJumps.ToString();
            fireRate.text += saveObject.fireRate.ToString();
            

        }

    }


    public int getScore()
    {
        return score;
    }

    public void setScore(int newScore)
    {
        score += newScore;
    }


    private class SaveObject
    {
        public float maxHealth = 50;
        public int extraJumps = 1;
        public float movementSpeed = 10;
        public float meleeDamage = 20;
        public float rangeDamage = 20;
        public float fireRate = 0.5f;
        public float critChance = 10f;
        public float critDamage = 50f;
        public int score = 0;
    }
}
