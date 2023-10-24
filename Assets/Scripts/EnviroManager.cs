using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviroManager : MonoBehaviour
{
    [SerializeField] List<GameObject> enviroList;
    //dictionnaire avec une string serait mieux (dynamique)

    public void DisplayEnviro(int index)
    {
        for (int i = 0; i < enviroList.Count; i++)
        {
            enviroList[i].SetActive(false);
        }

        enviroList[index].SetActive(true);

    }
}
