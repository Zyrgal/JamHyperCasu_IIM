using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinImageActivate : MonoBehaviour
{
    void Start()
    {
        if (ScoreManager.instance.isGoldCoinActivate)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

}
