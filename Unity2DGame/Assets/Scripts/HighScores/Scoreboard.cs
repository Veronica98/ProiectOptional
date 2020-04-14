using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace vlad.Scoreboards
{
    public class Scoreboard : MonoBehaviour
    {
        [SerializeField] private int maxScoreboardEntries = 3;
        [SerializeField] private Transform highscoresHolderTransform = null;
        [SerializeField] private GameObject scoreboardEntryObject = null;

        
        private string SavePath => $"{Application.dataPath}/highscores.json";


        private long numberOfSaves;
        private string path;
        DirectoryInfo info;

        private List<ScoreboardEntryData> hs_list = new List<ScoreboardEntryData>();

        public static long SavesCount(DirectoryInfo info)
        {
            long i = 0;
            // Add file sizes.
            FileInfo[] fis = info.GetFiles();
            foreach (FileInfo fi in fis)
            {
                if (!fi.Extension.Contains("meta"))
                {
                    i++;
                }

            }
            return i;

        }


        public void  add_hs_list()
        {
            FileInfo[] fis = info.GetFiles();
            foreach (FileInfo fi in fis)
            {

                if (!fi.Extension.Contains("meta"))
                {
                    int index = fi.Name.IndexOf("_");
                    string nume = Path.GetFileNameWithoutExtension(fi.FullName).Substring(index + 1);
                    string saveString = SaveSystem.Load(nume);
                    
                    if (saveString != null)
                    {
                        
                        SaveObject saveObject = JsonUtility.FromJson<SaveObject>(saveString);
                        ScoreboardEntryData hs_test = new ScoreboardEntryData();
                        hs_test.entryName = nume;
                        hs_test.entryScore = saveObject.score;
                      
                        hs_list.Add(hs_test);
                            
                    }

                }
            }
        }
        
        private void Start()
        {

            path = Application.dataPath + "/Saves";
            info = new DirectoryInfo(path);
            numberOfSaves = SavesCount(info);
            SavesCount(info);

            add_hs_list();

         

            SaveScores();

            UpdateUI(hs_list);

            
        }

        
        public void AddEntry(ScoreboardEntryData scoreboardEntryData)
        {
            ScoreboardSaveData savedScores = GetSavedScores();

            bool scoreAdded = false;

            foreach (ScoreboardEntryData hs_score in hs_list)
            {
                add_hs_list();
            }

        

            //Check if the score can be added to the end of the list.
            if (!scoreAdded && savedScores.highscores.Count < maxScoreboardEntries)
            {
                savedScores.highscores.Add(scoreboardEntryData);
            }

            //Remove any scores past the limit.
            if (savedScores.highscores.Count > maxScoreboardEntries)
            {
                savedScores.highscores.RemoveRange(maxScoreboardEntries, savedScores.highscores.Count - maxScoreboardEntries);
            }

            UpdateUI(hs_list);

            
        }

        private void UpdateUI(List<ScoreboardEntryData> hs_list)
        {
            foreach (Transform child in highscoresHolderTransform)
            {
                Destroy(child.gameObject);
            }

            for (int i = 0; i < maxScoreboardEntries; i ++)
            {
                Instantiate(scoreboardEntryObject, highscoresHolderTransform).GetComponent<ScoreboardEntryUI>().Initialise(hs_list[i]);
            }
        }

        private ScoreboardSaveData GetSavedScores()
        {
            if (!File.Exists(SavePath))
            {
                File.Create(SavePath).Dispose();
                return new ScoreboardSaveData();
            }

            using (StreamReader stream = new StreamReader(SavePath))
            {
                string json = stream.ReadToEnd();

                return JsonUtility.FromJson<ScoreboardSaveData>(json);
            }
        }

        
    private void SaveScores()
        {
            hs_list = hs_list.OrderByDescending(o => o.entryScore).ToList();



            for (int i = 0; i < maxScoreboardEntries; i++)
            {
                using (StreamWriter stream = new StreamWriter(SavePath, true))
                {
                    string json = JsonUtility.ToJson(hs_list[i], true);
                    stream.Write(json);
                }
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



    }
}