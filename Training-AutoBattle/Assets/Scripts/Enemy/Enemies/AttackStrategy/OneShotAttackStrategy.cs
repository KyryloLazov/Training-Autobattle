using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneShotAttackStrategy : IAttackStrategy
{
    public void Attack(float damage, IEnemy target)
    {
        target.TakeDamage(target.Health);
    }
}
