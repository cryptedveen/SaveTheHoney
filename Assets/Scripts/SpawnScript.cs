using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    [SerializeField]  List<GameObject> Enemies = new List<GameObject>();
    int enemySelection, powerbearSelection;
    [SerializeField] GameObject HoneyBear;
    [SerializeField] List<GameObject> PowerBears = new List<GameObject>();


    public void SpawnEnemy()
    {
       //This will select which enemy to spawn from the list of enemies
       enemySelection = Random.Range(0, Enemies.Count);

       SpawnControlTimer.timerInstance.increaseTimeEasy();

       GameObject spawnedEnemy = Instantiate(Enemies[enemySelection], gameObject.transform.position, Quaternion.identity);

        if(gameObject.name == "LeftSpawnerTop" || gameObject.name == "RightSpawnerTop")
        {
            spawnedEnemy.GetComponentInChildren<Animator>().SetBool("isFlying", true);
            spawnedEnemy.GetComponent<EnemyControl>().isFlyingTrue = true;
            spawnedEnemy.GetComponent<BoxCollider2D>().size = new Vector2(2.5f, 0.9f);
        }
        else
        {
            spawnedEnemy.GetComponentInChildren<Animator>().SetBool("isStanding", true);
            spawnedEnemy.GetComponent<EnemyControl>().isFlyingTrue = false;
            spawnedEnemy.GetComponent<BoxCollider2D>().size = new Vector2(1f, 1.5f);
            spawnedEnemy.GetComponent<BoxCollider2D>().offset = new Vector2(0f, -0.3f);
        }
    }
      
    public void spawnHoneyBear(bool canSpawnPower)
    {

        if (canSpawnPower)
        {
            powerbearSelection = Random.Range(0, PowerBears.Count);
            Instantiate(PowerBears[powerbearSelection], gameObject.transform.position, Quaternion.identity);

            GameManagerScript.gameManagerInstance.canSpawnPowerBear = false;
        }
        else
        {

            // While the normal power bear will spawn every 50 points, This will also call a power bear randomly with a chance of 1 in 10. 
            int powerRandomChecker;
            
            powerRandomChecker = (int)Random.Range(0, 10);

            if(powerRandomChecker == 1)
            {
                Instantiate(PowerBears[powerbearSelection], gameObject.transform.position, Quaternion.identity);
                //canSpawnPower = false;
            }
            else
            {
                Instantiate(HoneyBear, gameObject.transform.position, Quaternion.identity);
                //canSpawnPower = false;
            }

           
        }

           




    }
}
