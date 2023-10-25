using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneManager : MonoBehaviour
{
    int currentSceneIndex;
    public void LoadSceneFrom()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
