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

    public void SpawnEnemies(TeamConfig teamConfig)
    {
        _spawnStrategy.SpawnEnemy(teamConfig, _factory);
    }
}
