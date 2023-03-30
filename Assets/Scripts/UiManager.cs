using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class UiManager : MonoBehaviour
{
    [SerializeField]
    private FinishLine finishLine;
    [SerializeField]
    AdsManager adsManager;
    InputPlayer player;

    [SerializeField]
    GameObject winPanel;
    [SerializeField]
    GameObject losePanel;
    public event Action gameLaunch;
    [SerializeField]
    private GameObject menuStart;

    private void Awake()
    {
        //finishLine = GameObject.FindObjectOfType<FinishLine>();
        player = GameObject.Find("Player").GetComponent<InputPlayer>();
        adsManager = GameObject.Find("AdsManager").GetComponent<AdsManager>();
        finishLine.crossEndLine += OnPlayerWin;
        player.playerDied += OnPlayerLose;
        adsManager.rewardWatched += HideLoseMenu;
    }

    private void HideLoseMenu()
    {
        losePanel.SetActive(false);
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
