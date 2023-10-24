using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.Advertisements;
using System;

public class RewardedAdsButton : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] Button _showAdButton;
    [SerializeField] string _androidPlacementID = "";
    [SerializeField] string _iOSAdUnitId = "Rewarded_iOS";

    public static event Action onRevive;
    public static event Action onHalloweenMapReward;

    public event Action<string> rewardWatched;
    public static event Action watchingReward;

    string _adUnitId = null; // This will remain null for unsupported platforms

    void Awake()
    {
        // Get the Ad Unit ID for the current platform:
#if UNITY_IOS
        _adUnitId = _iOSAdUnitId;
#elif UNITY_ANDROID
        _adUnitId = _androidPlacementID;
#endif

        //Advertisement.Initialize("5224737");
        Advertisement.Load(_adUnitId, this);
        //Disable the button until the ad is ready to show:
        _showAdButton.interactable = false;
        OnUnityAdsAdLoaded(_adUnitId);
    }

    // Load content to the Ad Unit:
    public void LoadAd()
    {
        // IMPORTANT! Only load content AFTER initialization (in this example, initialization is handled in a different script).
        Debug.Log("Loading Ad: " + _adUnitId);
        Advertisement.Load(_adUnitId, this);
    }

    // If the ad successfully loads, add a listener to the button and enable it:
    public void OnUnityAdsAdLoaded(string adUnitId)
    {
        Debug.Log("Ad Loaded: " + adUnitId,gameObject);

        if (adUnitId.Equals(_adUnitId))
        {
            // Configure the button to call the ShowAd() method when clicked:
            _showAdButton.onClick.AddListener(ShowAd);
            // Enable the button for users to click:
            _showAdButton.interactable = true;
        }
    }

    // Implement a method to execute when the user clicks the button:
    public void ShowAd()
    {
        Time.timeScale = 0;
        watchingReward?.Invoke();
        // Disable the button:
        _showAdButton.interactable = false;
        // Then show the ad:
        Advertisement.Show(_adUnitId, this);
    }

    // Implement the Show Listener's OnUnityAdsShowComplete callback method to determine if the user gets a reward:
    public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState)
    {
        if (adUnitId.Equals(_adUnitId) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
        {
            // Grant a reward.
            rewardWatched?.Invoke(_adUnitId);
            if (_adUnitId == "Rewarded_Android")
            {
                onRevive?.Invoke();
            }
            else if (_adUnitId == "HalloweenMap")
            {
                onHalloweenMapReward?.Invoke();
            }

            //player.Revive();
            // Load another ad:
            Advertisement.Load(_adUnitId, this);
        }

        switch (showCompletionState)
        {
            case UnityAdsShowCompletionState.SKIPPED:
                Time.timeScale = 1;
                break;
            case UnityAdsShowCompletionState.COMPLETED:
                Time.timeScale = 1;
                break;
            case UnityAdsShowCompletionState.UNKNOWN:
                Time.timeScale = 1;
                break;
            default:
                break;
        }
    }

    // Implement Load and Show Listener error callbacks:
    public void OnUnityAdsFailedToLoad(string adUnitId, UnityAdsLoadError error, string message)
    {
        Time.timeScale = 1;
        Debug.Log($"Error loading Ad Unit {adUnitId}: {error.ToString()} - {message}");
        // Use the error details to determine whether to try to load another ad.
    }

    public void OnUnityAdsShowFailure(string adUnitId, UnityAdsShowError error, string message)
    {
        Time.timeScale = 1;
        Debug.Log($"Error showing Ad Unit {adUnitId}: {error.ToString()} - {message}");
        // Use the error details to determine whether to try to load another ad.
    }

    public void OnUnityAdsShowStart(string adUnitId) { }
    public void OnUnityAdsShowClick(string adUnitId) { }

    void OnDestroy()
    {
        // Clean up the button listeners:
        _showAdButton.onClick.RemoveAllListeners();
    }
}