using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeToLoadScene : MonoBehaviour
{
    public void changeToLoadScene()
    {
        SceneManager.LoadScene("LoadScene");
    }
}
