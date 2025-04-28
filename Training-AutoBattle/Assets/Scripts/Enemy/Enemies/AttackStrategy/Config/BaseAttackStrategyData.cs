using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BaseAttackStrategyData", menuName = "Configs/BaseAttackStrategyData")]
public class BaseAttackStrategyData : AtackStrategyData
{
    public override IAttackStrategy strategy { get; protected set; } = new BaseAttackStrategy();
}
