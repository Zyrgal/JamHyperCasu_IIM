using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnviroManager : MonoBehaviour
{
    [SerializeField] List<GameObject> enviroList;
    //[SerializeField] Button halloweenButton;
    //dictionnaire avec une string serait mieux (dynamique)

    [SerializeField] GameObject playerNormal;
    [SerializeField] GameObject playerHalloween;

    [SerializeField] FollowPlayer followPlayer;
    [SerializeField] Display123 display123;
    [SerializeField] EnemySpotting enemySpotting;
    [SerializeField] UiManager uiManager;

    public void Awake()
    {
        enemySpotting = FindObjectOfType<EnemySpotting>();
    }

    public void EnableHalloweenEnviro()
    {
        //halloweenButton.interactable = true;
    }

    public void UI_DisplayEnviro(int index)
    {
        for (int i = 0; i < enviroList.Count; i++)
        {
            enviroList[i].SetActive(false);
        }

        if (index == 0)
        {
            uiManager.greenSquareBaseLevel.SetActive(true);
            uiManager.greenSquareHalloweenLevel.SetActive(false);
        }
        else if (index == 1)
        {
            uiManager.greenSquareBaseLevel.SetActive(false);
            uiManager.greenSquareHalloweenLevel.SetActive(true);

        }

        enviroList[index].SetActive(true);
        ScoreManager.instance.currentLevelSelected = index;

        /*if (index == 0)
        {
            SetCharacterNormal();
        }
        else if (index == 1)
        {
            SetCharacterHalloween();
        }*/

    }

    public void SetCharacterHalloween()
    {
        playerNormal.SetActive(false);
        playerHalloween.SetActive(true);
        followPlayer.SetTarget(playerHalloween);
        display123.SetTarget(playerHalloween.GetComponent<InputPlayer>());
        if (enemySpotting == null)
        {
            enemySpotting = FindObjectOfType<EnemySpotting>();
        }
        enemySpotting.SetTarget(playerHalloween.GetComponent<InputPlayer>());
        uiManager.SetTarget(playerHalloween.GetComponent<InputPlayer>());
        uiManager.greenSquareBaseCharacter.SetActive(false);
        uiManager.greenSquareHalloweenCharacter.SetActive(true);
        ScoreManager.instance.currentCharacterSelected = 1;
    }

    public void SetCharacterNormal()
    {
        playerNormal.SetActive(true);
        playerHalloween.SetActive(false);
        followPlayer.SetTarget(playerNormal);
        display123.SetTarget(playerNormal.GetComponent<InputPlayer>());
        enemySpotting.SetTarget(playerNormal.GetComponent<InputPlayer>());
        uiManager.SetTarget(playerNormal.GetComponent<InputPlayer>());
        uiManager.greenSquareBaseCharacter.SetActive(true);
        uiManager.greenSquareHalloweenCharacter.SetActive(false);
        ScoreManager.instance.currentCharacterSelected = 0;
    }
}
