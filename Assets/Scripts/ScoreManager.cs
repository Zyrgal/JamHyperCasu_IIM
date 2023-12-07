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
    public int gems = 0;
    public int shieldAmount = 0;

    public bool havePayForHalloweenSkinCharacter;
    public bool haveWatchAdForHalloweenMap;

    public int currentMapSelected = 0;
    public int currentCharacterSelected = 0;
    public int currentLevel = 1;
    
    TextMeshProUGUI goldText;
    TextMeshProUGUI gemsText;
    TextMeshProUGUI shieldText;
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
    public void SetGemsTextReference(TextMeshProUGUI newText)
    {
        gemsText = newText;
        gemsText.text = gems.ToString();
    }
    public void SetShieldTextReference(TextMeshProUGUI newText)
    {
        shieldText = newText;
        shieldText.text = shieldAmount.ToString();
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
    public void IncrementeGold(int amount)
    {
        //GameAnalytics.NewResourceEvent(0, "Gold", amount, "WinRun", "Gold");
        gold += amount;
        goldText.text = gold.ToString();
    }
    public void DecrementeGold(int amount)
    {
        GameAnalytics.NewResourceEvent(0, "Gold", amount, "WinRun", "Gold");
        gold -= amount;
        goldText.text = gold.ToString();
    }
    public void DecrementeGems(int amount)
    {
        gems -= amount;
        gemsText.text = gems.ToString();
    }
    
    public void IncrementeShield(int amount)
    {
        shieldAmount = 1;
        shieldText.text = shieldAmount.ToString();
    }
    public void DecrementeShield()
    {
        shieldAmount--;
        shieldText.text = shieldAmount.ToString();
    }
    public void IncrementeGems(int amount)
    {
        gems += amount;
        gemsText.text = gems.ToString();
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

    public void TryBuyGoldCoin(int cost)
    {
        if (CanPayWithGems(cost))
        {
            DecrementeGems(cost);
            if (cost == 200)
            {
                IncrementeGold(2000);
            }
            else if(cost == 400)
            {
                IncrementeGold(5000);
            }
            else if (cost == 800)
            {
                IncrementeGold(15000);
            }
        }
    }

    public bool CanPayWithGems(int cost)
    {
        if (gems >= cost)
        {
            return true;
        }
        else
        {
            return false;
        }
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
