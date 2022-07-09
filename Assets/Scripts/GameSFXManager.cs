using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSFXManager : MonoBehaviour
{
    static public GameSFXManager SFXinstance;
    public AudioClip explosionSFX, powerupSFX;
    public List<AudioClip> hitSFX;

    
    private void Awake()
    {
        SFXinstance = this;
    
    }

    public void EnemyDie()
    {
        if (GameMainData.SFXActive)
        {
            if (GameManagerScript.gameManagerInstance.superpunchBear)
            {
                gameObject.GetComponent<AudioSource>().PlayOneShot(hitSFX[0]);
            }
            else
            {
                int selection = Random.Range(1, hitSFX.Count);
                gameObject.GetComponent<AudioSource>().PlayOneShot(hitSFX[selection]);
            }
        }

       
       
    }
    public void PowerUpSFX()
    {
        if (GameMainData.SFXActive)
        {
            gameObject.GetComponent<AudioSource>().PlayOneShot(powerupSFX);
        }
    }
    public void BombSFX()
    {
        if (GameMainData.SFXActive)
        {
            gameObject.GetComponent<AudioSource>().PlayOneShot(explosionSFX);
        }
    }




}
