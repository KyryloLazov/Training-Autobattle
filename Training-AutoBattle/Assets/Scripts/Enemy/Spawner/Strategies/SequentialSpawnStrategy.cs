using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequentialSpawnStrategy : ISpawnStrategy
{
    public void SpawnEnemy(TeamConfig teamConfig, Factory factory)
    {
        for(int i = 0; i < teamConfig.Enemies.Count; i++)
        {
            Vector3 currentSpawnPoint = teamConfig.SpawnPoint.position + new Vector3(0f, 0f, teamConfig.Offset * i);
            GameObject enemyGO = factory.SpawnObject(teamConfig.Enemies[i].EnemyPrefab, currentSpawnPoint);
            enemyGO.GetComponent<IEnemy>().Initialize(teamConfig.Enemies[i], teamConfig.Team);
        }
    }
}
