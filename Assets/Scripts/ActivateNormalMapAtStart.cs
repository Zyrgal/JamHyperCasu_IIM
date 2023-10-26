using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivateNormalMapAtStart : MonoBehaviour
{
    [SerializeField] bool isNormalLevel;
    void Start()
    {
        if (ScoreManager.instance.currentMapSelected == 0)
        {
            if (isNormalLevel)
            {
                gameObject.SetActive(true);
            }
            else 
            {
                gameObject.SetActive(false);
            }
        }
        else if (ScoreManager.instance.currentMapSelected == 1)
        {
            if (isNormalLevel)
            {
                gameObject.SetActive(false);
            }
            else
            {
                gameObject.SetActive(true);
            }
        }
    }

}
