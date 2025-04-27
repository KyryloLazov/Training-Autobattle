using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemySpawnInstaller : MonoInstaller
{
    [SerializeField] private Factory _factory;
    [SerializeField] private List<EnemyConfig> _configs = new();
    [SerializeField] private GameConfig _gameConfig;
    public override void InstallBindings()
    {
        Container.Bind<Factory>().FromInstance(_factory).AsSingle();
        Container.BindInterfacesAndSelfTo<SequentialSpawnStrategy>().AsSingle();
        Container.Bind<List<EnemyConfig>>().FromInstance(_configs).AsSingle();
        Container.Bind<GameConfig>().FromInstance(_gameConfig).AsSingle();
        Container.Bind<EnemySpawner>().AsSingle();
    }
}
