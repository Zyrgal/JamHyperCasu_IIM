using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public event Action crossEndLine;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            crossEndLine?.Invoke();
            ScoreManager.instance.IncrementeGold();
            ScoreManager.instance.IncrementeGold();
        }
    }
}
