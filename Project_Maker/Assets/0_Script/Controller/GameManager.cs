using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonBehabiour<GameManager>
{
    PlayerData pData;
    public PlayerData Pdata { get { return pData; } }

    protected override void Awake()
    {
        base.Awake();

        Application.targetFrameRate = 60;
    }

    void Start()
    {
        // LoadData();
        
        // Test
        pData = new PlayerData();
        OpenData(pData);
    }

    void OpenData(PlayerData _pData)
    {
        StageControl.Instance.Open(_pData);
        BallControl.Instance.Open(_pData);
        PlayerControl.Instance.Open(_pData);
        EnemyControl.Instance.Open(_pData);
        UIControl.Instance.Open(_pData);
    }

    public void SaveData()
    {
        string _jsonString = JsonUtility.ToJson(pData);
        PlayerPrefs.SetString("SaveData", _jsonString);
    }

    public void LoadData()
    {
        if (PlayerPrefs.HasKey("SaveData"))
        {
            string _jsonString = PlayerPrefs.GetString("SaveData");
            pData = JsonUtility.FromJson<PlayerData>(_jsonString);
        }
        else
        {
            UnityEngine.Debug.Log("<color=red>Create New Data</color>");
            pData = new PlayerData();
            SaveData();
        }
    }
}
