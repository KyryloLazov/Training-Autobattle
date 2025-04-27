using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{
    public GameObject SpawnObject(GameObject prefab, Vector3 spawnPoint)
    {
        if (spawnPoint == null) return null;
        
        GameObject gameObject = Instantiate(prefab, spawnPoint, Quaternion.identity);
        return gameObject;
    }
}