using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class TeamConfig
{
    [field: SerializeField] public TeamIdentifiers Team { get; private set; }
    [field: SerializeField] public List<EnemyConfig> Enemies { get; private set; }
    [field: SerializeField] public Transform SpawnPoint { get; private set; }
    [field: SerializeField] public float Offset { get; private set; }
}
