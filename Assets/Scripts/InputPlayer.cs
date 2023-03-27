using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPlayer : MonoBehaviour
{
    [SerializeField]
    float speed = 1f;


    bool playerIsMoving = false;
    public bool PlayerIsMoving { get => playerIsMoving; }
    public bool IsDead { /*get => isDead;*/ set => isDead = value; }

    bool isDead = false;

    void Update()
    {
        if (isDead)
        {
            return;
        }

        if (Input.GetButton("Fire1"))
        {
            if (!playerIsMoving)
            {
                Debug.Log("playerIsMoving = true");
                playerIsMoving = true;
            }
            gameObject.transform.position += Vector3.forward * speed * Time.deltaTime;
        }

        if (Input.GetButtonUp("Fire1"))
        {
            Debug.Log("playerIsMoving = false");
            playerIsMoving = false;
        }
    }

    public void CheckIfPlayerDie()
    {
        if (PlayerIsMoving)
        {
            IsDead = true;
            Debug.Log("Dead");
        }
    }
}
