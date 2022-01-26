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
    public void LoadSceneTouristMainApp() {  
        SceneManager.LoadScene("Tourist_App_Main");  
    }

    // Abfrage fürs Caroussel
    public void ChangeScene(int index)
    {
        Debug.Log("Hitty");
        if (index == 1)
        {
            SceneManager.LoadScene("Stop_IlluminatiDoor_Puzzle");
        }

        if (index == 3)
        {
            SceneManager.LoadScene("Stop_Frankenstein");
        }

        if (index == 4)
        {
            SceneManager.LoadScene("Stop_HorsedrawnTram");
        }
    }
    
    public void LoadSceneGuideStart() {  
        SceneManager.LoadScene("Guide_Start");  
    }
    
    public void LoadSceneGuideMain() {  
        SceneManager.LoadScene("Guide_App_Main");  
    }
    
}
