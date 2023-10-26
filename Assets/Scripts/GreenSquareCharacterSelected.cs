using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GreenSquareCharacterSelected : MonoBehaviour
{
    [SerializeField] bool isHalloween;
    void Start()
    {
        if (ScoreManager.instance.currentCharacterSelected == 0)
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
        else if (ScoreManager.instance.currentCharacterSelected == 1)
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
