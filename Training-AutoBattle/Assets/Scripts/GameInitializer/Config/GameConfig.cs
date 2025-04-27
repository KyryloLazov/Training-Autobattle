using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "Configs/GameInitializer")]
public class GameConfig : ScriptableObject
{
    [field: SerializeField] public int TeamCount { get; private set; } = 2;
    [field: SerializeField] public float DistanceBtwTeammates { get; private set; } = 10f;
}
