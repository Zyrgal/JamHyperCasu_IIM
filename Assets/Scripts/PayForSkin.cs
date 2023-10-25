using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PayForSkin : MonoBehaviour
{
    [SerializeField] int cost;
    [SerializeField] EnviroManager enviroManager;
    [SerializeField] TextMeshProUGUI costText;
    [SerializeField] GameObject goldCoin;

    public void Start()
    {
        GetComponent<Button>().onClick.AddListener(AddButtonForPay);
    }

    public void AddButtonForPay()
    {
        if (ScoreManager.instance.havePayForHalloweenSkinCharacter) 
        {
            enviroManager.SetCharacterHalloween();
        }
        else if(ScoreManager.instance.CanPay(cost) && !ScoreManager.instance.havePayForHalloweenSkinCharacter)
        {
            ScoreManager.instance.Pay(cost);
            costText.color = Color.green;
            ScoreManager.instance.havePayForHalloweenSkinCharacter = true;
            enviroManager.SetCharacterHalloween();
            ScoreManager.instance.isGoldCoinActivate = false;
        }
        else if (!ScoreManager.instance.CanPay(cost))
        {
            Debug.Log("Pas assez d'or");
        }
    }


}
