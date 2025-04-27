using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequentialSpawnStrategy : ISpawnStrategy
{
    public void SpawnEnemy(List<EnemyConfig> enemyConfigs, Factory factory, Vector3 spawnPoint, float offset)
    {
        for(int i = 0; i < enemyConfigs.Count; i++)
        {
            Vector3 currentSpawnPoint = spawnPoint + new Vector3(0f, 0f, offset * i);
            GameObject enemyGO = factory.SpawnObject(enemyConfigs[i].EnemyPrefab, currentSpawnPoint);
            enemyGO.GetComponent<IEnemy>().Initialize(enemyConfigs[i]);
        }
    }
}
