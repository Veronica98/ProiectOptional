using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{


    private string theName;
    //public GameObject inputField;



    public void storeName()
    {
        //theName = inputField.GetComponent<Text>().text;
        theName = GameObject.FindGameObjectWithTag("NameInput").GetComponentInChildren<Text>().text;
        Debug.Log(theName);
    }




}
