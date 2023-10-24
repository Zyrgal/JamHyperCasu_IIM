using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnviroManager : MonoBehaviour
{
    [SerializeField] List<GameObject> enviroList;
    [SerializeField] Button halloweenButton;
    //dictionnaire avec une string serait mieux (dynamique)

    public void EnableHalloweenEnviro()
    {
        halloweenButton.interactable = true;
    }

    public void UI_DisplayEnviro(int index)
    {
        for (int i = 0; i < enviroList.Count; i++)
        {
            enviroList[i].SetActive(false);
        }

        enviroList[index].SetActive(true);

    }
}
