using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player_ScoreHealth : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI ScoreText;
    [SerializeField] Slider HealthSlider;
    [SerializeField] GameObject Hero;
    [SerializeField] GameObject EndScreen;
    int score, life , maxLife;
    
    // Start is called before the first frame update
    void Start()
    {
        if(GameMainData.HeroScore != 0)
        {
            score = GameMainData.HeroScore;
        }
        else
        {
            score = 00;
        }
       
        life = 100;
        maxLife = 100;
        HealthSlider.value = life;
        ScoreText.text = score.ToString();
    }

    public void updateLife()
    {
        int randomvalue = Random.Range(3, 6);
        life -= randomvalue;
        HealthSlider.value = life;
        CheckHeroAlive();
    }

    public void updateScore()
    {
        score += 10;
        ScoreText.text = score.ToString();

        if (score%50 == 0)
        {
            GameManagerScript.gameManagerInstance.canSpawnPowerBear = true;
        }
        else 
        {
            GameManagerScript.gameManagerInstance.canSpawnPowerBear = false;
        }
    }

    void CheckHeroAlive()
    {
        if (life <= 0)
        {

            GameMainData.HeroScore = score;

            Destroy(Hero.gameObject);

            EndScreen.SetActive(true);

            GameManagerScript.gameManagerInstance.gameIsActive = false;

            Time.timeScale = 0;


            //print("Game Ended");
        }
    }

    public void AddHeroLife()
    {
        if(life < 100)
        {

            life = maxLife;
            
            HealthSlider.value = life;

        }
        
    }
}
