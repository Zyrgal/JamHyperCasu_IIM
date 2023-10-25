using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetBaseCharacterSkin : MonoBehaviour
{
    [SerializeField] EnviroManager enviroManager;

    public void Start()
    {
        GetComponent<Button>().onClick.AddListener(SetBaseCharacter);
    }

    public void SetBaseCharacter()
    {
        enviroManager.SetCharacterNormal();
    }
}
