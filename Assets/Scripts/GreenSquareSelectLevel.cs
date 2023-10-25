using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenSquareSelectLevel : MonoBehaviour
{
    [SerializeField] bool isHalloween;
    void Start()
    {
        if (ScoreManager.instance.currentMapSelected == 0)
        {
            if (isHalloween) 
            {
                gameObject.SetActive(false);
            }
            else
            {
                gameObject.SetActive(true);
            }
        }
        else if (ScoreManager.instance.currentMapSelected == 1)
        {
            if (isHalloween)
            {
                gameObject.SetActive(true);
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }
}
