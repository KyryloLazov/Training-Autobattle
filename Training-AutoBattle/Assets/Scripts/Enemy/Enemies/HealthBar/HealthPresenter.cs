using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class HealthPresenter
{
    private readonly HealthModel _health;
    private readonly HealthView _view;

    public ReactiveCommand<Unit> HasDied { get; } = new ReactiveCommand<Unit>();

    public HealthPresenter(HealthModel health, HealthView view)
    {
        _health = health;
        _view = view;
        
        _health.CurrentHp.Subscribe(hp => OnHealthChanged(hp, _health.MaxHp.Value))
            .AddTo(_view);
        
        _view.UpdateHealthBar(_health.CurrentHp.Value, _health.MaxHp.Value);
    }

    private void OnHealthChanged(float currentHp, float maxHp)
    {
        _view.UpdateHealthBar(currentHp, maxHp);

        if (_view.FillAmount <= 0) {
            HasDied.Execute(Unit.Default);
        }
    }

    public void TakeDamage(float dmg)
    {
        _health.TakeDamage(dmg);
    }
}
