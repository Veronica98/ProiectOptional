using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitScript : MonoBehaviour
{
    public void ExitApp() {
        Debug.Log("QUIT SUCCESSFULLY");
        Application.Quit();
    }
}
