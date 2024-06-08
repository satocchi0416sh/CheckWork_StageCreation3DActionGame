using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModeSwitcher : MonoBehaviour
{
    [SerializeField] private Text modeChangeButtonText;
    
    public void OnClickModeChangeButton()
    {
        if (modeChangeButtonText.text == "作成モード")
        {
            modeChangeButtonText.text = "プレイモード";
        }
        else
        {
            modeChangeButtonText.text = "作成モード";
        }
    }
}
