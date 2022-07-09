using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicONOFF : MonoBehaviour
{

    public GameObject music;

    [SerializeField] Animator MusicUIanimator;
    bool isMusicOn = true, isSFXOn = true;


    private void Start()
    {
        music = GameObject.Find("MUSICMANAGER");
    }


    public void SFXSlider()
    {
        if (isSFXOn)
        {
            stopSFX();
        }
        else
        {
            startSFX();
        }
    }
    public void MusicSliderOnOff()
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


    public void stopSFX()
    {
        MusicUIanimator.Play("Base Layer.UISettingsSliderOFF", 0, 0);
        GameMainData.SFXActive = false;
        isSFXOn = false;
    }

    public void startSFX()
    {
        MusicUIanimator.Play("Base Layer.UISettingsSliderON", 0, 0);
        GameMainData.SFXActive = true; 
        isSFXOn = true;
    }
}
