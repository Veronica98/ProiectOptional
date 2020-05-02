using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuUi;
    [SerializeField] private bool isPaused;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }
        
        if(isPaused)
        {
            ActivateMenu();
        }
        else
        {
            DeactivateMenu();
        }
    }

    void ActivateMenu()
    {
        AudioListener.pause = true;
        Time.timeScale = 0;
        pauseMenuUi.SetActive(true);
    }

    public void DeactivateMenu()
    {
        AudioListener.pause = false;
        Time.timeScale = 1;
        pauseMenuUi.SetActive(false);
        isPaused = false;
    }


    public void NewGame()
    {
        DestroyObjectsNewGame();
        SceneManager.LoadScene(1);
    }

    public void QuitToMyMenu()
    {
        DestroyObjectsQuitToMyMenu();
        ReLoad();
        
    }

    private void DestroyObjectsNewGame()
    {
        
        Destroy(GameObject.FindGameObjectWithTag("MainCamera"));
        Destroy(GameObject.FindGameObjectWithTag("Player"));
    }

    private void DestroyObjectsQuitToMyMenu()
    {
        Destroy(GameObject.FindGameObjectWithTag("MainCamera"));
        Destroy(GameObject.FindGameObjectWithTag("Player"));
        Destroy(GameObject.FindGameObjectWithTag("Name"));
    }

    private void ReLoad()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
