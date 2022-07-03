using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using UnityEngine.SceneManagement;


public class AdManagerScript : MonoBehaviour
{

    private BannerView bannerView;
    [SerializeField] float BannerAdWaitTime = 60f;

    private void Start()
    {
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(initStatus => { });


        StartCoroutine(RefreshBannerAd());
    }


  
    

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

        yield return new WaitForSeconds(5f);

        RestartAd();
    }

    void RestartAd()
    {
        StartCoroutine(RefreshBannerAd());
    }

    private void RequestBanner()
    {

        #if UNITY_ANDROID
        string adUnitId = "ca-app-pub-4265126177729958/4218950957";


#elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-4265126177729958/4218950957";


#else
            string adUnitId = "unexpected_platform";

#endif
        if (SceneManager.GetActiveScene().name == "MainMenuScene")
        {
            bannerView = new BannerView(adUnitId, AdSize.Leaderboard, AdPosition.Bottom);

        }
        else
        {
            bannerView = new BannerView(adUnitId, AdSize.Leaderboard, AdPosition.Top);
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
