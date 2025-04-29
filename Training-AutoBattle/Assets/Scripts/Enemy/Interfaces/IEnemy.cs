using UniRx;
using UnityEngine;

public interface IEnemy
{
    public float Health { get; set; }
    public TeamIdentifiers TeamID { get; set; }
    Vector3 Position { get; set; }
    
    public ReactiveProperty<bool> IsDead { get; set; }
    
    void Initialize(EnemyConfig config, TeamIdentifiers teamID);
    
    void TakeDamage(float damage);
}
