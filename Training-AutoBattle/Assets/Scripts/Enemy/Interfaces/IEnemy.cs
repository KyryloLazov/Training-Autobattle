public interface IEnemy
{
    public float Health { get; set; }
    
    void Initialize(EnemyConfig config);
    
    void TakeDamage(float damage);
}
