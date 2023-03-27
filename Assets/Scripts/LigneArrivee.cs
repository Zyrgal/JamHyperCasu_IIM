using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LigneArrivee : MonoBehaviour
{

    public event Action crossEndLine;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            crossEndLine.Invoke();
        }
    }
}
