using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class GiveGoldTextRef : MonoBehaviour
{
    void Start()
    {
        ScoreManager.instance.SetGoldTextReference(gameObject.GetComponent<TextMeshProUGUI>());
    }
}
