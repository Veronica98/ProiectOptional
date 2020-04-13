using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireRate : MonoBehaviour
{
    private int score;
    [SerializeField] private int cost = 100;
    [SerializeField] private float fireRateChange = 0.005f;
    [SerializeField] private Text fireRateText;
    private float limitFireRate = 0.05f;



    public void upgradeMovementSpeed()
    {
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreSkillTree>().getScore();
        if (score - cost > 0)
        {
            Debug.Log("intra primu");
            string saveString = SaveSystem.Load();

            if (saveString != null)
            {
                Debug.Log("intra doi");
                SaveObject saveObject = JsonUtility.FromJson<SaveObject>(saveString);

                if (saveObject.fireRate - fireRateChange >= limitFireRate)
                {
                    Debug.Log("intra trei");
                    score -= cost;
                    saveObject.fireRate -= fireRateChange;
                    saveObject.score -= cost;
                    string json = JsonUtility.ToJson(saveObject);
                    SaveSystem.SaveAfterShop(json);
                    fireRateText.text = "Fire Rate: " + saveObject.fireRate.ToString();
                    GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreSkillTree>().setScore(-cost);
                }

                else
                {
                    fireRateText.text = "Fire Rate: MAX";
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
