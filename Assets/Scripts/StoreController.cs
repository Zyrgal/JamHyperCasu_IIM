using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class StoreController : MonoBehaviour, IStoreController
{
    private static StoreController instance;
    //public static StoreController Instance { get { if (instance == null) instance = FindObjectOfType<StoreController>(); return instance; } }
    public static StoreController Instance => instance = instance ?? FindObjectOfType<StoreController>();

    public ProductCollection products => throw new NotImplementedException();

    public void ConfirmPendingPurchase(Product product)
    {
        Debug.Log("ConfirmPendingPurchase " + "product = " + product);
    }

    public void FetchAdditionalProducts(HashSet<ProductDefinition> additionalProducts, Action successCallback, Action<InitializationFailureReason> failCallback)
    {
        throw new NotImplementedException();
    }

    public void FetchAdditionalProducts(HashSet<ProductDefinition> additionalProducts, Action successCallback, Action<InitializationFailureReason, string> failCallback)
    {
        throw new NotImplementedException();
    }

    public void InitiatePurchase(Product product, string payload)
    {
        Debug.Log("InitiatePurchase " + "product = " + product + "playload = " + payload);
    }

    public void InitiatePurchase(string productId, string payload)
    {
        Debug.Log("InitiatePurchase " + "productId = " + productId + "playload = " + payload);

    }

    public void InitiatePurchase(Product product)
    {
        Debug.Log("InitiatePurchase " + "product = " + product);

    }

    public void InitiatePurchase(string productId)
    {
        Debug.Log("InitiatePurchase " + "productId = " + productId);

    }
}
