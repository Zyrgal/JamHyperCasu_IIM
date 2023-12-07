using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class GiveShieldTextRef : MonoBehaviour
{
    void Start()
    {
        ScoreManager.instance.SetShieldTextReference(gameObject.GetComponent<TextMeshProUGUI>());
    }
}
