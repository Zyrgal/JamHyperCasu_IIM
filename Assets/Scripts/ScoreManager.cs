using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using Codice.Client.BaseCommands;
using GameAnalyticsSDK;
using Codice.Client.BaseCommands.Merge.Xml;
using static Codice.Client.Common.Servers.RecentlyUsedServers;
using static Codice.CM.Common.CmCallContext;


public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int gold = 0;
    public bool havePayForHalloweenSkinCharacter;

    public int currentLevelSelected = 0;
    public int currentCharacterSelected = 0;

    FinishLine finishline;
    TextMeshProUGUI goldText;
    public bool isGoldCoinActivate = true;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void SetGoldTextReference(TextMeshProUGUI newText)
    {
        goldText = newText;
        goldText.text = gold.ToString();
    }
    public void IncrementeGold()
    {
        GameAnalytics.NewResourceEvent(0, "Gold", 100, "WinRun", "Gold");
        gold += 100;
        goldText.text = gold.ToString();
    }

    public bool CanPay(int cost)
    {
        if (gold >= cost)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Pay(int cost)
    {
        gold -= cost;
    }
}