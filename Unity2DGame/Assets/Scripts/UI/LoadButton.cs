using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadButton : MonoBehaviour
{
    private void Start()
    {
        
    }



    public void setPlayerName()
    {
        GameObject.FindGameObjectWithTag("Name").GetComponent<PlayerName>().setName(gameObject.GetComponentInChildren<Text>().text);
    }


    public void StartGame()
    {
        SceneManager.LoadScene("SkillTree");
    }


}
