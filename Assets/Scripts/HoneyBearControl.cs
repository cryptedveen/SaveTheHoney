using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class HoneyBearControl : MonoBehaviour
{

    public enum Beartype
    {
        superPunch,
        slowEnemies,
        blastEnemies,
        godModeBear,
        restoreLife
    }


    GameObject target;
    BoxCollider2D targetBoxCollider;
   

    [SerializeField] Beartype typeOfBear;
   
    public bool isPowerBear;

    [SerializeField] float BearSpeed = 10f;
    GameObject gameManagerScriptBear;

    void Start()
    {
        //Find the Hero Object with name
        target = GameObject.Find("TargetPoint");
        gameManagerScriptBear = GameObject.Find("GAMEMANAGER");

        float distance = target.transform.position.x - gameObject.transform.position.x;

        //The below function turns the character based on spawn position
        FlipBear(distance);

        //Binding Target Colliders in the target objects
        targetBoxCollider = target.GetComponent<BoxCollider2D>();
        //targetCapsuleCollider = target.GetComponent<CapsuleCollider2D>();

        //Movement Code

        gameObject.transform.DOMoveX(target.transform.position.x, BearSpeed);

    }
    void FlipBear(float distance)
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

    private void OnTriggerEnter2D(Collider2D hitCollider)
    {

        if (hitCollider == targetBoxCollider)
        {
            DOTween.Kill(gameObject.transform);
            Destroy(gameObject);

            gameManagerScriptBear.GetComponent<Player_ScoreHealth>().updateScore();


            if (isPowerBear)
            {

                switch (typeOfBear)
                {
                    case Beartype.superPunch:
                        BearPowers.PowersInstance.canSuperPunch = true;
                        BearPowers.PowersInstance.ActivateSuperPunch();
                        break;

                    case Beartype.godModeBear:
                        BearPowers.PowersInstance.useGodMode();
                        break;

                    case Beartype.blastEnemies:
                        BearPowers.PowersInstance.useBlastBomb();
                        break;

                    case Beartype.slowEnemies:
                        BearPowers.PowersInstance.useSlowEnemies();
                        break;

                    case Beartype.restoreLife:
                        BearPowers.PowersInstance.restoreHeroHealth();
                        break;
                    
                    default:
                        print("Error No Power Detected");
                        break;
                }

               

                print("PowerActivated");
            }



        }

        


    }

}
