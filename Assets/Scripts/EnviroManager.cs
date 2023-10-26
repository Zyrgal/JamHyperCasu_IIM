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

    [SerializeField] GameObject lightBaseLevel;
    [SerializeField] GameObject lightHalloweenLevel;

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
            lightBaseLevel.SetActive(true);
            lightHalloweenLevel.SetActive(false);
            uiManager.greenSquareBaseLevel.GetComponent<Image>().enabled = true;
            uiManager.greenSquareHalloweenLevel.GetComponent<Image>().enabled = false;
        }
        else if (index == 1)
        {
            lightBaseLevel.SetActive(false);
            lightHalloweenLevel.SetActive(true);
            uiManager.greenSquareBaseLevel.GetComponent<Image>().enabled = false;
            uiManager.greenSquareHalloweenLevel.GetComponent<Image>().enabled = true;

        }

        enviroList[index].SetActive(true);
        ScoreManager.instance.currentMapSelected = index;

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
        uiManager.greenSquareBaseCharacter.GetComponent<Image>().enabled = false;
        uiManager.greenSquareHalloweenCharacter.GetComponent<Image>().enabled = true;
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
        uiManager.greenSquareBaseCharacter.GetComponent<Image>().enabled = true;
        uiManager.greenSquareHalloweenCharacter.GetComponent<Image>().enabled = false;
        ScoreManager.instance.currentCharacterSelected = 0;
    }
}
