using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDifficulty : MonoBehaviour
{
  public void ChageGameDifficultyEasy()
    {
        GameMainData.diffLevel = GameMainData.GameDifficulty.Easy;
        print(GameMainData.diffLevel.ToString());
    }
    public void ChageGameDifficultyMedium()
    {
        GameMainData.diffLevel = GameMainData.GameDifficulty.Medium;
        print(GameMainData.diffLevel.ToString());
    }
    public void ChageGameDifficultyHard()
    {
        GameMainData.diffLevel = GameMainData.GameDifficulty.Hard;
        print(GameMainData.diffLevel.ToString());
    }
}
