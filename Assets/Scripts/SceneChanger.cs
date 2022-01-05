using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private void Start()
    {
        CellController.onButtonHit += ChangeScene;
    }
    
    public void LoadSceneXDApp() {  
        SceneManager.LoadScene("XD_App");  
    }

    // Abfrage fürs Caroussel
    public void ChangeScene(int index)
    {
        if (index == 1)
        {
            SceneManager.LoadScene("IlluminatiDoor_Puzzle");
        }

        if (index == 2)
        {
            SceneManager.LoadScene("Scenes/Frankenstein");
        }
    }
}
