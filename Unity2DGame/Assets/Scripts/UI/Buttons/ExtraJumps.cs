using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExtraJumps : MonoBehaviour
{
    private int score;
    [SerializeField] private int cost = 600;
    [SerializeField] private int extraJumpsChange = 1;
    [SerializeField] private Text extraJumpsText;
    private float limitExtraJumps = 5;



    public void upgradeExtraJumps()
    {
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreSkillTree>().getScore();
        if (score - cost > 0.00001)
        {

            string saveString = SaveSystem.Load();

            if (saveString != null)
            {

                SaveObject saveObject = JsonUtility.FromJson<SaveObject>(saveString);

                if (saveObject.extraJumps + extraJumpsChange <= limitExtraJumps)
                {
                    score -= cost;
                    saveObject.extraJumps += extraJumpsChange;
                    saveObject.score -= cost;
                    string json = JsonUtility.ToJson(saveObject);
                    SaveSystem.SaveAfterShop(json);
                    extraJumpsText.text = "Extra Jumps: " + saveObject.extraJumps.ToString();
                    GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreSkillTree>().setScore(-cost);
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
