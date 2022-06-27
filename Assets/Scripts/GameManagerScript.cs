using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    [SerializeField] GameObject CanvasObject;
    [SerializeField] float timegap = 2f;
    bool gameIsActive = true;


    public bool currentlyAttacking = false;

    static public GameManagerScript gameManagerInstance;

   

    [SerializeField, Tooltip("List of Spawner")] List<SpawnScript> SpawnScripts = new List<SpawnScript>();
    [SerializeField, Tooltip("Bears")] GameObject HoneyBears;

    int selectSpawner, selectHoneybear;

    private void Awake()
    {
        gameManagerInstance = this;
    }

    void Start()
    {
        if (!CanvasObject.activeInHierarchy)
        {
            CanvasObject.SetActive(true);
        }

        StartCoroutine("ContinousAttackScript");
        StartCoroutine("ContinousHoneyBearScript");
       // InvokeRepeating("SpawnerActivate", 2f, timegap);
    }

    IEnumerator ContinousAttackScript()
    {
        while (gameIsActive)
        {
            SpawnerActivate();
            //spawnBear();

            yield return new WaitForSeconds(timegap);
        }
       
    }

    IEnumerator ContinousHoneyBearScript()
    {
        while (gameIsActive)
        {
            spawnBear();

            int randomwaitvalue = Random.Range(5, 11);
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
        SpawnScripts[selectSpawner].spawnHoneyBear();
    }

    public void increaseTime()
    {
        if (Time.time >= 30f)
        {
            timegap = 1f;
         //   print(timegap);
        }
        if (Time.time >= 60f)
        {
            timegap = 0.8f;
         //   print(timegap);

        }
        if (Time.time >= 120f)
        {
            timegap = 0.7f;
         //   print(timegap);

        }
        if (Time.time >= 240f)
        {
            timegap = 0.6f;
         //   print(timegap);

        }
        if (Time.time >= 360f)
        {
            timegap = 0.5f;
          //  print(timegap);

        }
    }

    
  
}




