using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModeSwitcher : MonoBehaviour
{
    [SerializeField] private Text modeChangeButtonText;
    [SerializeField] private GameObject createModeUI;
    [SerializeField] private GameObject createModeCamera;
    [SerializeField] private GameObject player;
    private bool _isCreateMode = true;
    
    
    public void OnClickModeChangeButton()
    {
        _isCreateMode = !_isCreateMode;
        
        if (_isCreateMode)
        {
            modeChangeButtonText.text = "作成モード";
            createModeUI.SetActive(true);
            createModeCamera.SetActive(true);
            player.SetActive(false);
        }
        else
        {
            modeChangeButtonText.text = "プレイモード";
            createModeUI.SetActive(false);
            createModeCamera.SetActive(false);
            player.SetActive(true);
        }
    }
}
