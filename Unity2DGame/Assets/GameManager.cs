
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    bool gameEnded = false;
    public void EndGame()
    {
        if(gameEnded == false)
        {
            gameEnded = true;
            Debug.Log("GAME OVER");
            SceneManager.LoadScene("GameOver");
        }
    }
}
