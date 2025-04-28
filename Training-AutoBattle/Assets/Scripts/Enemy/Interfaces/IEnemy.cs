using UnityEngine;

public interface IEnemy
{
    public float Health { get; set; }
    public int TeamID { get; set; }
    Vector3 Position { get; set; }
    
    public bool IsDead { get; set; }
    
    void Initialize(EnemyConfig config, int teamID);
    
    void TakeDamage(float damage);
}
