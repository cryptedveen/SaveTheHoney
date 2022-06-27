using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    bool gameIsPaused = false;
    [SerializeField] GameObject SettingScreen;
    public void PauseAndResumeGame()
    {
        
        if(gameIsPaused == true)
        {
            gameIsPaused = false;
            SettingScreen.SetActive(false);
           
            Time.timeScale = 1;
        }
        else
        {
            gameIsPaused = true;
            SettingScreen.SetActive(true);
            
            Time.timeScale = 0;
        }

    }
  
}
