using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CritChance : MonoBehaviour
{
    private int score;
    [SerializeField] private int cost = 500;
    [SerializeField] private float critChanceChange = 1;
    [SerializeField] private Text critChanceText;



    public void upgradeCritChance()
    {
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreSkillTree>().getScore();
        if (score - cost > 0.00001)
        {
            score -= cost;
            string saveString = SaveSystem.Load();

            if (saveString != null)
            {
                SaveObject saveObject = JsonUtility.FromJson<SaveObject>(saveString);
                saveObject.critChance += critChanceChange;
                saveObject.score -= cost;
                string json = JsonUtility.ToJson(saveObject);
                SaveSystem.SaveAfterShop(json);
                critChanceText.text = "Crit Chance: " + saveObject.critChance.ToString();
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
