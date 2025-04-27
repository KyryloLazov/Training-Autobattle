using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour, IEnemy
{
    public float Health { get; set; }
    private float _speed;
    private float _damage;

    private IAttackStrategy _attackStrategy;
    
    public void Initialize(EnemyConfig config)
    {
        Health = config.Health;
        _speed = config.Speed;
        _damage = config.Damage;
    }
    
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        throw new System.NotImplementedException();
    }
}
