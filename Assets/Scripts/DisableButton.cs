using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisableButton : MonoBehaviour
{
    public Color32 colorDisable;
    public void UI_DiableButton(Button button)
    {
        button.enabled = false;
        button.targetGraphic.color = colorDisable;
    }
}
