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
            ps.Play();
            ScoreManager.instance.IncrementeGold();
        }
    }
}
