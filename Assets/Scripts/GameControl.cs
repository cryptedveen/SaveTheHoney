using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameControl : MonoBehaviour
{
    bool gameIsPaused = false;
    [SerializeField] GameObject SettingScreen, LoaderScreen;


    private void Start()
    {
        StartGameFunctions();
    }

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


    public void StartGameFunctions()
    {
        LoaderScreen.SetActive(true);
        LoaderScreen.GetComponent<Animator>().Play("Base Layer.UI_LoadingEnd", 0, 0.0f);
    }


    public void ReloadCurrentLevel()
    {
        
       // SceneManager.UnloadScene("GameScene");
        SceneManager.LoadScene("GameScene");
        Time.timeScale = 1;
    }
}
