using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicONOFF : MonoBehaviour
{

    public GameObject music;

    [SerializeField] Animator MusicUIanimator;
    bool isMusicOn = true;


    private void Start()
    {
        music = GameObject.Find("MUSICMANAGER");
    }
    public void SliderOnOff()
    {
        if (isMusicOn)
        {
            MusicUIanimator.Play("Base Layer.UISettingsSliderOFF", 0, 0);
            isMusicOn = false;
            stopMusic();
        }
        else
        {
            MusicUIanimator.Play("Base Layer.UISettingsSliderON", 0 ,0);
            isMusicOn = true;
            startMusic();   
        }
       
    }

    public void stopMusic()
    {
        music.GetComponent<AudioSource>().Stop();
    }

    public void startMusic()
    {
        music.GetComponent<AudioSource>().Play();
    }
}
