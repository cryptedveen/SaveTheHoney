using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadLevel_LoaderScript : MonoBehaviour
{
    public void GoToMainLevel(string LevelName)
    {
        SceneManager.LoadScene(LevelName);
    }
   
    public void MainLevelStart()
    {
        GameManagerScript.gameManagerInstance.GameBegins();
    }

}
