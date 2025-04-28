using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;
using Zenject;

public class BaseEnemy : MonoBehaviour, IEnemy
{
    [SerializeField] private HealthView _healthView;
    public float Health { get; set; }
    public int TeamID { get; set; }
    public Vector3 Position
    {
        get => transform.position;
        set => transform.position = value;
    }

    public bool IsDead { get; set; }

    private float _speed;
    private float _damage;
    private float _range;
    private bool _inRange;

    private List<IEnemy> _enemies = new();
    private IEnemy _closestEnemy;

    private IAttackStrategy _attackStrategy;
    private AttackStrategiesConfig _config;
    private StrategyChooser _chooser;

    private HealthPresenter _healthPresenter;
    private HealthModel _healthModel;

    [Inject]
    private void Construct(AttackStrategiesConfig config, StrategyChooser chooser)
    {
        _config = config;
        _chooser = chooser;
    }
    
    public void Initialize(EnemyConfig config, int teamID)
    {
        Health = config.Health;
        _speed = config.Speed;
        _damage = config.Damage;
        _range = config.Range;
        IsDead = false;
        TeamID = teamID;
        _healthModel = new HealthModel(Health);
        _healthPresenter = new HealthPresenter(_healthModel, _healthView);
        _healthPresenter.HasDied
            .Subscribe(_ => Die())
            .AddTo(this);
    }

    private void Start()
    {
        IEnemy[] allEnemies = FindObjectsOfType<MonoBehaviour>().OfType<IEnemy>().ToArray();
        
        foreach (var enemy in allEnemies)
        {
            if (enemy.TeamID != TeamID)
            {
                _enemies.Add(enemy);
            }
        }

        _attackStrategy = _chooser.ChooseStrategy(_config);
    }

    void Update()
    {
        FindClosestEnemy();
        CheckDistance();
        MoveToEnemy();
        Attack();
    }

    private void FindClosestEnemy()
    {
        if (_enemies.Count <= 0 && !_closestEnemy.IsDead) return;
        float shortestDistance = float.MaxValue;

        for (int i = _enemies.Count - 1; i >= 0; i--)
        {
            var enemy = _enemies[i];
            if (enemy == null || (enemy as MonoBehaviour) == null)
            {
                _enemies.RemoveAt(i);
                continue;
            }

            float distance = Vector3.Distance(transform.position, enemy.Position);
            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                _closestEnemy = enemy;
            }
        }
    }

    private void CheckDistance()
    {
        if (_closestEnemy == null || _closestEnemy.IsDead) return;
        _inRange = Vector3.Distance(Position, _closestEnemy.Position) <= _range;
    }

    private void MoveToEnemy()
    {
        if (_closestEnemy == null || _closestEnemy.IsDead || _inRange) return;
        Vector3 direction = (_closestEnemy.Position - Position).normalized;
        transform.Translate(direction * (_speed * Time.deltaTime));
    }

    private void Attack()
    {
        if (!_inRange || _closestEnemy.IsDead) return;
        _attackStrategy.Attack(_damage, _closestEnemy);
    }

    public void TakeDamage(float damage)
    {
        _healthPresenter?.TakeDamage(damage);
    }

    private void Die()
    {
        IsDead = true;
        Destroy(gameObject);
    }
}
