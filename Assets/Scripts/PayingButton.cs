using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.Purchasing.Extension;

public class PayingButton : MonoBehaviour
{
    [SerializeField] CodelessIAPButton codelessIAPButton;
    [SerializeField] int gemsAmount;

    private void Start()
    {
        codelessIAPButton.onPurchaseComplete.AddListener(PurchaseComplete);
        codelessIAPButton.onPurchaseFailed.AddListener(PurchaseFailed);
    }

    private void OnDestroy()
    {
        codelessIAPButton.onPurchaseComplete.RemoveAllListeners();
        codelessIAPButton.onPurchaseFailed.RemoveAllListeners();

    }

    private void PurchaseComplete(Product purchasedProduct)
    {
        ScoreManager.instance.IncrementeGems(gemsAmount);
        Debug.Log("Purchase Sucess");
        Debug.Log(purchasedProduct.definition.id);
    }
    private void PurchaseFailed(Product production , PurchaseFailureDescription purchaseFailureDescription)
    {
        Debug.Log("Purchase Failed");
        Debug.Log(production);
        Debug.Log(purchaseFailureDescription);
    }

    
}
