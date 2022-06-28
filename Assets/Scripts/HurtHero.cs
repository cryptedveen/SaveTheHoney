using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtHero : MonoBehaviour
{
    CapsuleCollider2D herocollider;
    [SerializeField] Player_ScoreHealth playerScript;
    private void Start()
    {
        herocollider = gameObject.GetComponent<CapsuleCollider2D>();
    }
  

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "EnemyWeapon")
        {
            //  print(collision.gameObject.name);
            // print("Collision With hero");

            if(GameManagerScript.gameManagerInstance.godMode == false)
            {
                playerScript.updateLife();
            }  
            
            //gameObject.SetActive(false);
        }
    }

}
