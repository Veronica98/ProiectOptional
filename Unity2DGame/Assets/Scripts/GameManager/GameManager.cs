
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{

    private PlayerStats playerStats;
    private string name;

    bool gameEnded = false;


    private void Awake()
    {
       

        if(GameObject.Find("Player"))
        {
            playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        }
      
        SaveSystem.Init();
        
    }

    public void EndGame()
    {
        if(gameEnded == false)
        {
            gameEnded = true;
            SceneManager.LoadScene("GameOver");
        }
    }


    public void SaveAfterShop()
    {
        SaveObject saveObject = new SaveObject
        {
            maxHealth = playerStats.getMaxHealth(),
            extraJumps = playerStats.getExtraJumps(),
            movementSpeed = playerStats.getMovementSpeed(),
            meleeDamage = playerStats.getMeleeDamage(),
            rangeDamage = playerStats.getRangeDamage(),
            fireRate = playerStats.getFireRate(),
            critChance = playerStats.getCritChance(),
            critDamage = playerStats.getCritDamage(),
            score = playerStats.getScore()
        };

        string json = JsonUtility.ToJson(saveObject);

        SaveSystem.SaveAfterShop(json);
    }

    public void SaveAfterDeath()
    {
        SaveObjectOnDeath saveObject = new SaveObjectOnDeath
        {
            score = playerStats.getScore()
        };

        string json = JsonUtility.ToJson(saveObject);

        SaveSystem.SaveAfterDeath(json);
    }


    public void Load()
    {
        string saveString = SaveSystem.Load();

        if(saveString != null)
        {
            SaveObject saveObject = JsonUtility.FromJson<SaveObject>(saveString);

            playerStats.setLoadedMaxHealth(saveObject.maxHealth);
            playerStats.setLoadedExtraJumps(saveObject.extraJumps);
            playerStats.setLoadedMovementSpeed(saveObject.movementSpeed);
            playerStats.setLoadedMeleeDamage(saveObject.meleeDamage);
            playerStats.setLoadedRangeDamage(saveObject.rangeDamage);
            playerStats.setLoadedFireRate(saveObject.fireRate);
            playerStats.setLoadedCritChance(saveObject.critChance);
            playerStats.setLoadedCritDamage(saveObject.critDamage);
            playerStats.setLoadedScore(saveObject.score);
        }

        string saveStringScore = SaveSystem.LoadScore();

        if (saveStringScore != null)
        {
            SaveObjectOnDeath saveObjectScore = JsonUtility.FromJson<SaveObjectOnDeath>(saveStringScore);
            playerStats.setLoadedScore(saveObjectScore.score);
        }
        else
        {
            SaveObject saveObject = new SaveObject
            {

            };

            playerStats.setLoadedMaxHealth(saveObject.maxHealth);
            playerStats.setLoadedExtraJumps(saveObject.extraJumps);
            playerStats.setLoadedMovementSpeed(saveObject.movementSpeed);
            playerStats.setLoadedMeleeDamage(saveObject.meleeDamage);
            playerStats.setLoadedRangeDamage(saveObject.rangeDamage);
            playerStats.setLoadedFireRate(saveObject.fireRate);
            playerStats.setLoadedCritChance(saveObject.critChance);
            playerStats.setLoadedCritDamage(saveObject.critDamage);
            playerStats.setLoadedScore(saveObject.score);


        }

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

    private class SaveObjectOnDeath
    {
        public int score = 0;
    }
}



