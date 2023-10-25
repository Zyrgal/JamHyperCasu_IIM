using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GiveCurrentLevelTextRef : MonoBehaviour
{
    void Start()
    {
        ScoreManager.instance.SetCurrentLevelTextReference(gameObject.GetComponent<TextMeshProUGUI>());
    }
}
