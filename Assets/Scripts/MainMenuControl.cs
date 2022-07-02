using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControl : MonoBehaviour
{

    public static MainMenuControl Instance;

    [SerializeField] GameObject MainmenuCanvas, E1,E2,E3, Loader;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        if (MainmenuCanvas.activeInHierarchy) { MainmenuCanvas.SetActive(true); }

        // Hero.GetComponent<Animator>().Play("Base Layer.Idle", 0, 0f);

        E1.GetComponent<Animator>().Play("Base Layer.EnemyStand_Idle", 0, 0.2f);
        E2.GetComponent<Animator>().Play("Base Layer.EnemyStand_Idle", 0, 0.5f);
        E3.GetComponent<Animator>().Play("Base Layer.EnemyStand_Idle", 0, 0.7f);

    }

   
    public void PlayButtonClicked()
    {
        Loader.SetActive(true);
        Loader.GetComponent<Animator>().Play("Base Layer.UI_LoadingStart", 0, 0f);
    }
  
  

}
