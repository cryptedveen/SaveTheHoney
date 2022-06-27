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
    int score, life;

    // Start is called before the first frame update
    void Start()
    {
        score = 00;
        life = 100;
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
        score += 15;
        ScoreText.text = score.ToString();
    }

    void CheckHeroAlive()
    {
        if (life <= 0)
        {

            Destroy(Hero.gameObject);
            Time.timeScale = 0;


            //print("Game Ended");
        }
    }
}
