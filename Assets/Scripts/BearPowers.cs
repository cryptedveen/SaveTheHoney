using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BearPowers : MonoBehaviour
{


    public static BearPowers PowersInstance;

    [SerializeField] GameObject BArmGlove, FArmGlove, BLegShoe, FLegShoe, GodCrown, SlowSnail;

    public bool canSuperPunch, isGodModeTrue, canBlastEnemy, canSlowEnemy;

    GameObject[] allBees;

    private void Awake()
    {
        PowersInstance = this;
    }
    private void Start()
    {
        GodCrown.SetActive(false);
        SlowSnail.SetActive(false);
        DeactivateSuperPunch();

    }



    public void useGodMode()
    {
        GameManagerScript.gameManagerInstance.godModeBear = true;
        GodCrown.SetActive(true);

        StartCoroutine(GodModeIsOn());
    }

    IEnumerator GodModeIsOn()
    {
        yield return new WaitForSeconds(10.0f);

        GameManagerScript.gameManagerInstance.godModeBear = false;
        GodCrown.SetActive(false);
    }

    

    public void useBlastBomb()
    {
        allBees = GameObject.FindGameObjectsWithTag("Enemy");

        foreach(GameObject enemyBee in allBees)
        {
            if(enemyBee != null)
            {
                DOTween.Kill(enemyBee.transform);
                enemyBee.GetComponent<EnemyControl>().colEvent();
                Destroy(enemyBee);
            }
        }
    }

    public void useSlowEnemies()
    {
        GameManagerScript.gameManagerInstance.isEnemySlowed = true;
        SlowSnail.SetActive(true);

        StartCoroutine(SlowEnemiesIsOn());

    }


    IEnumerator SlowEnemiesIsOn()
    {
        yield return new WaitForSeconds(10.0f);

        GameManagerScript.gameManagerInstance.isEnemySlowed = false;
        SlowSnail.SetActive(false);
    }
  

    

    public void ActivateSuperPunch()
    {
        if (canSuperPunch)
        {
            BArmGlove.SetActive (true);
            FArmGlove.SetActive (true);
            FLegShoe.SetActive  (true);
            BLegShoe.SetActive  (true);

            GameManagerScript.gameManagerInstance.superpunchBear = true;


            StartCoroutine(SuperPunchIsOn());
        }
    }

    void DeactivateSuperPunch()
    {
        BArmGlove.SetActive(false);
        FArmGlove.SetActive(false);
        FLegShoe.SetActive(false);
        BLegShoe.SetActive(false);
    }


    IEnumerator SuperPunchIsOn()
    {
        yield return new WaitForSeconds(10.0f);
        
        GameManagerScript.gameManagerInstance.superpunchBear = false;
        DeactivateSuperPunch();
    }

    

    public void restoreHeroHealth()
    {
        GameManagerScript.gameManagerInstance.RestoreHerohealth();
    }
   
  

}
