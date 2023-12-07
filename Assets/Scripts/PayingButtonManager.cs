using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class PayingButtonManager : MonoBehaviour
{
    [SerializeField] private ReferencePayingButtonManager referencePayingButtonManager;

    private void Awake()
    {
        referencePayingButtonManager.payingButtonManager = this;
    }
}
