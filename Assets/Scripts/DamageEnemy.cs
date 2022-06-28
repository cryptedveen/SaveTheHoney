using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class DamageEnemy : MonoBehaviour
{
    List<GameObject> enemiesColliding = new List<GameObject>();
    //[SerializeField] BoxCollider2D Hand1, Hand2, Leg1, Leg2;
    //bool isColliding = false;

    [SerializeField, Tooltip("Time Before Colliders Reactivate")] float waitTime = 0.3f;

    Collider2D[] results = new Collider2D[] { };
    GameObject currentEnemy;

    [SerializeField] GameManagerScript main;


    private void OnTriggerEnter2D(Collider2D enemyColliders)
    {
        if(main.currentlyAttacking == false)
        {
            if (enemyColliders.gameObject.tag == "Enemy")
            {
                main.currentlyAttacking = true;
                currentEnemy = enemyColliders.gameObject;

            
                DestroyCurrentEnemy(currentEnemy);
            }
        }
    }

    void  DestroyCurrentEnemy(GameObject currentEnemy)
    {
        DOTween.Kill(currentEnemy.transform);
        currentEnemy.GetComponent<EnemyControl>().colEvent();
        Destroy(currentEnemy);

      

      StartCoroutine("reEnablecollider");
    }

IEnumerator reEnablecollider()
    {

      yield return new WaitForSeconds(waitTime);
      main.currentlyAttacking = false;
      
    }

}


  //IMPORTANT NOTE  
/*
 

Collision Problem : 
 The problem now is that the event is called for everytime the collider touches a new enemy collider.
So the secong overlapping enemy is considered new and the event is called for that object.


The Solution I did was to create a bool value in main Game control script.
Set that bool to true when collision with an object starts so that the bool will no more allow other collisions.
and then set it to false with a time delay so that the bool will now allow collision to happen;
 
 
 */