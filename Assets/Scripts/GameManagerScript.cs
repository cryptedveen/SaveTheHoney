using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    [SerializeField] GameObject CanvasObject;
    [SerializeField] float timegap = 2f;
    bool gameIsActive = true;




    public bool currentlyAttacking = false;

    public bool canSpawnPowerBear, godMode;

    static public GameManagerScript gameManagerInstance;

    float StartTime, GameTime;

    [SerializeField, Tooltip("List of Spawner")] List<SpawnScript> SpawnScripts = new List<SpawnScript>();
    [SerializeField, Tooltip("Bears")] GameObject HoneyBears;

    int selectSpawner, selectHoneybear;

    private void Awake()
    {
        gameManagerInstance = this;
    }

    void Start()
    {

        StartTime = Time.time;

        if (!CanvasObject.activeInHierarchy)
        {
            CanvasObject.SetActive(true);
        }

        StartCoroutine("ContinousAttackScript");
        StartCoroutine("ContinousHoneyBearScript");
       
    }

    IEnumerator ContinousAttackScript()
    {
        while (gameIsActive)
        {
            SpawnerActivate();
            

            yield return new WaitForSeconds(timegap);
        }
       
    }

    IEnumerator ContinousHoneyBearScript()
    {
        while (gameIsActive)
        {
            spawnBear();

            int randomwaitvalue = Random.Range(4, 6);
            yield return new WaitForSeconds(randomwaitvalue);
        }

    }



    public void SpawnerActivate()
    {
        //This will select which spawner to use
        selectSpawner = Random.Range(0, SpawnScripts.Count);

        //This will call the Spawn Enemy function of selected spawner.
        SpawnScripts[selectSpawner].SpawnEnemy();

    }


    public void spawnBear()
    {
        selectSpawner = Random.Range(0, SpawnScripts.Count);

        

        //This will call the Spawn Enemy function of selected spawner.
        SpawnScripts[selectSpawner].spawnHoneyBear(canSpawnPowerBear);


    }

   



    public void increaseTime()
    {
        GameTime = Time.time;

        if (GameTime >= 60f)
        {
            timegap = 1f;
         //   print(timegap);
        }
        if (GameTime >= 120f)
        {
            timegap = 0.95f;
         //   print(timegap);

        }
        if (GameTime >= 180f)
        {
            timegap = 0.8f;
         //   print(timegap);

        }
        if (GameTime >= 360f)
        {
            timegap = 0.65f;
         //   print(timegap);

        }
        if (GameTime >= 480f)
        {
            timegap = 0.6f;
          //  print(timegap);

        }
    }

    
  
}




