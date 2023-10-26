using GameAnalyticsSDK.Events;
using GameAnalyticsSDK;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public event Action crossEndLine;

    [SerializeField] ParticleSystem ps;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            crossEndLine?.Invoke();
            GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete , "Level_" + ScoreManager.instance.currentLevel, ScoreManager.instance.gold);
            ps.Play();
            ScoreManager.instance.IncrementeGold();
        }
    }
}
