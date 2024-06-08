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
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.y = 0f;
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            CreateGround(worldPosition);
        }
        
    }
    
    private void CreateGround(Vector3 position)
    {
        Instantiate(groundPrefab, position, Quaternion.identity);
    }
}
