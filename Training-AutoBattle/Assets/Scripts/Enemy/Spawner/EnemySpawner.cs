using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemySpawner
{
    private List<EnemyConfig> _configs = new();
    private Factory _factory;
    
    private ISpawnStrategy _spawnStrategy;
    
    public EnemySpawner(Factory factory, ISpawnStrategy strategy, List<EnemyConfig> enemies)
    {
        _factory = factory;
        _spawnStrategy = strategy;
        _configs = enemies;
    }

    public void SpawnEnemies(Vector3 spawnPosition, float offset, int TeamID)
    {
        _spawnStrategy.SpawnEnemy(_configs, _factory, spawnPosition, offset, TeamID);
    }
}
