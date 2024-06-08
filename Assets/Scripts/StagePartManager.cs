using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StagePartManager : MonoBehaviour
{
    private GameObject _selectedPart;
    private bool _isPartSelected;
    public bool IsPartSelected => _isPartSelected;
    
    [SerializeField] private GameObject partButtonContainer;

    private void Start()
    {
        _isPartSelected = false;
        partButtonContainer.SetActive(false);
    }

    public void SelectPart(GameObject part)
    {
        _selectedPart = part;
        _isPartSelected = true;
        partButtonContainer.SetActive(true);
    }

    public void OnDeleteButtonClicked()
    {
        if (_isPartSelected)
        {
            StageDataManager.Instance.RemoveStagePartData(_selectedPart);
            Destroy(_selectedPart);
            _isPartSelected = false;
            partButtonContainer.SetActive(false);
        }
    }
    
    public void OnCancelButtonClicked()
    {
        _isPartSelected = false;
        partButtonContainer.SetActive(false);
    }
}
