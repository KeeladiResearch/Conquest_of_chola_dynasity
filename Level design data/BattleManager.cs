using UnityEngine;
using System.Collections;

public class BattleManager : MonoBehaviour
{
    public LevelData currentLevel;
    private int currentWaveIndex = 0;

    void Start()
    {
        StartCoroutine(RunBattle());
    }

    IEnumerator RunBattle()
    {
        foreach (var wave in currentLevel.waves)
        {
            yield return StartCoroutine(SpawnWave(wave));
        }

        Debug.Log("Level Completed!");
    }

    IEnumerator SpawnWave(WaveData wave)
    {
        Debug.Log($"Starting Wave: {wave.waveName}");
        foreach (var type in wave.enemyTypes)
        {
            for (int i = 0; i < type.count; i++)
            {
                SpawnEnemy(type.prefabName);
                yield return new WaitForSeconds(wave.spawnInterval);
            }
        }
    }

    void SpawnEnemy(string enemyId)
    {
        // Your prefab lookup + instantiate logic
        Debug.Log($"Spawned enemy: {enemyId}");
    }
}
