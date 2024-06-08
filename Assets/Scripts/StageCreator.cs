using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageCreator : MonoBehaviour
{
    [SerializeField] private GameObject groundPrefab;
    [SerializeField] private StagePartManager stagePartManager;
    [SerializeField] private ModeSwitcher modeSwitcher;
    
    private void Update()
    {
        if (!modeSwitcher.IsCreateMode) return;
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var hit))
            {
                if (stagePartManager.IsPartSelected) return;
                if (hit.collider.CompareTag("Lava"))
                {
                    CreateGround(hit.point);
                }
                else
                {
                    SelectPart(hit.collider.gameObject);
                }
            }
        }
    }
    
    private void CreateGround(Vector3 position)
    {
        GameObject ground = Instantiate(groundPrefab, position, Quaternion.identity);
        StageDataManager.Instance.AddStagePartData(ground);
    }
    
    private void SelectPart(GameObject part)
    {
        stagePartManager.SelectPart(part);
    }
}
