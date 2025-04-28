using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Zenject;

public class GameInitializer : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Button _startButton;
    
    private EnemySpawner _spawner;
    private GameConfig _gameConfig;

    [Inject]
    private void Construct(EnemySpawner spawner, GameConfig gameConfig)
    {
        _spawner = spawner;
        _gameConfig = gameConfig;
    }

    private void OnEnable()
    {
        _startButton.onClick.AddListener(StartBattle);
    }

    private void OnDisable()
    {
        _startButton.onClick.RemoveAllListeners();
    }

    private void StartBattle()
    {
        _startButton.interactable = false;
        for (int i = 0; i < _gameConfig.TeamCount; i++)
        {
            _spawner.SpawnEnemies(_spawnPoints[i].position, _gameConfig.DistanceBtwTeammates, i);
        }
    }
    
}
