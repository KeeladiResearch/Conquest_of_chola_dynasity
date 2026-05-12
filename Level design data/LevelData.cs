using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "LevelData", menuName = "Game/Level Data")]
public class LevelData : ScriptableObject
{
    public string levelName;
    public string description;
    public int valorTarget;
    public int sageTarget;

    public List<WaveData> waves;
    public List<Checkpoint> checkpoints;
    public int rewardXP;
}

[System.Serializable]
public class WaveData
{
    public string waveName;
    public int enemyCount;
    public float spawnInterval;
    public List<EnemyType> enemyTypes;
}

[System.Serializable]
public class EnemyType
{
    public string prefabName;
    public int count;
}

[System.Serializable]
public class Checkpoint
{
    public string checkpointId;
    public string message;
    public int valorBonus;
    public int sageBonus;
}
