using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicONOFF : MonoBehaviour
{

    [SerializeField] Animator MusicUIanimator;
    bool isMusicOn = true;
  public void SliderOnOff()
    {
        if (isMusicOn)
        {
            MusicUIanimator.Play("Base Layer.UISettingsSliderOFF", 0, 0);
            isMusicOn = false;
        }
        else
        {
            MusicUIanimator.Play("Base Layer.UISettingsSliderON", 0 ,0);
            isMusicOn = true;
        }
       
    }
}
