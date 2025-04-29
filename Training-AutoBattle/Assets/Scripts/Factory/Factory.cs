using UnityEngine;
using Zenject;

public class Factory : MonoBehaviour
{
    private DiContainer _container;
    
    [Inject]
    public void Construct(DiContainer container)
    {
        _container = container;
    }
    
    public GameObject SpawnObject(GameObject prefab, Vector3 spawnPoint)
    {
        GameObject gameObject = _container.InstantiatePrefab(prefab);
        gameObject.transform.position = spawnPoint;
        return gameObject;
    }
}