using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputPlayer : MonoBehaviour
{
    [SerializeField]
    float speed = 4f;

    Rigidbody rb;

    bool isDead = false;
    bool canMove = false;
    bool playerIsMoving = false;

    private FinishLine finishLine;

    [SerializeField]
    private UiManager uiManager;

    public event Action playerDied;

    public bool PlayerIsMoving { get => playerIsMoving; }
    public bool IsDead { /*get => isDead;*/ set => isDead = value; }


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerDied += OnPlayerDeath;
        uiManager.gameLaunch += Initialization;
        finishLine = GameObject.FindObjectOfType<FinishLine>();
    }

    private void Initialization()
    {
        canMove = true;
    }

    private void Update()
    {
        if (Input.GetButtonUp("Fire1"))
        {
            rb.velocity = Vector3.zero;
            //Debug.Log("playerIsMoving = false");
            playerIsMoving = false;
        }
    }

    void FixedUpdate()
    {
        if (isDead || !canMove)
        {
            return;
        }

        if (Input.GetButton("Fire1"))
        {
            rb.velocity = transform.forward * speed * Time.deltaTime;

            if (!playerIsMoving)
            {
                //Debug.Log("playerIsMoving = true");
                playerIsMoving = true;
            }

            gameObject.transform.position += Vector3.forward * speed * Time.deltaTime;
        }
    }

    public void CheckIfPlayerDie()
    {
        if (PlayerIsMoving)
        {
            playerDied.Invoke();
        }
    }

    private void OnPlayerDeath()
    {
        IsDead = true;
        Debug.Log("Dead");
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.CompareTag("Ground"))
        {
            canMove = false;
            Debug.Log("canMove = false");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (!collision.collider.CompareTag("Ground"))
        {
            canMove = true;
            Debug.Log("canMove = true");
        }
    }
}
