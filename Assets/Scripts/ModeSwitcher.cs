using System;
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
    public bool IsCreateMode => _isCreateMode;

    private void Start()
    {
        modeChangeButtonText.text = "作成モード";
        createModeCamera.SetActive(true);
        player.SetActive(false);
        
        // 作成モードでスタートするが、選択状態ではないためUIを表示しない
        // createModeUI.SetActive(true);
    }

    public void OnClickModeChangeButton()
    {
        _isCreateMode = !_isCreateMode;
        
        if (_isCreateMode)
        {
            modeChangeButtonText.text = "作成モード";
            createModeCamera.SetActive(true);
            player.SetActive(false);
            
            // 前回選択した状態で作成モードに切り替えた場合、再び作成モードに切り替えた際にUIを表示したい
            if (GetComponent<StagePartManager>().IsPartSelected)
            {
                createModeUI.SetActive(true);
            }
        }
        else
        {
            modeChangeButtonText.text = "プレイモード";
            createModeUI.SetActive(false);
            createModeCamera.SetActive(false);
            player.SetActive(true);
            player.GetComponent<PlayerController>().ResetPosition();
        }
    }
}
