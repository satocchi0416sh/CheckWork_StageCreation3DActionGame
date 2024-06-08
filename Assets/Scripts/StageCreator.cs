using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageCreator : MonoBehaviour
{
    [SerializeField] private GameObject groundPrefab;
    [SerializeField] private StagePartManager stagePartManager;
    
    private void Update()
    {
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
        Instantiate(groundPrefab, position, Quaternion.identity);
    }
    
    private void SelectPart(GameObject part)
    {
        stagePartManager.SelectPart(part);
    }
}
