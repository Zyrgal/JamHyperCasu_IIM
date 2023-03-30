using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputPlayer : MonoBehaviour
{
    [SerializeField]
    float speed = 4f;
    
    public float Speed { get => speed; set => speed = value; }

    Rigidbody rb;

    bool isDead = false;
    bool canMove = false;
    bool playerIsMoving = false;

    private FinishLine finishLine;

    [SerializeField]
    private UiManager uiManager;

    public event Action playerDied;
    public event Action isRevive;

    [SerializeField]
    Animator animator;

    public bool PlayerIsMoving { get => playerIsMoving; }
    public bool IsDead { /*get => isDead;*/ set => isDead = value; }


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerDied += OnPlayerDeath;
        uiManager.gameLaunch += Initialization;
        finishLine = GameObject.FindObjectOfType<FinishLine>();
        finishLine.crossEndLine += OnPlayerWin;
    }

    private void Initialization()
    {
        canMove = true;
    }

    private void Update()
    {
        if (Input.GetButtonUp("Fire1"))
        {
            //int temp Animator.StringToHash("IsWalking");
            animator.SetBool("IsWalking", false);
            rb.velocity = Vector3.zero;
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
            animator.SetBool("IsWalking", true);
            rb.velocity = transform.forward * speed * Time.deltaTime;

            if (!playerIsMoving)
            {
                playerIsMoving = true;
            }

            gameObject.transform.position += Vector3.forward * speed * Time.deltaTime;
        }
    }

    private void OnPlayerWin()
    {
        animator.SetTrigger("Victory");
        canMove = false;
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
        animator.SetTrigger("IsDead");
        IsDead = true;
    }

    public void Revive()
    {
        animator.SetTrigger("Idle");
        IsDead = false;
        canMove = true;
        isRevive.Invoke();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.CompareTag("Ground"))
        {
            canMove = false;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (!collision.collider.CompareTag("Ground"))
        {
            canMove = true;
        }
    }
}
