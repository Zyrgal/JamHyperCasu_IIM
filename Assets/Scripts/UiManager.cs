using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class UiManager : MonoBehaviour
{
    private FinishLine finishLine;
    InputPlayer player;

    [SerializeField]
    GameObject winPanel;
    [SerializeField]
    GameObject losePanel;
    public event Action gameLaunch;
    [SerializeField]
    private GameObject menuStart;

    private void Start()
    {
        finishLine = GameObject.FindObjectOfType<FinishLine>();
        player = GameObject.Find("Player").GetComponent<InputPlayer>();
        finishLine.crossEndLine += OnPlayerWin;
        player.playerDied += OnPlayerLose;
        //finishLine.crossEndLine += OnPlayerLose;
    }

    public void Ui_LaunchGame()
    {
        gameLaunch.Invoke();
        menuStart.SetActive(false);
    }

    private void OnPlayerWin()
    {
        winPanel.SetActive(true);
    }

    private void OnPlayerLose()
    {
        losePanel.SetActive(true);
    }

    public void ReloadScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
