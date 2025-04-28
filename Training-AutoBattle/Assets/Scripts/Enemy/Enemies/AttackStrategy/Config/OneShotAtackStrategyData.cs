using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "OneShotAttackStrategyData", menuName = "Configs/OneShotAttackStrategyData")]
public class OneShotAttackStrategyData : AtackStrategyData
{
    public override IAttackStrategy strategy { get; protected set; } = new OneShotAttackStrategy();
}
