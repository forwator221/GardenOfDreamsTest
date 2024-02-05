using System;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour, IHealth
{
    [SerializeField] private EnemyConfig _config;
    [SerializeField] private EnemyHealthView _healthView;

    [SerializeField] UnityEvent OnDie;

    public IHealth Health { get; private set; }

    public int MaxValue => _config.HealthMax;

    public bool IsAlive => Health.IsAlive;

    public int Value => Health.Value;

    public void Initialize()
    {
        Health = new Health(_config.HealthMax, MaxValue, _healthView);
        _healthView.Initialize();
    }

    public void TakeDamage(int damage)
    {
        Health.TakeDamage(damage);
        _healthView.Show(Value);
    }

    public void Die()
    {
        Initialize();
        OnDie?.Invoke();
    }

    public void Heal(int healAmount)
    {
        
    }
}
