using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;



public class AdsManager : MonoBehaviour
{

    #region InternalTypes

    class AdListener : IUnityAdsShowListener
    {
        public AdListener(AdsManager master)
        {
            Master = master;
        }

        public AdsManager Master { get; }

        public void OnUnityAdsShowClick(string placementId)
        {
            Debug.Log("ClickPub");
            //throw new System.NotImplementedException();
        }

        public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
        {
            switch (showCompletionState)
            {
                case UnityAdsShowCompletionState.SKIPPED:
                    Debug.Log("Pubs skipped");
                    break;
                case UnityAdsShowCompletionState.COMPLETED:
                    Debug.Log("Completed");
                    Master.HideLoseMenu();
                    Master.player.Revive();
                    break;
                case UnityAdsShowCompletionState.UNKNOWN:
                    Debug.Log("Pubs Unknow");
                    break;
                default:
                    break;
            }
        }

        public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
        {
            Debug.Log("ShowFailure" + message);
            //throw new System.NotImplementedException();
        }

        public void OnUnityAdsShowStart(string placementId)
        {
            Master.StartCoroutine(Routine());
            IEnumerator Routine()
            {
                yield return new WaitForSeconds(0.5f);
                while(Advertisement.isShowing)
                {
                    yield return null;
                }

                Master.rewardWatched.Invoke();
                Master.player.Revive();
            }
        }
    }
    #endregion

    #region AddListener
    class ADDListener : IUnityAdsListener
    {
        public void OnUnityAdsDidError(string message)
        {
            throw new System.NotImplementedException();
        }

        public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
        {
            throw new System.NotImplementedException();
        }

        public void OnUnityAdsDidStart(string placementId)
        {
            throw new System.NotImplementedException();
        }

        public void OnUnityAdsReady(string placementId)
        {
            throw new System.NotImplementedException();
        }
    }
    #endregion


    [SerializeField]
    GameObject LoseMenu;
    [SerializeField]
    GameObject AdForRewardMenu;
    [SerializeField]
    InputPlayer player;

    public event Action watchingReward;
    public event Action rewardWatched;

    AdListener adshowListener;

    ADDListener aDDListener;

    float tentatives;

    private void Awake()
    {
        adshowListener = new AdListener(this);
    }

    private void Start()
    {
        LoseMenu = GameObject.Find("LoseMenu");
        AdForRewardMenu = GameObject.Find("AdForReward");
        player = GameObject.Find("Player").GetComponent<InputPlayer>();
        Advertisement.Initialize("5224737");
        Advertisement.Load("Rewarded_Android");
    }

    private void HideLoseMenu()
    {
        LoseMenu.SetActive(false);
    }

    public void Ui_ChoseToRevive()
    {
        watchingReward?.Invoke();
        RunRewardedAD();
    }

    public void RunRewardedAD()
    {
        while (!Advertisement.IsReady("Rewarded_Android") || tentatives > 10f)
        {
            tentatives += Time.deltaTime;
            Debug.Log(tentatives);
        }

        Advertisement.AddListener(aDDListener);


        Advertisement.Show("Rewarded_Android", adshowListener);


    }

    public void RunBannerAD()
    {
        Advertisement.Load("Banner_Android");
        Advertisement.Show("Banner_Android");
    }
}
