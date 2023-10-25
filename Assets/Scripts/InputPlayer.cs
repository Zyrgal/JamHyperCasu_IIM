using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputPlayer : MonoBehaviour
{
    [SerializeField] float speed = 4f;
    [SerializeField] int lifePoint = 2;
    [SerializeField] List<GameObject> checkPoints;

    public float Speed { get => speed; set => speed = value; }

    Rigidbody rb;

    bool isDead = false;
    bool canMove = false;
    bool playerIsMoving = false;
    bool isInvulnurable = false;

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
        RewardedAdsButton.onRevive += Revive;
    }
    private void OnDestroy()
    {
        RewardedAdsButton.onRevive -= Revive;
        finishLine.crossEndLine -= OnPlayerWin;
        uiManager.gameLaunch -= Initialization;
        playerDied -= OnPlayerDeath;
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

        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("RollBack");
            RollBack();
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

    public void TakeDamage()
    {
        lifePoint--;        

        if (lifePoint <= 0)
        {
            playerDied.Invoke();
            return;
        }

        uiManager.PlayerGetHit();
        animator.SetTrigger("GetHit");
        RollBack();
        isInvulnurable = true;
        StartCoroutine(InvulnerabilityFrame());
    }

    public void CheckIfTakeDamage()
    {
        if (!PlayerIsMoving || isInvulnurable)
        {
            return;
        }

        TakeDamage();
    }

    private IEnumerator InvulnerabilityFrame()
    {
        yield return new WaitForSeconds(1f);
        isInvulnurable = false;
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
        isRevive?.Invoke();
    }

    public void RollBack()
    {
        canMove = false;
        playerIsMoving = false;
        StartCoroutine(LerpPosition(gameObject.transform.position, checkPoints[checkPoints.Count - 1].transform.position + new Vector3(0,0.15f,0), 1f));
    }

    public IEnumerator LerpPosition(Vector3 currentPosition, Vector3 targetPostion, float dur)
    {
        var startTime = Time.time;
        transform.position = currentPosition;
        while (startTime + dur > Time.time)
        {
            transform.position = Vector3.Lerp(currentPosition, targetPostion, (Time.time - startTime) / dur);
            yield return null;

        }
        transform.position = targetPostion;
        canMove = true;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Checkpoint"))
        {
            checkPoints.Add(other.gameObject);
            Debug.Log("CHECKPOINT");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {        
        if (collision.collider.CompareTag("Wall"))
        {
            canMove = false;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Wall"))
        {
            canMove = true;
        }
    }
}
