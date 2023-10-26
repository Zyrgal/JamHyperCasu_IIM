using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GreenSquareSelectLevel : MonoBehaviour
{
    [SerializeField] bool isHalloween;
    void Start()
    {
        if (ScoreManager.instance.currentMapSelected == 0)
        {
            if (isHalloween) 
            {
                GetComponent<Image>().enabled = false;
            }
            else
            {
                GetComponent<Image>().enabled = true;
            }
        }
        else if (ScoreManager.instance.currentMapSelected == 1)
        {
            if (isHalloween)
            {
                GetComponent<Image>().enabled = true;
            }
            else
            {
                GetComponent<Image>().enabled = false;
            }
        }
    }
}
