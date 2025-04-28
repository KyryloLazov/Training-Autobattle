using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StrategyChooser
{
    public IAttackStrategy ChooseStrategy(AttackStrategiesConfig config)
    {
        float randomPoint = Random.value;

        float cumulative = 0f;
        foreach (var entry in config.attackStrategies)
        {
            cumulative += entry.Probability;
            if (randomPoint <= cumulative)
            {
                return entry.Data.strategy;
            }
        }
        
        return config.attackStrategies.Last().Data.strategy;
    }
}
