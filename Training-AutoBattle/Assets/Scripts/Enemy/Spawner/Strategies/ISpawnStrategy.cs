using System.Collections.Generic;
using UnityEngine;

public interface ISpawnStrategy
{
    void SpawnEnemy(List<EnemyConfig> enemyConfigs, Factory factory, Vector3 spawnpoint, float offset);
}
