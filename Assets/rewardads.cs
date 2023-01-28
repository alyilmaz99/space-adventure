using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;
using UnityEngine.SceneManagement;

public class rewardads : MonoBehaviour
{
    private RewardedAd rewardedAd;

    public string adUnityId;

    public void Start()
    {
        MobileAds.Initialize(initStatus => { });

        RequestRewardedVideo();



        //if (rewardedAd.IsLoaded())
        //    rewardedAd.Show();
    }

    public void RequestRewardedVideo()
    {
        string adUnityId;
#if UNITY_ANDROID
        adUnityId = "ca-app-pub-3940256099942544/5224354917";
#elif UNITY_IPHONE
            adUnitId = "ca-app-pub-3940256099942544/1712485313";
#else
            adUnitId = "unexpected_platform";
#endif

        this.rewardedAd = new RewardedAd(adUnityId);

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

    // no ads satýn alma kontrolü yapýlacak. Reklamsýz izleme alýndýysa reklam izleme fonksiyonuna gidilmeyecek
    public void WatchRebornAd()
    {
        WatchAd();
    }
    void WatchAd()
    {
        if (this.rewardedAd != null)
        {
            this.rewardedAd.Destroy();

        }

        if (this.rewardedAd.IsLoaded())
        {
            this.rewardedAd.Show();
        }
        this.rewardedAd.OnUserEarnedReward += Replay;

        


    }
    private void Replay(object sender, Reward e)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    #endregion
}
