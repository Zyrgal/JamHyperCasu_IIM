using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Display123 : MonoBehaviour
{
    [SerializeField]
    GameObject[] sprite123;

    [SerializeField]
    GameObject sun;

    [SerializeField]
    EnemySpotting enemySpotting;
    [SerializeField]
    private FinishLine finishLine;
    [SerializeField]
    InputPlayer player;
    [SerializeField]
    AdsManager adsManager;

    Coroutine displayCoroutine;

    float delayForSun = 0;

    void Start()
    {
        enemySpotting.turnBack += OnTurnBack;
        enemySpotting.beginCount += StartDisplayCoroutine;
        finishLine.crossEndLine += OnPlayerWin;
        player.playerDied += OnPlayerLose;
        adsManager.watchingReward += OnWatchingReward;
        player = GameObject.Find("Player").GetComponent<InputPlayer>();
        adsManager = GameObject.Find("AdsManager").GetComponent<AdsManager>();

    }

    void StartDisplayCoroutine(float delaySun)
    {
        delayForSun = delaySun;
        displayCoroutine = StartCoroutine(E_Display());
    }

    void OnPlayerLose()
    {
        StopDisplayCoroutine();
    }

    void OnPlayerWin()
    {
        StopDisplayCoroutine();
    }

    private void OnWatchingReward()
    {
        sun.SetActive(false);
    }

    public void StopDisplayCoroutine()
    {
        StopCoroutine(displayCoroutine);
    }

    IEnumerator E_Display()
    {
        HideAndShow(0);
        yield return new WaitForSeconds(1f);
        HideAndShow(1);
        yield return new WaitForSeconds(1f);
        HideAndShow(2);
        yield return new WaitForSeconds(delayForSun);
        sprite123[2].SetActive(false);
        sun.SetActive(true);
    }

    void OnTurnBack()
    {
        sun.SetActive(false);
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
