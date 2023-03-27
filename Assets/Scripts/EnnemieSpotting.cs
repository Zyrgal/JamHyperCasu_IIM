using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemieSpotting : MonoBehaviour
{
    [SerializeField]
    float waitToTurn = 3f;

    [SerializeField]
    float turnTimer = 1f;

    [SerializeField]
    InputPlayer player;

    [SerializeField]
    bool canKill = true;

    private void Start()
    {
        StartCoroutine(TurningBehaviour());
    }

    private IEnumerator TurningBehaviour()
    {
        yield return new WaitForSeconds(waitToTurn);

        if (canKill)
        {
            player.CheckIfPlayerDie();
        }

        yield return new WaitForSeconds(turnTimer);

        StartCoroutine(TurningBehaviour());
    }
}
