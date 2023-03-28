using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneScript : MonoBehaviour
{
    public void MoveToScene(int sceneID)
    {
        Debug.Log("test");
        SceneManager.LoadScene(sceneID);
        
    }
}
