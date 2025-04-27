using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAttackStrategy : IAttackStrategy
{
    public void Attack(float damage, IEnemy target)
    {
        target.TakeDamage(damage);
    }
}
