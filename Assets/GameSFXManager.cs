using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSFXManager : MonoBehaviour
{
    static public GameSFXManager SFXinstance;
    public AudioClip hitSFX;

    private void Awake()
    {
        SFXinstance = this;
    
    }

    public void EnemyDie()
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(hitSFX);
    }


}
