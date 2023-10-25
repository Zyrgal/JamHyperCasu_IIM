using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateCharacterAtStart : MonoBehaviour
{
    [SerializeField] bool isNormalCharacter;
    [SerializeField] EnviroManager enviroManager;
    IEnumerator Start()
    {
        yield return new WaitForEndOfFrame();
        if (ScoreManager.instance.currentCharacterSelected == 0)
        {
            if (isNormalCharacter)
            {
                //enviroManager.SetCharacterNormal();
                //gameObject.SetActive(true);
            }
            else
            {
                enviroManager.SetCharacterNormal();
                gameObject.SetActive(false);
            }
        }
        else if (ScoreManager.instance.currentCharacterSelected == 1)
        {
            if (isNormalCharacter)
            {
                enviroManager.SetCharacterHalloween();
                gameObject.SetActive(false);
            }
            else
            {
                //enviroManager.SetCharacterHalloween();
                //gameObject.SetActive(true);
            }
        }
    }
}
