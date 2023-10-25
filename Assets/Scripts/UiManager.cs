using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [SerializeField]
    private FinishLine finishLine;

    public FinishLine FinishLine1 { get => finishLine; set => finishLine = value; }

    InputPlayer player;

    [SerializeField] GameObject winPanel;
    [SerializeField] GameObject losePanel;
    public event Action gameLaunch;
    [SerializeField] private GameObject menuStart;

    [SerializeField] GameObject shopMenu;
    [SerializeField] GameObject characterMenu;
    [SerializeField] GameObject buttonToRemove;

    public GameObject greenSquareBaseLevel;
    public GameObject greenSquareHalloweenLevel;
    public GameObject greenSquareBaseCharacter;
    public GameObject greenSquareHalloweenCharacter;

    private void Start()
    {
        //finishLine = FindObjectOfType<FinishLine>();
        player = GameObject.Find("Player").GetComponent<InputPlayer>();
        RewardedAdsButton.onHalloweenMapReward += HalloweenMapUnlock;
        finishLine.crossEndLine += OnPlayerWin;
        player.playerDied += OnPlayerLose;
        player.isRevive += HideLoseMenu;
    }

    public void SetTarget(InputPlayer newTarget)
    {
        if (player != null)
        {
            player.playerDied -= OnPlayerLose;
            player.isRevive -= HideLoseMenu;
        }
        

        player = newTarget;

        player.playerDied += OnPlayerLose;
        player.isRevive += HideLoseMenu;
    }

    private void OnDestroy()
    {
        player.playerDied -= OnPlayerLose;
        player.isRevive -= HideLoseMenu;
        finishLine.crossEndLine -= OnPlayerWin;
        RewardedAdsButton.onHalloweenMapReward -= HalloweenMapUnlock;
    }

    private void HalloweenMapUnlock()
    {
        buttonToRemove.GetComponent<Button>().enabled = false;
        buttonToRemove.GetComponent<Image>().enabled = false;
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

    public void UI_DisplayCharacterMenu(bool activate)
    {
        characterMenu.SetActive(activate);
        menuStart.SetActive(!activate);
    }
}
