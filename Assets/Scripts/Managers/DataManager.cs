using System.Collections.Generic;
using UnityEngine;
using Utils;

[System.Serializable]
public struct GameData
{
    public int PlayerShipId;
}

[System.Serializable]
public struct StageData
{
    public int EnemyType;
    public int SpawnPoint;

    public StageData(int type, int spawn)
    {
        EnemyType = type;
        SpawnPoint = spawn;
    }
}

public class DataManager : Singleton<DataManager>
{
    public enum ShipType
    {
        Player = 0,
        Enemy = 7
    }
    
    private GameData _data;
    private List<ShipData> _shipDatas;
    private List<StageData>[] _stages = new List<StageData>[150];

    protected override void Awake()
    {
        base.Awake();
        Initialize();
    }

    public void Initialize() //외부에서 관리?
    {
        _shipDatas.AddRange(Resources.LoadAll<ShipData>("ScriptableObjects/PlayerDatas"));
        _shipDatas.AddRange(Resources.LoadAll<ShipData>("ScriptableObjects/EnemyDatas"));
        LoadStageData();
    }
        
    public ShipData GetSelectedPlayerShipData()
    {
        return _shipDatas[_data.PlayerShipId];
    }
    
    public ShipData GetShipData(ShipType type, int index)
    {
        return _shipDatas[(int)type + index];
    }
    
    private void LoadStageData()
    {
        TextAsset rawCsvAsset = Resources.Load<TextAsset>("StageData/StageDataV1");
        string[] splitByLine = rawCsvAsset.text.Split("\n");
        for (int i = 0; i < _stages.Length; ++i)
        {
            string[] splitByComma = splitByLine[i].Split(",");
            int index = 1;
            while (splitByComma[index] != null && splitByComma[index] != "")
            {
                StageData data = new StageData(int.Parse(splitByComma[index]), int.Parse(splitByComma[index+1]));
                _stages[i].Add(data);
                index += 2;
            }
        }
    }
    
    public List<StageData> GetStageData(int index)
    {
        return _stages[index];
    }
}
