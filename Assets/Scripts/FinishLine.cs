using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public event Action crossEndLine;
    [SerializeField] RewardedAdsButton rewardedAdsButton;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            rewardedAdsButton.ShowAd();
            crossEndLine?.Invoke();
        }
    }
}
