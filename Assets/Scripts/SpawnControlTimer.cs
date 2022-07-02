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



    public void increaseTime()
    {
        currentTime = Time.time;

        gameTime = currentTime - startTime;

        print(gameTime);    

        if (gameTime >= 60f)
        {
           GameManagerScript.gameManagerInstance.timegap = 1.8f;
            //   print(timegap);
        }
        if (gameTime >= 180f)
        {
            GameManagerScript.gameManagerInstance.timegap = 1.75f;
            //   print(timegap);
      
        }
        if (gameTime >= 360f)
        {
            GameManagerScript.gameManagerInstance.timegap = 1.65f;
            //   print(timegap);
      
        }
        if (gameTime >= 480f)
        {
            GameManagerScript.gameManagerInstance.timegap = 1.45f;
            //   print(timegap);
      
        }
        if (gameTime >= 600f)
        {
            GameManagerScript.gameManagerInstance.timegap = 1.0f;
            //  print(timegap);
      
        }
    }

}
