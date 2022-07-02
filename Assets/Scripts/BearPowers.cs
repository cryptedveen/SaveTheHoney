using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearPowers : MonoBehaviour
{


    public static BearPowers PowersInstance;

    [SerializeField] GameObject BArmGlove, FArmGlove, BLegShoe, FLegShoe;

    public bool canSuperPunch;



    private void Awake()
    {
        PowersInstance = this;
    }
    private void Start()
    {
        DeactivateSuperPunch();
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

}
