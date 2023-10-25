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
    [SerializeField]
    RewardedAdsButton rewardedAdsButton;
    public event Action gameLaunch;
    [SerializeField]
    private GameObject menuStart;

    [SerializeField] GameObject shopMenu;

    private void Start()
    {
        //finishLine = FindObjectOfType<FinishLine>();
        player = GameObject.Find("Player").GetComponent<InputPlayer>();
        //rewardedAdsButton = GameObject.Find("RewardedAdsButton").GetComponent<RewardedAdsButton>();
        finishLine.crossEndLine += OnPlayerWin;
        player.playerDied += OnPlayerLose;
        player.isRevive += HideLoseMenu;
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
        gameObject.GetComponent<RewardedAdsButton>().ShowAd();
        losePanel.SetActive(true);
    }

    public void UI_ReloadScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void UI_DisplayShopMenu(bool activate)
    {
        shopMenu.SetActive(activate);
        menuStart.SetActive(!activate);
    }
}
