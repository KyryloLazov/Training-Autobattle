using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AttackStrategiesConfig", menuName = "Configs/AttackStrategiesConfig")]
public class AttackStrategiesConfig : ScriptableObject
{
    [field: SerializeField] public List<AtackStrategyProbability> attackStrategies = new ();
}
