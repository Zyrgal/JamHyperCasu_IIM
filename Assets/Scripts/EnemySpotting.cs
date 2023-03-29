using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpotting : MonoBehaviour
{
    [SerializeField]
    float waitForTurn = 3f;

    [SerializeField]
    float turnTimer = 1f;

    [SerializeField]
    InputPlayer player;

    [SerializeField]
    UiManager uimanager;
    [SerializeField]
    private FinishLine finishLine;

    [SerializeField]
    bool canKill = true;

    Coroutine turningCoroutine;
    bool canSpotMovement;

    public event Action turnBack;
    public event Action<float> beginCount;

    public void Start()
    {
        uimanager.gameLaunch += CallEnumerator;
        finishLine.crossEndLine += OnPlayerWin;
        player.playerDied += OnPlayerLose;
    }

    void OnPlayerWin()
    {
        StopCoroutine(turningCoroutine);
    }

    void OnPlayerLose()
    {
        StopCoroutine(turningCoroutine);
    }

    public void CallEnumerator()
    {
        turningCoroutine = StartCoroutine(RunTheGame());
        uimanager.gameLaunch -= CallEnumerator;
    }

    public IEnumerator RunTheGame()
    {
        yield return new WaitForSeconds(0.1f);

        yield return TurningBehaviour();
    }

    private void Update()
    {
        if (canKill && canSpotMovement)
        {
            player.CheckIfPlayerDie();
        }
    }

    private IEnumerator TurningBehaviour()
    {
        while (true) //Stop quand win/lose (stopcoroutine?)
        {
            float randomDelaySun = UnityEngine.Random.Range(0.1f, 0.8f);
            beginCount?.Invoke(randomDelaySun);
            yield return new WaitForSeconds(2 + randomDelaySun);

            canSpotMovement = true;

            float randomSpotDuration = UnityEngine.Random.Range(0.4f, 0.7f);
            yield return new WaitForSeconds(randomSpotDuration);
            canSpotMovement = false;
            turnBack.Invoke();

            float randomRecover = UnityEngine.Random.Range(0.4f, 0.7f);
            yield return new WaitForSeconds(randomRecover);
        }
    }
}
