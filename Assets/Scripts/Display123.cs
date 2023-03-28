using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Display123 : MonoBehaviour
{
    [SerializeField]
    GameObject[] sprite123;

    [SerializeField]
    GameObject soleil;

    [SerializeField]
    EnemySpotting enemySpotting;
    void Start()
    {
        enemySpotting.turnBack += OnTurnBack;
        enemySpotting.beginCount += Display;
    }

    void Display()
    {
        StartCoroutine(E_Display());
    }

    IEnumerator E_Display()
    {
        HideAndShow(0);
        yield return new WaitForSeconds(1f);
        HideAndShow(1);
        yield return new WaitForSeconds(1f);
        HideAndShow(2);
        float randomSoleil = Random.Range(0.1f, 0.8f);
        yield return new WaitForSeconds(randomSoleil);
        sprite123[2].SetActive(false);
        soleil.SetActive(true);
    }

    void OnTurnBack()
    {
        soleil.SetActive(false);
    }

    void HideAndShow(int numberToDisplay)
    {
        for (int i = 0; i < sprite123.Length; i++)
        {
            if (numberToDisplay == i)
            {
                sprite123[i].SetActive(true);
            }
            else
            {
                sprite123[i].SetActive(false);
            }
        }
    }

}
