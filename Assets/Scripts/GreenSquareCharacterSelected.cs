using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenSquareCharacterSelected : MonoBehaviour
{
    [SerializeField] bool isHalloween;
    void Start()
    {
        if (ScoreManager.instance.currentCharacterSelected == 0)
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
        else if (ScoreManager.instance.currentCharacterSelected == 1)
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
