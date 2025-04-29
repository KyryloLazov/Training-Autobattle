using System.Collections.Generic;
using UnityEngine;

public interface ISpawnStrategy
{
    void SpawnEnemy(TeamConfig teamConfig, Factory factory);
}
