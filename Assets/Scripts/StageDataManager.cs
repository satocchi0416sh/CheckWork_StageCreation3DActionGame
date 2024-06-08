using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageDataManager : MonoBehaviour
{
    public List<GameObject> stagePartDataList = new List<GameObject>();
    [SerializeField] private GameObject groundPrefab;
    
    //--------------------------------------------------
    // これはシングルトンパターンといって、一つのインスタンスしか生成しないようにするためのコード！
    // これにより、どこからでもStageDataManager.Instanceでアクセスできるようになる
    public static StageDataManager Instance { get; private set; }
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    //--------------------------------------------------

    private void Start()
    {
        stagePartDataList.Clear();
        LoadFromJson();
    }
    
    private void LoadFromJson()
    {
        string path = "Assets/Resources/StageData.json";
        // ファイルが存在しない場合は処理を抜ける
        if (!System.IO.File.Exists(path)) return;
        
        string json = System.IO.File.ReadAllText(path);
        StageData stageData = JsonUtility.FromJson<StageData>(json);
        
        foreach (var stagePartData in stageData.parts)
        {
            GameObject stagePart = Instantiate(groundPrefab, stagePartData.position, Quaternion.identity);
            stagePartDataList.Add(stagePart);
        }
    }

    public void AddStagePartData(GameObject stagePart)
    {
        stagePartDataList.Add(stagePart);
    }
    
    public void RemoveStagePartData(GameObject stagePart)
    {
        stagePartDataList.Remove(stagePart);
    }
    
    public void OnClickSaveButton()
    {
        StageData stageData = new StageData();
        stageData.parts = new List<StagePartData>();
        
        foreach (var stagePart in stagePartDataList)
        {
            StagePartData stagePartData = new StagePartData();
            stagePartData.type = stagePart.tag;
            stagePartData.position = stagePart.transform.position;
            stageData.parts.Add(stagePartData);
        }
        
        string json = JsonUtility.ToJson(stageData);
        Debug.Log(json);
        SaveToJson(json);
    }

    private void SaveToJson(string json)
    {
        string path = "Assets/Resources/StageData.json";
        System.IO.File.WriteAllText(path, json);
    }
}

// Json保存用のクラス
[Serializable]
public class StageData
{
    public List<StagePartData> parts;
}

[Serializable]
public class StagePartData
{
    public string type;
    public Vector3 position;
}