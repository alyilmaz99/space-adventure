using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class interstitialads : MonoBehaviour
{
    private InterstitialAd interstitial;

    void Start()
    {
        MobileAds.Initialize(initStatus => { });
        RequestInterstitial();
        if(interstitial.IsLoaded()){
            interstitial.Show();
        }
    }
    

private void RequestInterstitial()
{
    #if UNITY_ANDROID
        string adUnitId = "ca-app-pub-2763655103678935/9036603956";
    #elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-3940256099942544/4411468910";
    #else
        string adUnitId = "unexpected_platform";
    #endif

     // Initialize an InterstitialAd.
    this.interstitial = new InterstitialAd(adUnitId);


    // Create an empty ad request.
    AdRequest request = new AdRequest.Builder().Build();
    // Load the interstitial with the request.
    this.interstitial.LoadAd(request);
}
}
