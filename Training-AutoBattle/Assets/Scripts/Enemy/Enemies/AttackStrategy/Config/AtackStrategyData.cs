using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AtackStrategyData : ScriptableObject
{
    public abstract IAttackStrategy strategy { get; protected set; }
}
