﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RangeDamage : MonoBehaviour
{
    private int score;
    [SerializeField] private int cost = 100;
    [SerializeField] private float rangeDamageChange = 10;
    [SerializeField] private Text rangeDamageText;



    public void upgradeRangeDamage()
    {
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreSkillTree>().getScore();
        if (score - cost > 0.00001)
        {
            score -= cost;
            string saveString = SaveSystem.Load();

            if (saveString != null)
            {
                SaveObject saveObject = JsonUtility.FromJson<SaveObject>(saveString);
                saveObject.rangeDamage += rangeDamageChange;
                saveObject.score -= cost;
                string json = JsonUtility.ToJson(saveObject);
                SaveSystem.SaveAfterShop(json);
                rangeDamageText.text = "Range Damage: " + saveObject.rangeDamage.ToString();
            }

            GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreSkillTree>().setScore(-cost);
        }
    }


    public void Test()
    {
        Debug.Log("Merge on click");
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
