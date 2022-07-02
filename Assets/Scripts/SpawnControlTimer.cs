using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnControlTimer : MonoBehaviour
{
   
    float startTime, gameTime, currentTime;

    public static SpawnControlTimer timerInstance;

    private void Awake()
    {
        timerInstance = this;
    }
    void Start()
    {
        startTime = Time.time;
    }



    public void increaseTimeEasy()
    {
        if(GameMainData.diffLevel == GameMainData.GameDifficulty.Easy)
        {
            easyTimer();
        }

        if (GameMainData.diffLevel == GameMainData.GameDifficulty.Medium)
        {
            mediumTimer();
        }

        if (GameMainData.diffLevel == GameMainData.GameDifficulty.Hard)
        {
            hardTimer();
        }

    }





    //Timers Code. Change time gap below
    void easyTimer()
    {
        currentTime = Time.time;

        gameTime = currentTime - startTime;

        print(gameTime);

        if (gameTime >= 30f)
        {
            GameManagerScript.gameManagerInstance.timegap = 2.5f;
            //   print(timegap);
        }
        if (gameTime >= 180f)
        {
            GameManagerScript.gameManagerInstance.timegap = 2f;
            //   print(timegap);

        }
        if (gameTime >= 360f)
        {
            GameManagerScript.gameManagerInstance.timegap = 1.75f;
            //   print(timegap);

        }
        if (gameTime >= 480f)
        {
            GameManagerScript.gameManagerInstance.timegap = 1.5f;
            //   print(timegap);

        }
        if (gameTime >= 600f)
        {
            GameManagerScript.gameManagerInstance.timegap = 1.25f;
            //  print(timegap);

        }
    }


    void mediumTimer()
    {
        currentTime = Time.time;

        gameTime = currentTime - startTime;

        print(gameTime);

        if (gameTime >= 30f)
        {
            GameManagerScript.gameManagerInstance.timegap = 2f;
            //   print(timegap);
        }
        if (gameTime >= 180f)
        {
            GameManagerScript.gameManagerInstance.timegap = 1.7f;
            //   print(timegap);

        }
        if (gameTime >= 360f)
        {
            GameManagerScript.gameManagerInstance.timegap = 1.5f;
            //   print(timegap);

        }
        if (gameTime >= 480f)
        {
            GameManagerScript.gameManagerInstance.timegap = 1.2f;
            //   print(timegap);

        }
        if (gameTime >= 600f)
        {
            GameManagerScript.gameManagerInstance.timegap = 1f;
            //  print(timegap);

        }
    }

    void hardTimer()
    {
        currentTime = Time.time;

        gameTime = currentTime - startTime;

        print(gameTime);

        if (gameTime >= 30f)
        {
            GameManagerScript.gameManagerInstance.timegap = 2f;
            //   print(timegap);
        }
        if (gameTime >= 180f)
        {
            GameManagerScript.gameManagerInstance.timegap = 1.5f;
            //   print(timegap);

        }
        if (gameTime >= 360f)
        {
            GameManagerScript.gameManagerInstance.timegap = 1.25f;
            //   print(timegap);

        }
        if (gameTime >= 480f)
        {
            GameManagerScript.gameManagerInstance.timegap = 1f;
            //   print(timegap);

        }
        if (gameTime >= 600f)
        {
            GameManagerScript.gameManagerInstance.timegap = 0.8f;
            //  print(timegap);

        }
    }
}
