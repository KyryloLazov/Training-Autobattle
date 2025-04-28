using System;
using UnityEngine;

[Serializable]
public class AtackStrategyProbability
{
    [field: SerializeField] public AtackStrategyData Data { get; private set; }
    [field: SerializeField, Range(0, 1)] public float Probability { get; private set; }
}
