using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using UnityEngine.SceneManagement;




public class AdManagerScript : MonoBehaviour
{

    public GameControl gameControl;


    #if UNITY_ANDROID
            string BanneradUnitId   = "ca-app-pub-4265126177729958/4218950957";
            string RewardUnitID     = "ca-app-pub-4265126177729958~4592439756";

#elif UNITY_IPHONE
            string BanneradUnitId   = "ca-app-pub-4265126177729958/4218950957";
            string RewardUnitID     = "ca-app-pub-4265126177729958/3803371187"
#else
            string BanneradUnitId = "unexpected_platform";

#endif




    private BannerView bannerView;
    private RewardedAd rewardedAd;


    [SerializeField] float BannerAdWaitTime = 45f;



    private void Start()
    {
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(initStatus => { });

      


        CallRewardAd();

        StartCoroutine(RefreshBannerAd());
    }







    //Reward Ad Functions

    void CallRewardAd()
    {

        rewardedAd = new RewardedAd(RewardUnitID);

        rewardedAd.OnAdClosed += HandleRewardedAdClosed;

        AdRequest Rewardrequest = new AdRequest.Builder().Build();

        // Load the rewarded ad with the request.
        rewardedAd.LoadAd(Rewardrequest);

        
    }
  
    public void ShowRewardAd()
    {
        if (rewardedAd.IsLoaded())
        {
            rewardedAd.Show();
        }
        else
        {
            gameControl.ReloadCurrentLevel();
        }

    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        CallRewardAd();
        gameControl.ReloadCurrentLevel();
    }
















    //Banner Ad Functions Below

    private void ShowBannerAd()
    {
        RequestBanner();
        LoadBanner();
    }

    IEnumerator RefreshBannerAd()
    {

        ShowBannerAd();
        yield return new WaitForSeconds(BannerAdWaitTime);

        DestroyBanner();

        yield return new WaitForSeconds(3f);

        RestartAd();
    }

    void RestartAd()
    {
        StartCoroutine(RefreshBannerAd());
    }

    private void RequestBanner()
    {

       
        if (SceneManager.GetActiveScene().name == "MainMenuScene")
        {
            bannerView = new BannerView(BanneradUnitId, AdSize.Leaderboard, AdPosition.Bottom);

        }
        else
        {
            bannerView = new BannerView(BanneradUnitId, AdSize.Leaderboard, AdPosition.Top);
        }
       

    }

    private void LoadBanner()
    {
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        bannerView.LoadAd(request);
    }

    private void DestroyBanner()
    {
        bannerView.Destroy();
    }

    //All Above are Banner AD Functions

   

}
