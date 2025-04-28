using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class HealthModel
{
    public ReactiveProperty<float> CurrentHp { get; }
    public ReactiveProperty<float> MaxHp { get; }

    public HealthModel(float maxHp) 
    {
        MaxHp = new ReactiveProperty<float>(maxHp);
        CurrentHp = new ReactiveProperty<float>(maxHp);
    }

    public void TakeDamage(float damage) 
    {
        CurrentHp.Value = Mathf.Max(CurrentHp.Value - damage, 0);
    }
}
