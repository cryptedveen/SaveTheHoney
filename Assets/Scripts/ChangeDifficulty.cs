using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChangeDifficulty : MonoBehaviour
{
   [SerializeField] Image easyImage, medImage, hardImage;


    private void Start()
    {
        colorChange("easy");
    }
    public void ChageGameDifficultyEasy()
    {
        GameMainData.diffLevel = GameMainData.GameDifficulty.Easy;
        print(GameMainData.diffLevel.ToString());

        colorChange("easy");
    }
    public void ChageGameDifficultyMedium()
    {
        GameMainData.diffLevel = GameMainData.GameDifficulty.Medium;
        print(GameMainData.diffLevel.ToString());

        colorChange("medium");
    }
    public void ChageGameDifficultyHard()
    {
        GameMainData.diffLevel = GameMainData.GameDifficulty.Hard;
        print(GameMainData.diffLevel.ToString());

        colorChange("hard");
    }


    void colorChange(string diffSett)
    {

        switch (diffSett)
        {
            case "easy":
                easyImage.color = Color.green;
                hardImage.color = new Color() { r = 1f, g = 1f, b = 1f, a = 0.1f };
                medImage.color = new Color() { r = 1f, g = 1f, b = 1f, a = 0.1f };
                break;
            case "hard":
                easyImage.color = new Color() { r = 1f, g = 1f, b = 1f, a = 0.1f };
                hardImage.color = Color.green;
                medImage.color = new Color() { r = 1f, g = 1f, b = 1f, a = 0.1f };
                break ;
            case "medium":
                easyImage.color = new Color() { r = 1f, g = 1f, b = 1f, a = 0.1f };
                hardImage.color = new Color() { r = 1f, g = 1f, b = 1f, a = 0.1f };
                medImage.color = Color.green; 
                break;
            default:
                easyImage.color = Color.green;
                hardImage.color = new Color() { r = 1f, g = 1f, b = 1f, a = 0.1f };
                medImage.color = new Color() { r = 1f, g = 1f, b = 1f, a = 0.1f };
                break;
        }

       
    }
}
