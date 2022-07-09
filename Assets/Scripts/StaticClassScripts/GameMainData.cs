using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class GameMainData
{
    public enum GameDifficulty
    {
        Easy,
        Medium,
        Hard
    }
    static public GameDifficulty diffLevel = GameDifficulty.Easy;

    static public bool SFXActive = true;
    static public bool MusicActive = true;

    static public GameObject MainHero;
    static public Transform MainPlayerTransform;
    static public int HeroScore = 0;

    

}
