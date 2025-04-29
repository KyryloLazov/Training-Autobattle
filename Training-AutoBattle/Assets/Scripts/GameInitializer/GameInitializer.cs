using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Zenject;

public class GameInitializer : MonoBehaviour
{
    [SerializeField] private List<TeamConfig> _teams;
    [SerializeField] private InitializerView _view;
    
    private CompositeDisposable _disposable = new();
    private bool _battleStarted;
    
    private EnemySpawner _spawner;
    private ReactiveProperty<GameStates> _gameState = new(GameStates.PrepareState);

    [Inject]
    private void Construct(EnemySpawner spawner)
    {
        _spawner = spawner;
    }

    private void OnEnable()
    {
        SubscribeToMethods();
    }

    private void SubscribeToMethods()
    {
        _view.StartButtonPressed.Subscribe(_ => _gameState.Value = GameStates.BattleState)
            .AddTo(_disposable);

        _view.PauseButtonPressed.Subscribe(_ => _gameState.Value = GameStates.PauseState)
            .AddTo(_disposable);
        
        _gameState.Subscribe(_ => CheckState(_gameState.Value))
            .AddTo(_disposable);
    }

    private void CheckState(GameStates state)
    {
        switch (state)
        {
            case GameStates.BattleState:
                UnPause();
                StartBattle();
                break;
            case GameStates.PauseState:
                Pause();
                break;
        }
    }

    private void Pause()
    {
        Time.timeScale = 0;
    }

    private void UnPause()
    {
        Time.timeScale = 1;
    }

    private void StartBattle()
    {
        if (_battleStarted) return;
        foreach (var team in _teams)
        {
            _spawner.SpawnEnemies(team);
        }

        _battleStarted = true;
    }
    
}
