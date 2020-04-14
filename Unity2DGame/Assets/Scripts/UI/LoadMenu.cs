using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class LoadMenu : MonoBehaviour
{
    private long numberOfSaves;
    private string path;
    DirectoryInfo info;
    [SerializeField] private Button butonPreafb;
    [SerializeField] private Button [] buton;
    [SerializeField] private GameObject parinte;

    // Start is called before the first frame update
    void Start()
    {   
        path = Application.dataPath + "/Saves";
        info = new DirectoryInfo(path);
        numberOfSaves = SavesCount(info);
        SavesCount(info);
        createButtons(info);


    }


    
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


    public void createButtons(DirectoryInfo info)
    {
        int i = 0;
        FileInfo[] fis = info.GetFiles();
        foreach (FileInfo fi in fis)
        {
            if (!fi.Extension.Contains("meta"))
            {
                int index = fi.Name.IndexOf("_");
                string nume =  Path.GetFileNameWithoutExtension(fi.FullName).Substring(index + 1);
                buton[i] = Instantiate(butonPreafb);
                buton[i].transform.SetParent(parinte.transform);
                buton[i].GetComponentInChildren<Text>().text = nume;
                
            }

        }
    }
}
