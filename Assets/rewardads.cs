using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;
using UnityEngine.SceneManagement;

public class rewardads : MonoBehaviour
{
    private RewardedAd rewardedAd;
    private string adUnitId;

    [Obsolete]
    public void Start()
    {
        MobileAds.Initialize(initStatus => { });

        RequestRewardedVideo();

        
    }
    [Obsolete]
    public void RequestRewardedVideo()
    {
        if (this.rewardedAd != null)
        {
            this.rewardedAd.Destroy();

        }

        Debug.Log("reklam yüklüyo");
        string adUnitId;
        #if UNITY_ANDROID
            adUnitId = "ca-app-pub-2763655103678935/4806279558";
            //adUnitId = "ca-app-pub-3940256099942544/5354046379";

#elif UNITY_IPHONE
            adUnitId = "ca-app-pub-3940256099942544/1712485313";
#else
            adUnitId = "unexpected_platform";
#endif

        this.rewardedAd = new RewardedAd(adUnitId);
        // Called when an ad request has successfully loaded.
        this.rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
        // Called when an ad request failed to load.
        this.rewardedAd.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
        // Called when an ad is shown.
        this.rewardedAd.OnAdOpening += HandleRewardedAdOpening;
        // Called when an ad request failed to show.
        this.rewardedAd.OnAdFailedToShow += HandleRewardedAdFailedToShow;
        // Called when the user should be rewarded for interacting with the ad.
        this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        // Called when the ad is closed.
        this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        this.rewardedAd.LoadAd(request);
        if (this.rewardedAd.IsLoaded())
        {
            Debug.Log("loaded");
        }

        else { Debug.Log("not loaded"); }
    }

    public void HandleRewardedAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdLoaded event received");
    }

    public void HandleRewardedAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
    }

    public void HandleRewardedAdOpening(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdOpening event received");
    }

    public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToShow event received with message: "
                             + args.Message);
    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdClosed event received");
    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
        Debug.Log("reward");
    }


    #region Ads Settings

    // no ads sat�n alma kontrol� yap�lacak. Reklams�z izleme al�nd�ysa reklam izleme fonksiyonuna gidilmeyecek

    [Obsolete]
    public void WatchRebornAd()
    {
        WatchAd();
    }

    [Obsolete]
    void WatchAd()
    {
        //if (this.rewardedAd != null)
        //{
        //    this.rewardedAd.Destroy();

        //}

        if (this.rewardedAd.IsLoaded())
        {
            this.rewardedAd.Show();
        }

        else { Debug.Log("not loaded"); }
               
        
            
        
        this.rewardedAd.OnUserEarnedReward += Replay;

        


    }
    private void Replay(object sender, Reward e)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    #endregion
}
