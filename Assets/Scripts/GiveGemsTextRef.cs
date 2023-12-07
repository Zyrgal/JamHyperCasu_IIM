using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class GiveGemsTextRef : MonoBehaviour
{
    void Start()
    {
        ScoreManager.instance.SetGemsTextReference(gameObject.GetComponent<TextMeshProUGUI>());
    }
}
