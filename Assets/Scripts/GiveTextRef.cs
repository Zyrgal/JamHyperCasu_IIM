using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class GiveTextRef : MonoBehaviour
{
    void Start()
    {
        ScoreManager.instance.SetGoldTextReference(gameObject.GetComponent<TextMeshProUGUI>());
    }
}
