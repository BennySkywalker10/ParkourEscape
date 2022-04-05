using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class Ads : MonoBehaviour
{
    // android: 4687149
    // apple: your_id
    string gameId = "4687123";
    bool testMode = true;
/*
#if UNITY_IOS
        private string gameId = "4091461";
#elif UNITY_ANDROID
        private string gameId = "4091460";
#endif
*/

    void Start()
    {
        // Initialize the Ads service:
        Advertisement.Initialize(gameId);
        Advertisement.Initialize(gameId, testMode);
    }

    public void ShowInterstitialAd()
    {
        // Check if UnityAds ready before calling Show method:
        if (Advertisement.IsReady())
        {
            Advertisement.Show("Interstitial_Android");
        }
        else
        {
            Debug.Log("Interstitial ad not ready at the moment! Please try again later!");
        }
        //Time.timeScale = 0f;
    }

}