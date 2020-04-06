using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerName : MonoBehaviour
{
    private string name;

    //Singleton
    public static PlayerName Instance { get; private set; }


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }




    }

    public void storeName()
    {

        name = GameObject.FindGameObjectWithTag("NameInput").GetComponentInChildren<Text>().text;

    }

    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }


    public string getName()
    {
        return name;
    }

    public void setName(string newName)
    {
        name = newName;
    }
}
