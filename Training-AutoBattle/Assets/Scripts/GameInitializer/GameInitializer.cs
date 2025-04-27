using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameInitializer : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    
    private EnemySpawner _spawner;
    private GameConfig _gameConfig;

    [Inject]
    private void Construct(EnemySpawner spawner, GameConfig gameConfig)
    {
        _spawner = spawner;
        _gameConfig = gameConfig;
    }
    private void Start()
    {
        for (int i = 0; i < _gameConfig.TeamCount; i++)
        {
            _spawner.SpawnEnemies(spawnPoints[i].position, _gameConfig.DistanceBtwTeammates);
        }
    }
    
}
