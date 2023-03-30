using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class UiManager : MonoBehaviour
{
    [SerializeField]
    private FinishLine finishLine;

    public FinishLine FinishLine1 { get => finishLine; set => finishLine = value; }

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
        //finishLine = GameObject.FindObjectOfType<FinishLine>();
        player = GameObject.Find("Player").GetComponent<InputPlayer>();
        finishLine.crossEndLine += OnPlayerWin;
        player.playerDied += OnPlayerLose;
    }

    public void Ui_LaunchGame()
    {
        gameLaunch.Invoke();
        menuStart.SetActive(false);
    }

    public void OnPlayerWin()
    {
        winPanel.SetActive(true);
    }

    private void OnPlayerLose()
    {
        losePanel.SetActive(true);
    }

    public void UI_ReloadScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
