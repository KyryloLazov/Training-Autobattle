using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySeeker
{
    public IEnemy FindClosestEnemy(List<IEnemy> enemies, Vector3 position)
    {
        IEnemy closestEnemy = null;
        float shortestDistance = float.MaxValue;

        for (int i = enemies.Count - 1; i >= 0; i--)
        {
            var enemy = enemies[i];
            if (enemy == null || (enemy as MonoBehaviour) == null)
            {
                enemies.RemoveAt(i);
                continue;
            }

            float distance = Vector3.Distance(position, enemy.Position);
            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                closestEnemy = enemy;
            }
        }

        return closestEnemy;
    }
}
