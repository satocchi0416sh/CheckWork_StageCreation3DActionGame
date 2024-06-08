using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageCreator : MonoBehaviour
{
    [SerializeField] private GameObject groundPrefab;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var hit))
            {
                CreateGround(hit.point);
            }
        }
        
    }
    
    private void CreateGround(Vector3 position)
    {
        Instantiate(groundPrefab, position, Quaternion.identity);
    }
}
