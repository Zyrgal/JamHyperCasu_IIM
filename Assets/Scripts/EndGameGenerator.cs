using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameGenerator : MonoBehaviour
{
    [SerializeField]
    InputPlayer player;

    [SerializeField]
    UiManager uimanager;
    
    [SerializeField]
    private Display123 display123;

    [SerializeField]
    AdsManager adsManager;
    
    //bool canSpotMovement;
    
    public GameObject enemyPrefab;
    // Start is called before the first frame update
    void Awake()
    {
        GameObject enemySpotting = Instantiate(enemyPrefab, new Vector3(0, 0, (-17f + (7 + 1) * 9)), Quaternion.identity, gameObject.transform);
        EnemySpotting tempScript = enemySpotting.GetComponent<EnemySpotting>();
        tempScript.Player1 = player;
        tempScript.Uimanager1 = uimanager;
        //tempScript.CanSpotMovement1 = canSpotMovement;
        display123.EnemySpotting1 = tempScript;
        display123.FinishLine1 = tempScript.FinishLine1;
        tempScript.FinishLine1 = tempScript.FinishLine1;
        tempScript.DisplayScript = display123;
        tempScript.AdsManager = adsManager;
        uimanager.FinishLine1 = tempScript.FinishLine1;
    }
}