using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    [SerializeField]  List<GameObject> Enemies = new List<GameObject>();
    int selection;
    [SerializeField] GameObject HoneyBear;
    public void SpawnEnemy()
    {
        //This will select which enemy to spawn from the list of enemies
        selection = Random.Range(0, Enemies.Count);

       GameObject spawnedEnemy = Instantiate(Enemies[selection], gameObject.transform.position, Quaternion.identity);

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
      
    public void spawnHoneyBear()
    {
        GameObject spawnedbear = Instantiate(HoneyBear, gameObject.transform.position, Quaternion.identity);

       
    }
}
