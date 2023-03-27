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

    private void Start()
    {
        StartCoroutine(TurningBehaviour());
    }

    private IEnumerator TurningBehaviour()
    {
        yield return new WaitForSeconds(waitForTurn);

        player.CheckIfPlayerDie();

        yield return new WaitForSeconds(turnTimer);

        StartCoroutine(TurningBehaviour());
    }
}
