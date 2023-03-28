using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    private FinishLine finishLine;
    InputPlayer player;

    [SerializeField]
    GameObject winPanel;
    [SerializeField]
    GameObject losePanel;

    private void Start()
    {
        finishLine = GameObject.FindObjectOfType<FinishLine>();
        player = GameObject.Find("Player").GetComponent<InputPlayer>();
        finishLine.crossEndLine += OnPlayerWin;
        player.playerDied += OnPlayerLose;
        //finishLine.crossEndLine += OnPlayerLose;
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
