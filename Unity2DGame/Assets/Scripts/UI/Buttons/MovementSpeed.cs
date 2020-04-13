using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementSpeed : MonoBehaviour
{
    private int score;
    [SerializeField] private int cost = 100;
    [SerializeField] private float movementSpeedChange = 1;
    [SerializeField] private Text movementSpeedText;
    private float limitMovementSpeed = 50;



    public void upgradeMovementSpeed()
    {
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreSkillTree>().getScore();
        if (score - cost > 0.00001 )
        {
            
            string saveString = SaveSystem.Load();

            if (saveString != null)
            {
                
                SaveObject saveObject = JsonUtility.FromJson<SaveObject>(saveString);

                if(saveObject.movementSpeed + movementSpeedChange <= limitMovementSpeed)
                {
                    score -= cost;
                    saveObject.movementSpeed += movementSpeedChange;
                    saveObject.score -= cost;
                    string json = JsonUtility.ToJson(saveObject);
                    SaveSystem.SaveAfterShop(json);
                    movementSpeedText.text = "Movement Speed: " + saveObject.movementSpeed.ToString();
                    GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreSkillTree>().setScore(-cost);
                }

                else
                {
                    movementSpeedText.text = "Movement Speed: MAX";
                }
                
            }


        }
    }


    public void Test()
    {
        Debug.Log("Merge on click");
    }



    private class SaveObject
    {
        public float maxHealth = 50;
        public int extraJumps = 1; //
        public float movementSpeed = 10;
        public float meleeDamage = 20;
        public float rangeDamage = 20;
        public float fireRate = 0.5f; // 0.05
        public float critChance = 10f; 
        public float critDamage = 50f;
        public int score = 0;
    }
}
