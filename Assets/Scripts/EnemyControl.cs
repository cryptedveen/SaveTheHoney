using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyControl : MonoBehaviour
{

    
    GameObject target;
    BoxCollider2D targetBoxCollider;
    CapsuleCollider2D targetCapsuleCollider;
    [SerializeField] Animator animator;
    [SerializeField, Tooltip("Lower is Faster")] float EnemySpeed = 10f; 
    GameObject gameManagerScript;
    [SerializeField] GameObject VFX_Prefab;


    BoxCollider2D[] EnemyColliders;

    public bool isFlyingTrue;

    GameManagerScript mainscript = GameManagerScript.gameManagerInstance;
    void Start()
    {
        //Find the Hero Object with name
        target = GameObject.Find("HeroParent");
        gameManagerScript = GameObject.Find("GAMEMANAGER");
        


        float randomvalue = Random.Range(2.5f, 6f);
        EnemySpeed = randomvalue;

        float distance = target.transform.position.x - gameObject.transform.position.x;

        //The below function turns the character based on spawn position
        FlipEnemy(distance);

        //Binding Target Colliders in the target objects
        targetBoxCollider = target.GetComponent<BoxCollider2D>();
        targetCapsuleCollider = target.GetComponent<CapsuleCollider2D>();

        //Movement Code
        if (gameObject)
        {
            if (GameManagerScript.gameManagerInstance.isEnemySlowed)
            {
                gameObject.transform.DOMoveX(target.transform.position.x, (EnemySpeed/2));
            }
            else
            {
                gameObject.transform.DOMoveX(target.transform.position.x, EnemySpeed);
            }
           
        }
       

    }




    void FlipEnemy(float distance)
    {
        if (distance < 0)
        {
            gameObject.GetComponent<FlipCharacter>().FlipLeft();
        }
        else
        {
            gameObject.GetComponent<FlipCharacter>().FlipRight();
        }
    }


    //Trigger Function for attacking
    private void OnTriggerEnter2D(Collider2D hitCollider)
    {
        if (hitCollider == targetBoxCollider)
        {

            

            //Attack Code should be done here
            DOTween.Kill(gameObject.transform);


           // gameManagerScript.GetComponent<GameManagerScript>().increaseTime();


            //gameManagerScript.GetComponent<Player_ScoreHealth>().updateLife();
            if (isFlyingTrue)
            {
                animator.Play("Base Layer.EnemyFly_Attack", 0, 0f);
            }
            else
            {
                animator.Play("Base Layer.EnemyStand_Attack", 0, 0f);
            }

        }


        //Destroy Code should be here
      /*
        
        if (hitCollider.gameObject.tag == "GetDamage")
        {
            List<Collider2D> Cols = new List<Collider2D>();
            gameObject.GetComponent<BoxCollider2D>().OverlapCollider(new ContactFilter2D(),Cols);

          

            Destroy (gameObject);

            DOTween.Kill(gameObject.transform);
           
           
            
            
        }
       */

    }

    private void OnDestroy()
    {
       // mainscript.currentlyAttacking = false;
    }
    public void colEvent()
    {
        Instantiate(VFX_Prefab, gameObject.transform.position, Quaternion.identity);
    }

   
}
