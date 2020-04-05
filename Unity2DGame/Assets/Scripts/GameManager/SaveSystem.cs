using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class SaveSystem
{
    private static readonly string saveFolder = Application.dataPath + "/Saves";
    public static void Init()
    {
        //Test daca exista folderul
        if (!Directory.Exists(saveFolder))
        {
            //Daca nu exista il cream
            Directory.CreateDirectory(saveFolder);
        }

    }

    public static void SaveAfterDeath(string saveString)
    {
        File.WriteAllText(saveFolder + "/saveScore_" + GameObject.FindGameObjectWithTag("Name").GetComponent<PlayerName>().getName() + ".txt", saveString);
    }

    public static void SaveAfterShop(string saveString)
    {
        File.WriteAllText(saveFolder + "/save_" + GameObject.FindGameObjectWithTag("Name").GetComponent<PlayerName>().getName() + ".txt", saveString);
    }

    public static string Load()
    {
        if (File.Exists(saveFolder + "/save_" + GameObject.FindGameObjectWithTag("Name").GetComponent<PlayerName>().getName() + ".txt"))
        {
            string saveString = File.ReadAllText(saveFolder + "/save_" + GameObject.FindGameObjectWithTag("Name").GetComponent<PlayerName>().getName() + ".txt");
            return saveString;
        }
        else
        {
            return null;
        }



    }

    public static string LoadScore()
    {

        if (File.Exists(saveFolder + "/saveScore_" + GameObject.FindGameObjectWithTag("Name").GetComponent<PlayerName>().getName() + ".txt"))
        {
            string saveString = File.ReadAllText(saveFolder + "/saveScore_" + GameObject.FindGameObjectWithTag("Name").GetComponent<PlayerName>().getName() + ".txt");
            return saveString;
        }
        else
        {
            return null;
        }
    }

}
