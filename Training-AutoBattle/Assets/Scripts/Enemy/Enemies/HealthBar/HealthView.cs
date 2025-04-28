using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour
{
    [SerializeField] private Image _healthBarFill;
    
    public float FillAmount => _healthBarFill.fillAmount;

    public void UpdateHealthBar(float currentHp, float maxHp)
    {
        _healthBarFill.fillAmount = currentHp / maxHp;
    }
}
