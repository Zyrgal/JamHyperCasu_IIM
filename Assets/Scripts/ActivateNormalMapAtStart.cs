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
                GetComponent<Image>().enabled = true;
            }
            else 
            {
                GetComponent<Image>().enabled = false;
            }
        }
        else if (ScoreManager.instance.currentMapSelected == 1)
        {
            if (isNormalLevel)
            {
                GetComponent<Image>().enabled = false;
            }
            else
            {
                GetComponent<Image>().enabled = true;
            }
        }
    }

}
