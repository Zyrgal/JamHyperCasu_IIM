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
    bool canKill = true;

    public event Action turnBack;
    public event Action beginCount;

    private void Start()
    {
        StartCoroutine(TurningBehaviour());
    }

    private IEnumerator TurningBehaviour()
    {
        beginCount.Invoke();
        yield return new WaitForSeconds(waitForTurn);

        if (canKill)
        {
            player.CheckIfPlayerDie();
        }

        yield return new WaitForSeconds(turnTimer);
        turnBack.Invoke();

        float randomRecover = UnityEngine.Random.Range(0.7f, 1.2f);
        yield return new WaitForSeconds(randomRecover);
        StartCoroutine(TurningBehaviour());
    }
}
