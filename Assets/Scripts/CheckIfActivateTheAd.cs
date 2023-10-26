using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIfActivateTheAd : MonoBehaviour
{
    void Start()
    {
        if (ScoreManager.instance.haveWatchAdForHalloweenMap)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }

    public void WatchedAd()
    {
        ScoreManager.instance.HaveWatchHalloweenMapAd();
    }
}
