using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;
using Zenject;

public class BaseEnemy : MonoBehaviour, IEnemy
{
    [SerializeField] private HealthView _healthView;
    public float Health { get; set; }
    public TeamIdentifiers TeamID { get; set; }

    public Vector3 Position
    {
        get => transform.position;
        set => transform.position = value;
    }

    public ReactiveProperty<bool> IsDead { get; set; } = new();

    private float _speed;
    private float _damage;
    private float _range;
    private ReactiveProperty<bool> _inRange = new();

    private List<IEnemy> _enemies = new();
    private IEnemy _closestEnemy;
    private ReactiveProperty<IEnemy> _fightingTarget = new();

    private IAttackStrategy _attackStrategy;
    private AttackStrategiesConfig _config;
    private StrategyChooser _chooser;

    private HealthPresenter _healthPresenter;
    private HealthModel _healthModel;
    private EnemySeeker _enemySeeker;

    [Inject]
    private void Construct(AttackStrategiesConfig config, StrategyChooser chooser, EnemySeeker seeker)
    {
        _config = config;
        _chooser = chooser;
        _enemySeeker = seeker;
    }

    public void Initialize(EnemyConfig config, TeamIdentifiers teamID)
    {
        Health = config.Health;
        _speed = config.Speed;
        _damage = config.Damage;
        _range = config.Range;
        IsDead.Value = false;
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

        FindClosestEnemy();
        
        _fightingTarget
            .Where(target => target != null)
            .SelectMany(target => target.IsDead.Where(d => d))
            .Subscribe(_ =>
            {
                _fightingTarget.Value = null;
                FindClosestEnemy();
            })
            .AddTo(this);
        
        // _inRange
        //     .Where(inRange => inRange)
        //     .Subscribe(_ => Attack())
        //     .AddTo(this);
    }

    void Update()
    {
        CheckDistance();
        MoveToEnemy();

        if (_inRange.Value && _fightingTarget.Value != null)
        {
            Attack();
        }
    }


    private void FindClosestEnemy()
    {
        var alive = _enemies.Where(e => !e.IsDead.Value).ToList();
        _fightingTarget.Value = _enemySeeker.FindClosestEnemy(alive, Position);
    }

    private void CheckDistance()
    {
        var target = _fightingTarget.Value;
        if (target == null) return;
        _inRange.Value = Vector3.Distance(Position, target.Position) <= _range;
    }


    private void MoveToEnemy()
    {
        if (_fightingTarget.Value == null) return;
        Vector3 direction = (_fightingTarget.Value.Position - Position).normalized;
        transform.Translate(direction * (_speed * Time.deltaTime));
    }

    private void Attack()
    {
        _attackStrategy.Attack(_damage, _fightingTarget.Value);
    }

    public void TakeDamage(float damage)
    {
        _healthPresenter?.TakeDamage(damage);
    }

    private void Die()
    {
        IsDead.Value = true;
        Destroy(gameObject);
    }
}