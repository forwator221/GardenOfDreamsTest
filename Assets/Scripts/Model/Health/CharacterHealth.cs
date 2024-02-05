using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealth : MonoBehaviour, IHealth
{
    [SerializeField] private CharacterConfig _config;
    [SerializeField] private CharacterHealthView _healthView;

    public IHealth Health { get; private set; }

    public int MaxValue => _config.HealthMax;

    public bool IsAlive => Health.IsAlive;

    public int Value => Health.Value;

    public void Heal(int healAmount)
    {
        Health.Heal(healAmount);
        _healthView.Show(Value);
    }

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
}
