using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    [SerializeField] GameObject CanvasObject;
    public float timegap = 2f;
    public bool gameIsActive = true;

    public bool isEnemySlowed = false;


    public bool currentlyAttacking = false;

    public bool canSpawnPowerBear, godModeBear, superpunchBear;

    static public GameManagerScript gameManagerInstance;

    float StartTime, GameTime;

    [SerializeField, Tooltip("List of Spawner")] List<SpawnScript> SpawnScripts = new List<SpawnScript>();
    [SerializeField, Tooltip("Bears")] GameObject HoneyBears;

    int selectSpawnerEnemy, selectSpawnerBear;



    private void Awake()
    {
        gameManagerInstance = this;
    }

    void Start()
    {

        GameMainData.MainHero = GameObject.Find("HeroParent");
        GameMainData.MainPlayerTransform = GameMainData.MainHero.gameObject.transform;

        StartTime = Time.time;

        if (!CanvasObject.activeInHierarchy)
        {
            CanvasObject.SetActive(true);
        }

      
      
       
    }

    public void GameBegins()
    {
        gameIsActive = true;

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
        selectSpawnerEnemy = Random.Range(0, SpawnScripts.Count);

        //This will call the Spawn Enemy function of selected spawner.
        SpawnScripts[selectSpawnerEnemy].SpawnEnemy();

    }


    public void spawnBear()
    {
        //This will select which spawner to use
        selectSpawnerBear = Random.Range(0, SpawnScripts.Count);

        

        //This will call the Spawn Enemy function of selected spawner.
        SpawnScripts[selectSpawnerBear].spawnHoneyBear(canSpawnPowerBear);


    }

    public void RestoreHerohealth()
    {
        gameObject.GetComponentInChildren<Player_ScoreHealth>().AddHeroLife();
    }

}




