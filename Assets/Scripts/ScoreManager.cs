using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using GameAnalyticsSDK;
using UnityEngine.Rendering;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int gold = 0;

    public bool havePayForHalloweenSkinCharacter;
    public bool haveWatchAdForHalloweenMap;

    public int currentMapSelected = 0;
    public int currentCharacterSelected = 0;
    public int currentLevel = 1;
    
    TextMeshProUGUI goldText;
    TextMeshProUGUI currentLevelText;
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

    public void Start()
    {
        GameAnalytics.Initialize();
    }

    public void SetGoldTextReference(TextMeshProUGUI newText)
    {
        goldText = newText;
        goldText.text = gold.ToString();
    }
    public void SetCurrentLevelTextReference(TextMeshProUGUI newText)
    {
        currentLevelText = newText;
        currentLevelText.text = "Level : " + currentLevel.ToString();
    }

    public void IncrementeGold()
    {
        GameAnalytics.NewResourceEvent(0, "Gold", 100, "WinRun", "Gold");
        gold += 100;
        goldText.text = gold.ToString();
    }

    public void IncrementeLevelIndex()
    {
        currentLevel += 1;
        currentLevelText.text = currentLevel.ToString();
    }

    public void HaveWatchHalloweenMapAd()
    {
        haveWatchAdForHalloweenMap = true;
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
        goldText.text = gold.ToString();
    }
}
